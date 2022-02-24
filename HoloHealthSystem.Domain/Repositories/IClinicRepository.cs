using HoloHealthSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloHealthSystem.Domain.Repositories
{
    public interface IClinicRepository
    {
        void Create(Clinic clinic);
        void Update(Clinic clinic);

        Clinic GetById(Guid id);


    }
}
