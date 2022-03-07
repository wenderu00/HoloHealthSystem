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
    public class FakePacientRepository : IPacientRepository
    {
        public void Create(Pacient pacient)
        {
            
        }

        public Pacient GetByID(string cpf)
        {
            return new Pacient(new Email("mwmcjr@gmail.com"),new Name("márcio", "wendell") , DateTime.Now, new CPF("62318902364"));
        }

        public void Update(Pacient pacient)
        {
            
        }
    }
}
