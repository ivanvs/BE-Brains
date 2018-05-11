using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace T5_P2_1.Models.DTOs
{
    public class AddressDTO
    {
        public AddressDTO() { }

        public AddressDTO(Address address)
        {
            Id = address.Id;
            Street = address.Street;
            City = address.City;
            Country = address.Country;
        }
        
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}