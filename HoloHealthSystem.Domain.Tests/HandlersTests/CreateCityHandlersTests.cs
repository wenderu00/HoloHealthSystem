using HoloHealthSystem.Domain.Commands.CityCommands;
using HoloHealthSystem.Domain.Entities;
using HoloHealthSystem.Domain.Handlers;
using HoloHealthSystem.Domain.Tests.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloHealthSystem.Domain.Tests.HandlersTests
{
    public class CreateCityHandlersTests
    {
        private readonly CreateCityCommand _invalidCommand = new CreateCityCommand();
        private readonly CreateCityCommand _validCommand = new CreateCityCommand(Guid.NewGuid(), "Recife");
        //private readonly CityHandler _handler = new CityHandler(new FakeStateRepository(),new Fake);
    }
}
