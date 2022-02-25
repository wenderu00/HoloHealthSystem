using HoloHealthSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloHealthSystem.Domain.Repositories
{
    public interface IStateRepository
    {
        void Create(State state);
        void Update(State state);
        State GetByID(Guid id);
    }
}
