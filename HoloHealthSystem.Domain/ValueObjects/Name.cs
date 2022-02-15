using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloHealthSystem.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string givenName,string familyName)
        {
            GivenName = givenName;
            FamilyName = familyName;
            AddNotifications(new Contract<bool>()
                .IsGreaterThan(GivenName, 2, "O primeiro nome é muito curto.")
                .IsLowerThan(GivenName, 40, "O primeiro nome é muito grande.")
                .IsGreaterThan(FamilyName, 2, "O sobrenome é muito pequeno"));
        }
        public string GivenName { get; private set; }
        public string FamilyName { get; private set; }

    }
}
