using HoloHealthSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloHealthSystem.Domain.Repositories
{
    public interface IDoctorRepository
    {
        void Create(Doctor doctor);
        void Update(Doctor doctor);
        void GetById(Guid doctor);
    }
}
