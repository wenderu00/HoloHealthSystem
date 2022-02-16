using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloHealthSystem.Domain.Entities
{
    public class City:Entity
    {
        public City(State state,string name)
        {
            State = state;
            Name = name;
            Addresses = new List<Address>();
        }
        public string Name { get; private set; }
        public State State { get; private set; }
        public IList<Address> Addresses { get; private set; }
        public void AddAddress(Address address)
        {
            if (!Addresses.Contains(address))
            {
                Addresses.Add(address);
            }
        }
    }
}
