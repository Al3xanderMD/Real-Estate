using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RealEstate.Application.Contracts.Identity;
using RealEstate.Application.Models.Identity;
using RealEstate.Identity.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RealEstate.Identity.Services
{
	public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration configuration;
        private readonly IEmailService emailService;

        public AuthService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, IEmailService emailService)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.configuration = configuration;
            this.emailService = emailService;
        }
        public async Task<(int, string)> Registeration(RegistrationModel model)
        {
            var userExists = await userManager.FindByNameAsync(model.Username);
            var emailExists = await userManager.FindByEmailAsync(model.Email);

            if (emailExists != null)
                return (0, "User already exists");

            if (userExists != null)
                return (0, "Username already exists");

            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username,
                Name = model.Name,
                PhoneNumber = model.PhoneNumber
            };

            var createUserResult = await userManager.CreateAsync(user, model.Password);
            if (!createUserResult.Succeeded)
                return (0, "User creation failed! Please check user details and try again.");

            if (!await roleManager.RoleExistsAsync(model.Role))
                await roleManager.CreateAsync(new IdentityRole(model.Role));

            if (await roleManager.RoleExistsAsync(UserRoles.Client))
                await userManager.AddToRoleAsync(user, model.Role);

            var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
            var confirmationLink = configuration["AppUrl"] + "/api/v1/Authentication/ConfirmEmail?email=" + user.Email + "&token=" + token;
            var message = new Message(new string[] { user.Email }, "Confirmation email link", confirmationLink);
            emailService.SendEmail(message);

            user.EmailConfirmed = false;
            return (1, "User created successfully!");
        }

        public async Task<(int, string)> Login(LoginModel model)
        {
            var user = await userManager.FindByEmailAsync(model.Email!);
            //if (user == null)
            //	return (0, "Invalid username");
            //if (!await userManager.CheckPasswordAsync(user, model.Password!))
            //	return (0, "Invalid password");

            if (user.EmailConfirmed == false)
                return (0, "Email not confirmed");

            if (user == null || !await userManager.CheckPasswordAsync(user, model.Password!))
                return (0, "Invalid email or password");

            
            var userRoles = await userManager.GetRolesAsync(user);
            var authClaims = new List<Claim>
            {
               new Claim(ClaimTypes.Name, user.UserName!),
               new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            authClaims.Add(new Claim("userId",user.Id!));
            authClaims.Add(new Claim(ClaimTypes.Email, user.Email!));
            authClaims.Add(new Claim(ClaimTypes.MobilePhone, user.PhoneNumber!));
            authClaims.Add(new Claim(ClaimTypes.Name, user.Name!));

            string token = GenerateToken(authClaims);
            return (1, token);
        }

        public async Task<(int, string)> ConfirmEmail(string email, string token)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user != null)
            {
                var result = await userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    return (1, "Email confirmed successfully");
                }
            }
            return (0, "Error");
        }

        public async Task<(int, string)> ForgotPassword(string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
                return (0, "Email not found");

            var token = await userManager.GeneratePasswordResetTokenAsync(user);
            var forgotPasswordLink = configuration["AppUrl"] + "/api/v1/Authentication/resetPassword?email=" + user.Email + "&token=" + token;
            var message = new Message(new string[] { user.Email }, "Reset password token", forgotPasswordLink);
            emailService.SendEmail(message);

            return (1, "Reset password token sent to your email");
        }

        public async Task<(int, string)> ResetPasswordConfirmation(ResetPasswordModel model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);

            if (user == null)
                return (0, "Email not found");

            var resetPassResult = await userManager.ResetPasswordAsync(user, model.Token, model.Password);
            if(!resetPassResult.Succeeded)
            {
                foreach (var error in resetPassResult.Errors)
                {
                    return (0, error.Description);
                }
            }
            
            return (1, "Password has been changed");
        }

        public async Task<(int, string)> DeleteUser(string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
                return (0, "User not found");

            if (user.EmailConfirmed == false)
                return (0, "Email not confirmed");

            user.EmailConfirmed = false;
            return (1, "User deleted successfully");
        }

        private string GenerateToken(IEnumerable<Claim> claims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]!));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = configuration["JWT:ValidIssuer"]!,
                Audience = configuration["JWT:ValidAudience"]!,
                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256),
                Subject = new ClaimsIdentity(claims)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
