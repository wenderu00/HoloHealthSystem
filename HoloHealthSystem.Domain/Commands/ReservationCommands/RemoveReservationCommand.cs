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
    public class RemoveReservationCommand : Notifiable<Notification>, ICommand
    {
        public RemoveReservationCommand() { }
        public RemoveReservationCommand(Guid reservation)
        {
            Reservation = reservation;
        }
        public Guid Reservation { get; set; }
        public void Validate()
        {
            AddNotifications(new Contract<bool>().AreNotEquals(Reservation,Guid.Empty,"Reserva inválida"));
        }
    }
}
