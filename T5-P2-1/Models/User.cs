﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace T5_P2_1.Models
{
    public class User
    {
        [JsonProperty("ID")]
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; }

        [JsonIgnore]
        public string Password { get; set; }

        public virtual Address Address { get; set; }
    }
}