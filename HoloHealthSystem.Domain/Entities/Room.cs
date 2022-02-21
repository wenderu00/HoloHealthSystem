using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloHealthSystem.Domain.Entities
{
    public class Room : Entity
    {
        private IList<Reservation> _reservations;
        public Room(string number, Clinic clinic)
        {
            Number = number;
            Clinic = clinic;
            _reservations = new List<Reservation>();
        }
        public string Number { get; private set; }
        public Clinic Clinic { get; private set; }
        
        public IReadOnlyCollection<Reservation> Reservations { get { return _reservations.ToArray(); } }




        public void UpdateNumber(string number)
        {
            if (!Clinic.HasRoomNumber(number))
            {
                Number=number;
            }
        }
        public bool HasConflictReservation(Reservation reservation)
        {
            foreach(var x in Reservations)
            {
                if (x.HasConflictTime(reservation)) return true; 
            }
            return false;
        }
        public void AddReservation(Reservation reservation)
        {
            if (!HasConflictReservation(reservation)&&!_reservations.Contains(reservation))
            {
                _reservations.Add(reservation);
            };
        }
        public void RemoveReservation(Reservation reservation)
        {
            _reservations.Remove(reservation);
        }
    }
}
