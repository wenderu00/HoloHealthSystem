using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloHealthSystem.Domain.Entities
{
    public class City:Entity
    {
        private IList<Address> _addresses;
        public City(State state,string name)
        {
            State = state;
            Name = name;
            _addresses = new List<Address>();
        }
        public string Name { get; private set; }
        public State State { get; private set; }
        public IReadOnlyCollection<Address> Addresss { get { return _addresses.ToArray(); } }
        public void AddAddress(Address address)
        {
            if (!_addresses.Contains(address))
            {
                _addresses.Add(address);
            }
        }
    }
}
