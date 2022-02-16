using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloHealthSystem.Domain.Entities
{
    public class State : Entity
    {
        public State(string name)
        {
            Name = name;
        }
        public string Name { get; private set; }
        public IList<City> Cities { get; private set; }

        public void AddCity(City city)
        {
            if (!Cities.Contains(city))
            {
                Cities.Add(city);
            }
        }
    }
}
