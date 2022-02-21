using HoloHealthSystem.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloHealthSystem.Domain.Entities
{
    public class Pacient : User
    {
        private IList<Apointment> _apoints;
        public Pacient(Email email, Name name, DateTime birth, CPF cpf) : base(email, name, birth, cpf)
        {
            _apoints= new List<Apointment>();
        }
        public bool HasConflictApointment(Apointment apoint)
        {
            foreach (var x in _apoints)
            {
                if (x.HasConclictTime(apoint)) return true;
            }
            return false;
        }
        public void AddApointment(Apointment apoint)
        {
           
        }
    }
}
