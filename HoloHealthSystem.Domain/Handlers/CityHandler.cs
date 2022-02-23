using HoloHealthSystem.Domain.Commands.CityCommands;
using HoloHealthSystem.Domain.Commands.Contracts;
using HoloHealthSystem.Domain.Entities;
using HoloHealthSystem.Domain.Handlers.Contracts;
using HoloHealthSystem.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloHealthSystem.Domain.Handlers
{
    public class CityHandler : IHandler<CreateCityCommand>
    {
        private readonly IStateRepository _stateRepository;
        private readonly ICityRepository _cityRepository;
        public CityHandler(IStateRepository stateRepository,ICityRepository cityRepository)
        {
            _stateRepository = stateRepository;
            _cityRepository = cityRepository;
        }
        public ICommandResult Handle(CreateCityCommand command)
        {
            command.Validate();
            if (!command.IsValid)
                return new GenericCommandResult(false, "O comando é inválido", command.Notifications);
            var state = _stateRepository.GetByID(command.State);
            if(state == null)
                return new GenericCommandResult(false, "O estado não existe", command.State);
            var city = new City(state, "recife");
            _cityRepository.Create(city);
            return new GenericCommandResult(true, "Cidade criada com sucesso", city);
        }
    }
}
