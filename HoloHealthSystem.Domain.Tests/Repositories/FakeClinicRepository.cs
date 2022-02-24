using HoloHealthSystem.Domain.Entities;
using HoloHealthSystem.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloHealthSystem.Domain.Tests.Repositories
{
    public class FakeClinicRepository : IClinicRepository
    {
        public void Create(Clinic clinic)
        {
            
        }

        public Clinic GetById(Guid id)
        {
            return new Clinic("rua da hora");
        }

        public void Update(Clinic clinic)
        {
            
        }
    }
}
