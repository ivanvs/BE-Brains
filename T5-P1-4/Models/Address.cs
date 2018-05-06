using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace T5_P1_4.Models
{
    public class Address
    {
        public Address()
        {
            Users = new List<User>();
        }

        [JsonProperty("ID")]
        public int Id { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}