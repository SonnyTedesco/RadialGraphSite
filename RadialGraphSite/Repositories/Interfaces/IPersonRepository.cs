using RadialGraphSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadialGraphSite.Repositories.Interfaces
{
    public interface IPersonRepository
    {
        public List<Person> GetPeople();
    }
}
