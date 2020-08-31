using DM2BD.RadialGraph;
using Microsoft.AspNetCore.Components;
using RadialGraphSite.Models;
using RadialGraphSite.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadialGraphSite.Pages
{
    public partial class Index : ComponentBase
    {
        [Inject]
        public IPersonRepository PersonRepository { get; set; }
        
        public List<Edge> Edges { get; set; }
        public List<Node> Nodes { get; set; }
        protected override void OnInitialized()
        {
            base.OnInitialized();
            List<Person> people = PersonRepository.GetPeople();

            Nodes = people.Select((x, i) => new Node { id = i, title = $"{x.FirstName} {x.LastName}" }).ToList();

            Edges = new List<Edge>
            {
                new Edge { from = 0, to = 1, id = 0 },
                new Edge { from = 1, to = 0, id = 1 },
                new Edge { from = 0, to = 2, id = 2 },
                new Edge { from = 2, to = 0, id = 3 },
                new Edge { from = 2, to = 1, id = 3 },
                new Edge { from = 1, to = 2, id = 3 },
                new Edge { from = 1, to = 3, id = 4 },
                new Edge { from = 3, to = 1, id = 5 }
            };
        }
    }
}
