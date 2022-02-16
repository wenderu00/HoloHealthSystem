using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloHealthSystem.Domain.Entities
{
    public class Apointment : Entity
    {
        public Apointment(Pacient pacient,Reservation reservation)
        {
            Pacient = pacient;
            Reservation = reservation;
            Done = false;
        }
        public Pacient Pacient { get; private set; }
        public Reservation Reservation { get; private set; }
        public bool Done { get; private set; }

    }
}
