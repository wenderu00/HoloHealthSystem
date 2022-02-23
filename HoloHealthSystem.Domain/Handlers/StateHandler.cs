using HoloHealthSystem.Domain.Commands.Contracts;
using HoloHealthSystem.Domain.Commands.StateCommands;
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
    public class StateHandler : IHandler<CreateStateCommand>
    {
        private readonly IStateRepository _stateRepository;
        public StateHandler(IStateRepository stateRepository)
        {
            _stateRepository=stateRepository;
        }
        public ICommandResult Handle(CreateStateCommand command)
        {
            command.Validate();
            if (!command.IsValid)
                return new GenericCommandResult(false, "O comando é inválido", command.Notifications);
            var state = new State(command.Name);
            _stateRepository.Create(state);
            return new GenericCommandResult(true, "Estado salvo com sucesso", state);
        }
    }
}
