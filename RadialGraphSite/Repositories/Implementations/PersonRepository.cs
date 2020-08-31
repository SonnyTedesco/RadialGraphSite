using RadialGraphSite.Models;
using RadialGraphSite.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadialGraphSite.Repositories.Implementations
{
    public class PersonRepository : IPersonRepository
    {
        private List<Person> _people = new List<Person> 
        {
            new Person { FirstName = "Sonny", LastName = "Tedesco" },
            new Person { FirstName = "Hunter", LastName = "Freeman" },
            new Person { FirstName = "Bernard", LastName = "Farrell" },
            new Person { FirstName = "John", LastName = "Doe" },
            new Person { FirstName = "Jane", LastName = "Doe" },
            new Person { FirstName = "Mike", LastName = "Doe" }
        };
        public List<Person> GetPeople()
        {
            return _people;
        }
    }
}
