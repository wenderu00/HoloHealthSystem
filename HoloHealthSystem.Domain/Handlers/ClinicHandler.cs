using HoloHealthSystem.Domain.Commands;
using HoloHealthSystem.Domain.Commands.ClinicCommands;
using HoloHealthSystem.Domain.Commands.Contracts;
using HoloHealthSystem.Domain.Entities;
using HoloHealthSystem.Domain.Handlers.Contracts;
using HoloHealthSystem.Domain.Repositories;
using HoloHealthSystem.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloHealthSystem.Domain.Handlers
{
    public class ClinicHandler : 
        IHandler<CreateClinicCommand>,
        IHandler<AddManagerToClinicCommand>,
        IHandler<AddPhoneToClinicCommand>,
        IHandler<RemoveManagerOfClinicCommand>,
        IHandler<RemovePhoneOfClinicCommand>
    {
        //private readonly IStateRepository _stateRepository;
        private readonly ICityRepository _cityRepository;
        private readonly IClinicRepository _clinicRepository;
        private readonly IAddressRepository _addressRepository;
        public ClinicHandler(IClinicRepository clinicRepository,IAddressRepository addressRepository,ICityRepository cityRepository)
        {
            _clinicRepository = clinicRepository;
            _addressRepository = addressRepository;
            _cityRepository = cityRepository;
        }
        public ICommandResult Handle(CreateClinicCommand command)
        {
            command.Validate();
            if (!command.IsValid)
                return new GenericCommandResult(false, "O comando não é válido", command.Notifications);
            var city = _cityRepository.GetById(command.City);
            if(city == null)
                return new GenericCommandResult(false, "A cidade não é válida", command.Notifications);
            var clinic = new Clinic(command.Name);
            var address = new Address(command.District, command.Street, command.Number, city, clinic);
            clinic.AddAddress(address);
            _clinicRepository.Create(clinic);
            _addressRepository.Create(address);
            return new GenericCommandResult(true, "Clinica criada com sucesso", clinic);
        }
        public ICommandResult Handle(RemoveManagerOfClinicCommand command)
        {
            throw new NotImplementedException();
        }

        public ICommandResult Handle(RemovePhoneOfClinicCommand command)
        {
            throw new NotImplementedException();
        }

        public ICommandResult Handle(AddPhoneToClinicCommand command)
        {
            command.Validate();
            if (!command.IsValid)
                return new GenericCommandResult(false, "O comando não é válido", command.Notifications);
            var clinic = _clinicRepository.GetById(command.Clinic);
            if(clinic == null)
                return new GenericCommandResult(false, "O consultório não é válido", command.Notifications);
            clinic.AddPhone(command.Phone);
            _clinicRepository.Update(clinic);
            return new GenericCommandResult(true, "Telefone adicionado com sucesso", command.Phone);

        }

        public ICommandResult Handle(AddManagerToClinicCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
