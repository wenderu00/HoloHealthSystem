using HoloHealthSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloHealthSystem.Domain.Repositories
{
    public interface IRoomRepository
    {
        void Create(Room room);
        void Update(Room room);
        Room GetById(Guid room);
    }
}
