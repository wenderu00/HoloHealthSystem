using Flunt.Notifications;
using Flunt.Validations;
using HoloHealthSystem.Domain.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloHealthSystem.Domain.Commands.RoomCommands
{
    public class CreateRoomCommand : Notifiable<Notification>,ICommand
    {
        public CreateRoomCommand() { }
        public CreateRoomCommand(Guid clinic,string number)
        {
            Clinic = clinic;
            Number = number;
        }
        public Guid Clinic { get; set; }
        public string? Number { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract<bool>()
                .AreNotEquals(Guid.Empty, Clinic, "Clinica inválida")
                .IsNotNullOrEmpty(Number, "É necessário o número")
                );
        }
    }
}
