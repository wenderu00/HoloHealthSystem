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
    public class FakeReservationRepository : IReservationRepository
    {
        public void Create(Reservation reservation)
        {
            
        }

        public void Delete(Reservation reservation)
        {
            
        }

        public Reservation GetByID(Guid id)
        {
            return new Reservation(new Room("123",new Clinic("111")), new Doctor("12345678", 0, new Email("mwmcjr@gmail.com"), new Name("marcio", "wendell"), DateTime.Now, new CPF("62318902364")), DateTime.Now,DateTime.Now.AddDays(1));
        }

        public void Update(Reservation reservation)
        {
            
        }
    }
}
