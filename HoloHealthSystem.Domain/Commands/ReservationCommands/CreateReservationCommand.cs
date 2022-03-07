using Flunt.Notifications;
using Flunt.Validations;
using HoloHealthSystem.Domain.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloHealthSystem.Domain.Commands.ReservationCommands
{
    public class CreateReservationCommand : Notifiable<Notification>, ICommand
    {
        public CreateReservationCommand() { }
        public CreateReservationCommand(Guid room, string doctor, DateTime begin, DateTime end)
        {
            Room = room;
            Doctor = doctor;
            Begin = begin;
            End = end;
        }
        public Guid Room { get; set; }
        public string? Doctor { get; set; }
        public DateTime Begin { get; set; }
        public DateTime End { get; set; }

        public void Validate()
        {
            if (Doctor == null)
            {
                AddNotifications(new Contract<bool>()
                .AreNotEquals(Room, Guid.Empty, "Sala inválida")
                .IsNullOrEmpty(Doctor, "Médico inválido")
                .IsGreaterThan(End, Begin, "Horário inválido"));
            }
            else
            {
                AddNotifications(new Contract<bool>()
                .AreNotEquals(Room, Guid.Empty, "Sala inválida")
                .IsGreaterThan(End, Begin, "Horário inválido"));
            }
        }
    }
}
