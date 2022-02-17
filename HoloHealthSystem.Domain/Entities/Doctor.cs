using HoloHealthSystem.Domain.Enums;
using HoloHealthSystem.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloHealthSystem.Domain.Entities
{
    public class Doctor : User
    {
        private IList<Clinic> _clinics;
        private IList<Reservation> _reservations;
        public Doctor(string crm, EEspecialty especialty, Email email, Name name, DateTime birth, CPF cpf) : base(email, name, birth, cpf)
        {
            CRM= crm;
            _clinics= new List<Clinic>();
            _reservations=new List<Reservation>();
        }
        public string CRM { get; private set; }
        public EEspecialty eEspecialty { get; private set; }

        public IReadOnlyCollection<Clinic> Clinics { get { return _clinics.ToArray(); } }
        public IReadOnlyCollection<Reservation> Reservations { get { return _reservations.ToArray(); } }

        public void AddClinc(Clinic clinic)
        {
            if (!_clinics.Contains(clinic))
            {
                _clinics.Add(clinic);
            }
        }
        public void RemoveClinic(Clinic clinic)
        {
            _clinics.Remove(clinic);
        }
        public bool HasConflictReservation(Reservation reservation)
        {
            foreach (var x in Reservations)
            {
                if (x.HasConflictTime(reservation)) return true;
            }
            return false;
        }
        public void AddReservation(Reservation reservation)
        {
            if(!HasConflictReservation(reservation)) _reservations.Add(reservation);
        }
        public void RemoveReservation(Reservation reservation)
        {
            _reservations.Remove(reservation);
        }
    }
}
