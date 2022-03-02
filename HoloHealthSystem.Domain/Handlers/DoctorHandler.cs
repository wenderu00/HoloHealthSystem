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
        private readonly IClinicRepository _clinicRepository;
        public DoctorHandler(IDoctorRepository doctorRepository,IClinicRepository clinicRepository)
        {
            _doctorRepository = doctorRepository;
            _clinicRepository = clinicRepository;
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
            command.Validate();
            if (!command.IsValid)
                return new GenericCommandResult(false, "O comando não é válido", command.Notifications);
            var clinic = _clinicRepository.GetById(command.Clinic);
            if(clinic==null)
                return new GenericCommandResult(false, "A clinica não existe", command.Clinic);
            var doctor = _doctorRepository.GetById(command.Doctor);
            if (doctor == null)
                return new GenericCommandResult(false, "O médico não existe", command.Doctor);
            doctor.AddClinc(clinic);
            clinic.AddDoctor(doctor);
            _doctorRepository.Update(doctor);
            _clinicRepository.Update(clinic);
            return new GenericCommandResult(true, "Médico adicionado a clinica com sucesso", doctor);
            
        }

        public ICommandResult Handle(RemoveClinicOfDoctorCommand command)
        {
            command.Validate();
            if (!command.IsValid)
                return new GenericCommandResult(false, "O comando não é válido", command.Notifications);
            var clinic = _clinicRepository.GetById(command.Clinic);
            if (clinic == null)
                return new GenericCommandResult(false, "A clinica não existe", command.Clinic);
            var doctor = _doctorRepository.GetById(command.Doctor);
            if (doctor == null)
                return new GenericCommandResult(false, "O médico não existe", command.Doctor);
            doctor.RemoveClinic(clinic);
            clinic.RemoveDoctor(doctor);
            _doctorRepository.Update(doctor);
            _clinicRepository.Update(clinic);
            return new GenericCommandResult(true, "Médico removido da clinica com sucesso", doctor);
        }
    }
}
