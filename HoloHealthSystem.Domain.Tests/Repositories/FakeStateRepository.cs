using HoloHealthSystem.Domain.Entities;
using HoloHealthSystem.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloHealthSystem.Domain.Tests.Repositories
{
    public class FakeStateRepository : IStateRepository
    {
        public void Create(State state)
        {
            
        }


        public State GetByID(Guid id)
        {
            return new State("Pernambuco");
        }

        public void Update(State state)
        {
            
        }
    }
}
