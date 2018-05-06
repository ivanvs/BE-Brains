using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace T5_P1_2.Models
{
    public class Address
    {
        public Address()
        {
            Users = new List<User>();
        }
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public virtual ICollection<User> Users { get; set; }

        [JsonIgnore]
        public EAccessType AccessType { get; set; }
        public bool ShouldSerializeId()
        {
            return AccessType != EAccessType.Public;
        }
        public bool ShouldSerializeStreet()
        {
            return AccessType != EAccessType.Public;
        }
        public bool ShouldSerializeCity()
        {
            return AccessType != EAccessType.Public;
        }
        public bool ShouldSerializeCountry()
        {
            return AccessType != EAccessType.Public;
        }
        public bool ShouldSerializeUsers()
        {
            return AccessType != EAccessType.Public;
        }
    }

}