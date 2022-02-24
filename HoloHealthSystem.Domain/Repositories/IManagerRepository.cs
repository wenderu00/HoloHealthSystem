using HoloHealthSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloHealthSystem.Domain.Repositories
{
    public interface IManagerRepository
    {
        void Create(Manager manager);
        void Update(Manager manager);
        Manager GetByID(Guid id);
    }
}
