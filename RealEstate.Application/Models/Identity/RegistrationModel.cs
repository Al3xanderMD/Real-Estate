﻿using System.ComponentModel.DataAnnotations;

namespace RealEstate.Application.Models.Identity
{
    public class RegistrationModel
	{
        [Required(ErrorMessage = "User Name is required")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        public string? PhoneNumber { get; set; }
    }
}
