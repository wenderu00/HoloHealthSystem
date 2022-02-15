using Flunt.Br;
using Flunt.Br.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloHealthSystem.Domain.ValueObjects
{
    public class CPF : ValueObject
    {
        public CPF(string cpfcode)
        {
            Code = cpfcode;
            AddNotifications(new Contract().IsCpf(Code,"CPF.Code","O CPF é inválido"));

        }
        public string Code { get; private set; }
    }
}
