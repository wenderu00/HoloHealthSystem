using HoloHealthSystem.Domain.Commands.Contracts;
using HoloHealthSystem.Domain.Commands.PacientCommands;
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
    public class PacientHandler : IHandler<CreatePacientCommand>
    {
        private readonly IPacientRepository _pacientRepository;
        public PacientHandler(IPacientRepository pacientRepository)
        {
            _pacientRepository=pacientRepository;
        }
        public ICommandResult Handle(CreatePacientCommand command)
        {
            command.Validate();
            if (!command.IsValid)
                return new GenericCommandResult(false, "comando inválido", command.Notifications);
            var pacient = new Pacient(command.Email, command.Name, command.Birth, command.CPF);
            _pacientRepository.Create(pacient);
            return new GenericCommandResult(true, "paciente criado com sucesso", pacient);
        }
    }
}
