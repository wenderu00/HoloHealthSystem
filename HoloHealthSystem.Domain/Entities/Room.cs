using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloHealthSystem.Domain.Entities
{
    public class Room : Entity
    {
        public Room(string number, Clinic clinic)
        {
            Number = number;
            Clinic = clinic;
        }
        public string Number { get; private set; }
        public Clinic Clinic { get; private set; }
    }
}
