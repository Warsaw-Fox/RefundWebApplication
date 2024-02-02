﻿using System.ComponentModel.DataAnnotations;

namespace RefundWebApplication.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "Password has to be at least 6 characters")]
        public string Password { get; set; }

        public string? ReturnUrl { get; set; }
    }
}