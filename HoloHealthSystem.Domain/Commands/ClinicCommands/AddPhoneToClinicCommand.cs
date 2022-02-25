using Flunt.Notifications;
using Flunt.Validations;
using HoloHealthSystem.Domain.Commands.Contracts;
using HoloHealthSystem.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloHealthSystem.Domain.Commands.ClinicCommands
{
    public class AddPhoneToClinicCommand : Notifiable<Notification>, ICommand
    {
        public AddPhoneToClinicCommand() { }
        public AddPhoneToClinicCommand(string phone,Guid clinic)
        {
            Phone = new Phone(phone);
            Clinic = clinic;
        }

        public Phone? Phone { get; set; }
        public Guid Clinic { get; set; }
        public void Validate()
        {
            if (Phone == null)
            {
                AddNotifications(new Contract<bool>()
                .AreNotEquals(Clinic, Guid.Empty, "clinica inválida")
                .IsNotNull(Phone, "Telefone inválido"));
            }
            else
            {
                AddNotifications(new Contract<bool>()
                .AreNotEquals(Clinic, Guid.Empty, "clinica inválida")
                .IsNotNull(Phone, "Telefone inválido"),Phone);
            }
            
        }
    }
}
