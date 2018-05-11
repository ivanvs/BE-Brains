using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace T5_P2_1.Models.DTOs
{
    public class PrivateUserDTO : PublicUserDTO
    {
        public PrivateUserDTO() { }

        public PrivateUserDTO(User user) : base(user)
        {
            Address = new AddressDTO(user.Address);
        }

        public AddressDTO Address { get; set; }
    }
}