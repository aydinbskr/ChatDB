using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjects
{
    public class doMember
    {
        public int? Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Banned { get; set; }
        public bool Online { get; set; }
    }
}
