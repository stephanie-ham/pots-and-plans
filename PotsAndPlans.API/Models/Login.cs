using System;
using System.ComponentModel.DataAnnotations;

namespace PotsAndPlans.API.Models
{
	public class Login
	{

        [Required(ErrorMessage = "User Name is required")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
        public bool RememberMe { get; internal set; }
    }
}

