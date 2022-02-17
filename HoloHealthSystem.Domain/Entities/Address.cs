using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloHealthSystem.Domain.Entities
{
    public class Address
    {
        public Address(string distric, string street, string number,Clinic clinic)
        {
            District = distric;
            Street = street;
            Number = number;
            Clinic = clinic;
            Id = clinic.Id;
        }
        public Guid Id { get; private set; }
        public string District { get; private set; }
        public string Street { get; private set; }
        public string Number { get; private set; }

        public Clinic Clinic { get; private set; }
    }
}
