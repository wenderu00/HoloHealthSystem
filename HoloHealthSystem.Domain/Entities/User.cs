using Flunt.Notifications;
using Flunt.Validations;
using HoloHealthSystem.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloHealthSystem.Domain.Entities
{
    public abstract class User
    {
        public User(Email email, Name name,DateTime birth,CPF cpf)
        {
            Email = email;
            Name = name;
            Birth = birth;
            Phones = new List<Phone>();
            CPFCode = cpf;

            
        }
        public CPF CPFCode { get; private set; }
        public Email Email { get; private set; }

        public Name Name { get; private set; }
        public IList<Phone> Phones { get; private set; }
        public DateTime Birth { get; private set; }
        public string? HashCode { get; private set; }
        public void AddPhone (Phone phone)
        {
            if (phone.IsValid)
            {
                Phones.Add(phone);
            } ;
        }
        public void RemovePhone(Phone phone)
        {
            Phones.Remove(phone);
        }
        public void UpdateHashCode(string hash)
        {
            HashCode = hash;
        }
    }
}
