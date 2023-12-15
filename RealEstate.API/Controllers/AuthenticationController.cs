using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Contracts.Identity;
using RealEstate.Application.Models.Identity;
using RealEstate.Identity.Models;
using RealEstate.Identity.Services;
using System.ComponentModel.DataAnnotations;

namespace RealEstate.API.Controllers
{
	[Route("api/v1/[controller]")]
	[ApiController]
	public class AuthenticationController : ControllerBase
	{
		private readonly IAuthService _authService;
		private readonly ILogger<AuthenticationController> _logger;
		private readonly IEmailService _emailService;

        public AuthenticationController(IAuthService authService, ILogger<AuthenticationController> logger, IEmailService emailService)
		{
			_authService = authService;
			_logger = logger;
			_emailService = emailService;
		}

		[HttpPost]
		[Route("login")]
		public async Task<IActionResult> Login(LoginModel model)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					return BadRequest("Invalid payload");
				}

				var (status, message) = await _authService.Login(model);

				if (status == 0)
				{
					return BadRequest(message);
				}

				return Ok(message);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}

		[HttpPost]
		[Route("register")]
		public async Task<IActionResult> Register(RegistrationModel model, string role)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					return BadRequest("Invalid payload");
				}

				var (status, message) = await _authService.Registeration(model, role); // by default, all users are clients

				if (status == 0)
				{
					return BadRequest(message);
				}

				return CreatedAtAction(nameof(Register), model);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}

		[HttpGet]
		[Route("confirmEmail")]
		public async Task<IActionResult> ConfirmEmail(string email, string token)
		{
            try
			{
               if(!ModelState.IsValid)
				{
                    return BadRequest("Invalid payload");
				}

			   var (status, message) = await _authService.ConfirmEmail(email, token);

				if (status == 0)
				{
                    return BadRequest(message);
                }

				return CreatedAtAction(nameof(ConfirmEmail), email);
            }
            catch (Exception ex)
			{
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

		[HttpPost]
		[AllowAnonymous]
		[Route("forgotPassword")]
		public async Task<IActionResult> ForgotPassword([Required]string email)
		{
            try
			{
                if (!ModelState.IsValid)
				{
                    return BadRequest("Invalid payload");
                }

                var (status, message) = await _authService.ForgotPassword(email);

                if (status == 0)
				{
                    return BadRequest(message);
                }

                return CreatedAtAction(nameof(ForgotPassword), email);
            }
            catch (Exception ex)
			{
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

		[HttpGet]
		[Route("resetPassword")]
        public async Task<IActionResult> ResetPassword(string email, string token)
		{
			var model = new ResetPasswordModel { Email = email, Token = token };

			return Ok(new
			{
				model
			});
        }

		[HttpPost]
		[Route("resetPassword")]
		public async Task<IActionResult> ResetPasswordConfirmation(ResetPasswordModel model)
		{
			try
			{
                if (!ModelState.IsValid)
				{
                    return BadRequest("Invalid payload");
                }

                var (status, message) = await _authService.ResetPasswordConfirmation(model);

                if (status == 0)
				{
                    return BadRequest(message);
                }

                return CreatedAtAction(nameof(ResetPasswordConfirmation), model);
            }
            catch (Exception ex)
			{
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
		}

		[HttpDelete]
		[Route("deleteUser")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteUser(string email)
		{
			try
			{
                 if (!ModelState.IsValid)
				 {
                    return BadRequest("Invalid payload");
                 }
    
                 var (status, message) = await _authService.DeleteUser(email);
    
                if (status == 0)
				{
                   return BadRequest(message);
                }
   
				return CreatedAtAction(nameof(DeleteUser), email);
            }
            catch (Exception ex)
			{
		         _logger.LogError(ex.Message);
                 return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}

    }
}