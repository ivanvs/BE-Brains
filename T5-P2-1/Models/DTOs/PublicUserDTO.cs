using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace T5_P2_1.Models.DTOs
{
    public class PublicUserDTO
    {
        public PublicUserDTO() { }

        public PublicUserDTO(User user)
        {
            Id = user.Id;
            Name = user.Name;
        }

        [JsonProperty("ID")]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}