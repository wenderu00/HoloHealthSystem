using HoloHealthSystem.Domain.Entities;
using HoloHealthSystem.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloHealthSystem.Domain.Tests.Repositories
{
    public class FakeRoomRepository : IRoomRepository
    {
        public void Create(Room room)
        {
           
        }

        public Room GetById(Guid room)
        {
            return new Room("202", new Clinic("rua da hora"));
        }

        public void Update(Room room)
        {
            
        }
    }
}
