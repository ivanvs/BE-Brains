using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace T6_P1_1.Models
{
    public class User
    {
        [Required]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "First name must be between 3 and 50 character in length.")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Last name must be between 3 and 50 character in length.")]
        public string LastName { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 5, ErrorMessage = "Password must be between 5 and 10 character in length.")]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "Username must be between 5 and 15 character in length.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Age must be provided")]
        [Range(18, int.MaxValue, ErrorMessage = "Age must be greater then 18")]
        public int? Age { get; set; }
    }
}