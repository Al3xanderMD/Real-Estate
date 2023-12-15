namespace RealEstate.App.Models
{
    public class RegisterViewModel
    {
        public string email { get; set; } = string.Empty;
        public string username { get; set; } = string.Empty;
        public string name { get; set; } = string.Empty;
        public string phoneNumber { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public string confirmPassword { get; set; } = string.Empty;
    }
}
