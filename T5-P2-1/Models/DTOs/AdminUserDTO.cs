using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace T5_P2_1.Models.DTOs
{
    public class AdminUserDTO : PrivateUserDTO
    {
        public AdminUserDTO() { }

        public AdminUserDTO(User user) : base(user)
        {
            Email = user.Email;
            DateOfBirth = user.DateOfBirth;
        }

        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}