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
        public Pacient(Email email, Name name, DateTime birth, CPF cpf) : base(email, name, birth, cpf)
        {
            Apoints= new List<Apointment>();
        }
        public IList<Apointment> Apoints { get; private set; }
    }
}
