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
        public Doctor(string crm, EEspecialty especialty, Email email, Name name, DateTime birth, CPF cpf) : base(email, name, birth, cpf)
        {
            CRM= crm;
            Clinics= new List<Clinic>();
            Reservations=new List<Reservation>();
        }
        public string CRM { get; private set; }
        public EEspecialty eEspecialty { get; private set; }
        public IList<Clinic> Clinics { get; private set;}
        public IList<Reservation> Reservations { get; private set; }
    }
}
