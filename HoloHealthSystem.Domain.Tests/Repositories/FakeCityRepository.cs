using HoloHealthSystem.Domain.Entities;
using HoloHealthSystem.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloHealthSystem.Domain.Tests.Repositories
{
    public class FakeCityRepository : ICityRepository
    {
        public void Create(City city)
        {
            
        }

        public City GetById(Guid id)
        {
            return new City(new State("Pernambuco"),"Recife");
        }
    }
}
