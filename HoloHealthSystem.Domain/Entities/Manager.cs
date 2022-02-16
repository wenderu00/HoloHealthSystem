using HoloHealthSystem.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloHealthSystem.Domain.Entities
{
    public class Manager : User
    {
        public Manager(Clinic clinic,Email email, Name name, DateTime birth, CPF cpf) : base(email, name, birth, cpf)
        {
            Clinic = clinic;
        }
        public Clinic Clinic { get; private set; }

        public void ChangeClinic(Clinic clinic)
        {
        }
    }

}
