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
    public class FakeDoctorRepository : IDoctorRepository
    {
        public void Create(Doctor doctor)
        {
            
        }

        public Doctor GetById(string crm)
        {
            return new Doctor("12345678",0,new Email("mwmcjr@gmail.com"), new Name("marcio", "wendell"), DateTime.Now, new CPF("62318902364"));
        }

        public void Update(Doctor doctor)
        {
            
        }
    }
}
