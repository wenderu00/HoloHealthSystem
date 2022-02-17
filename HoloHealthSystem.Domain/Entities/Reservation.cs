using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloHealthSystem.Domain.Entities
{
    public class Reservation : Entity
    {
        public Reservation(Room room, Doctor doctor,DateTime begin, DateTime end)
        {
            Room = room;
            Doctor = doctor;
            Begin = begin;
            End = end;
            Apoints = new List<Apointment>();
        }
        public Room Room { get; private set; }
        public Doctor Doctor { get; private set; }
        public DateTime Begin { get; private set; }
        public DateTime End { get; private set; }
        
        public IList<Apointment> Apoints { get; private set; }

        public bool HasConflictTime(Reservation reservation)
        {
            bool BeginBetween = reservation.Begin > Begin && reservation.Begin < End;
            bool EndBetween = reservation.End > Begin && reservation.End < End;
            bool ReservationBetween = Begin > reservation.Begin && Begin < reservation.End;
            return BeginBetween || EndBetween || ReservationBetween;
        }
    }
}
