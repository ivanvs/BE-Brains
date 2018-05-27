using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace T10_P1_2_start.Models
{
    public class Address
    {
        public Address()
        {
            Clients = new List<User>();
        }

        public int Id { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Country { get; set; }

        [Timestamp]
        public byte[] Version { get; set; }

        [JsonIgnore]
        public virtual ICollection<User> Clients { get; set; }
    }
}