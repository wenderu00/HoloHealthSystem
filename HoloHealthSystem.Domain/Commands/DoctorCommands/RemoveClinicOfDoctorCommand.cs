using Flunt.Notifications;
using Flunt.Validations;
using HoloHealthSystem.Domain.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloHealthSystem.Domain.Commands.DoctorCommands
{
    public class RemoveClinicOfDoctorCommand : Notifiable<Notification>, ICommand
    {
        public RemoveClinicOfDoctorCommand() { }
        public RemoveClinicOfDoctorCommand(Guid clinic, Guid doctor)
        {
            Clinic = clinic;
            Doctor = doctor;
        }
        public Guid Clinic { get; set; }
        public Guid Doctor { get; set; }
        public void Validate()
        {
            AddNotifications(new Contract<bool>()
                .AreNotEquals(Guid.Empty, Clinic, "clinica inválida")
                .AreNotEquals(Guid.Empty, Doctor, "médico inválido"));
        }
    }
}
