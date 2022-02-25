using HoloHealthSystem.Domain.Entities;
using HoloHealthSystem.Domain.Repositories;
using HoloHealthSystem.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloHealthSystem.Domain.Tests.Repositories
{
    public class FakeManagerRepository : IManagerRepository
    {
        public void Create(Manager manager)
        {
           
        }

        public Manager GetByID(Guid id)
        {
            return new Manager(new Email("mwmcjr@gmail.com"),new Name("marcio","wendell"), DateTime.Now, new CPF("62318902364"));
        }

        public void Update(Manager manager)
        {
            
        }
    }
}
