using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadialGraphSite.Models
{
    public class Person
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
