using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace T10_P1_2_start.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public virtual Address Address { get; set; }
    }
}