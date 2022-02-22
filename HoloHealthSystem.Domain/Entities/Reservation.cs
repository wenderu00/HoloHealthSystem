using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloHealthSystem.Domain.Entities
{
    public class Reservation : Entity
    {
        private IList<Apointment> _apoints;
        public Reservation(Room room, Doctor doctor,DateTime begin, DateTime end)
        {
            Room = room;
            Doctor = doctor;
            Begin = begin;
            End = end;
            _apoints = new List<Apointment>();
        }
        public Room Room { get; private set; }
        public Doctor Doctor { get; private set; }
        public DateTime Begin { get; private set; }
        public DateTime End { get; private set; }
        
        public IReadOnlyCollection<Apointment> Apoints { get { return _apoints.ToArray(); } }
        public bool BeginBetween(Reservation reservation)
        {
            return reservation.Begin > Begin && reservation.Begin < End;
        }
        public bool EndBetween(Reservation reservation)
        {
            return reservation.End > Begin && reservation.End < End;
        }
        public bool ReservationBetween(Reservation reservation)
        {
            return reservation.BeginBetween(this) && reservation.EndBetween(this);
        }
        public bool HasConflictTime(Reservation reservation)
        {
            return BeginBetween(reservation) || EndBetween(reservation) || ReservationBetween(reservation);
        }
        public bool ValidApointment(Apointment apoint)
        {
            return apoint.Time >Begin && apoint.Time <End;
        }
        public bool HasConflictApointment(Apointment apoint)
        {
            foreach(var x in _apoints)
            {
                if(x.HasConclictTime(apoint)) return true;
            }
            return false;
        }
        public void AddApointment(Apointment apoint)
        {
            if (ValidApointment(apoint) && !_apoints.Contains(apoint) && !HasConflictApointment(apoint))
            {
                _apoints.Add(apoint);
            }
        }
        public void RemoveApointment(Apointment apoint)
        {
            _apoints.Remove(apoint);
        }
    }
}
