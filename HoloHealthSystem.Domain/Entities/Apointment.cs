using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloHealthSystem.Domain.Entities
{
    public class Apointment : Entity
    {
        public Pacient Pacient { get; set; }

    }
}
