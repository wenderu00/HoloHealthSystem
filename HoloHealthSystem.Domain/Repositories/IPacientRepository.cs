using HoloHealthSystem.Domain.Entities;
using HoloHealthSystem.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloHealthSystem.Domain.Repositories
{
    public interface IPacientRepository
    {
        void Create(Pacient pacient);
        void Update(Pacient pacient);
        Pacient GetByID(string cpf);
    }
}
