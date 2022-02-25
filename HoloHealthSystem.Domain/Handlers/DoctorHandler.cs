using HoloHealthSystem.Domain.Commands.Contracts;
using HoloHealthSystem.Domain.Commands.DoctorCommands;
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
    public class DoctorHandler : 
        IHandler<CreateDoctorCommand>,
        IHandler<AddClinicToDoctorCommand>,
        IHandler<RemoveClinicOfDoctorCommand>
    {
        private readonly IDoctorRepository _doctorRepository;
        public DoctorHandler(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }
        public ICommandResult Handle(CreateDoctorCommand command)
        {
            command.Validate();
            if(!command.IsValid)
                return new GenericCommandResult(false,"O comando não é válido",command.Notifications);
            var doctor = new Doctor(command.CRM, command.eEspecialty, command.Email, command.Name, command.Birth, command.CPF);
            _doctorRepository.Create(doctor);
            return new GenericCommandResult(true, "Médico criado com sucesso", doctor);
        }

        public ICommandResult Handle(AddClinicToDoctorCommand command)
        {
            throw new NotImplementedException();
        }

        public ICommandResult Handle(RemoveClinicOfDoctorCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
