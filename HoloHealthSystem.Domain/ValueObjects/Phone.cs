using Flunt.Br;
using Flunt.Br.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloHealthSystem.Domain.ValueObjects
{
    public class Phone:ValueObject
    {
        public Phone(string number)
        {
            Number = number;
            AddNotifications(new Contract().IsPhone(Number,"Phone.Number","O número de telefone é inválido."));

        }
        public string Number { get; private set; }
    }
}
