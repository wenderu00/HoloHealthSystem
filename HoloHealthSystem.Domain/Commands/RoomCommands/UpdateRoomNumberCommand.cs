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
    public class UpdateRoomNumberCommand : Notifiable<Notification>, ICommand
    {
        public UpdateRoomNumberCommand() { }
        public UpdateRoomNumberCommand(Guid room,string number)
        {
            Room = room;
            Number = number;
        }
        public Guid Room { get; set; }
        public string? Number { get; set; }
        public void Validate()
        {
            AddNotifications(new Contract<bool>()
                .AreNotEquals(Guid.Empty, Room, "Sala inválida")
                .IsNotNullOrEmpty(Number, "É necessário o número")
                );
        }
    }
}
