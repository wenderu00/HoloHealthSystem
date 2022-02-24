using Flunt.Notifications;
using Flunt.Validations;
using HoloHealthSystem.Domain.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloHealthSystem.Domain.Commands.ClinicCommands
{
    public class RemoveManagerOfClinicCommand : Notifiable<Notification>, ICommand
    {
        public RemoveManagerOfClinicCommand() { }
        public RemoveManagerOfClinicCommand(Guid clinic, Guid manager)
        {
            Clinic = clinic;
            Manager = manager;
        }
        public Guid Clinic { get; set; }
        public Guid Manager { get; set; }
        public void Validate()
        {
            AddNotifications(new Contract<bool>()
                .AreNotEquals(Guid.Empty, Clinic, "Clinica inválida")
                .AreNotEquals(Guid.Empty, Manager, "Gerente inválido")
                );
        }
    }
}
