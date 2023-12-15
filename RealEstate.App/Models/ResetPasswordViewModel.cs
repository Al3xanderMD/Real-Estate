namespace RealEstate.App.Models
{
    public class ResetPasswordViewModel
    {
        public string email { get; set; } = string.Empty;
        public string confirmPassword { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public string token { get; set; } = string.Empty;
    }
}
