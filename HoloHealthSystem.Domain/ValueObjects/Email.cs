using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloHealthSystem.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public Email(string email)
        {
            Address = email;

            AddNotifications(new Contract<bool>()
                .IsEmail(Address, "Email inválido."));
        }
        public string Address { get; private set; }
    }
}
