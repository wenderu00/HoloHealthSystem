using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloHealthSystem.Domain.Entities
{
    public class State : Entity
    {
        private IList<City> _cities;
        public State(string name)
        {
            Name = name;
            _cities = new List<City>();
        }
        public string Name { get; private set; }
        public IReadOnlyCollection<City> Cities { get { return _cities.ToArray(); } }

        public void AddCity(City city)
        {
            if (!_cities.Contains(city))
            {
                _cities.Add(city);
            }
        }
       
    }
}
