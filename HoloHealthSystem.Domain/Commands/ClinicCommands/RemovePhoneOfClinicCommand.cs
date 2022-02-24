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
    public class RemovePhoneOfClinicCommand : Notifiable<Notification>, ICommand
    {
        public RemovePhoneOfClinicCommand() { }
        public RemovePhoneOfClinicCommand(string phone, Guid clinic)
        {
            Phone = phone;
            Clinic = clinic;
        }

        public string? Phone { get; set; }
        public Guid Clinic { get; set; }
        public void Validate()
        {
            AddNotifications(new Contract<bool>()
                .IsNotNullOrEmpty(Phone, "Telefone inválido")
                .AreNotEquals(Clinic, Guid.Empty, "clinica inválida"));
        }
    }
}
