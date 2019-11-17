using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EonReality.Models
{
    public class UserAPI
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public DateTime DateRegistered { get; set; }
        public string DatesAttending { get; set; }
        public string AdditionalRequest { get; set; }
    }
}
