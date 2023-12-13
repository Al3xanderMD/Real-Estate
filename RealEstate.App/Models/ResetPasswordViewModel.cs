namespace RealEstate.App.Models
{
    public class ResetPasswordViewModel
    {
        public string email { get; set; }
        public string confirmPassword { get; set; }
        public string password { get; set; }
        public string token { get; set; }
    }
}
