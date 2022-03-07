using Flunt.Notifications;
using Flunt.Validations;
using HoloHealthSystem.Domain.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloHealthSystem.Domain.Commands.ApointmentCommands
{
    public class CreateApointmentCommand : Notifiable<Notification>, ICommand
    {
        public CreateApointmentCommand() { }
        public CreateApointmentCommand(string pacient_cpf,Guid reservation, DateTime time)
        {
            PacientCPF = pacient_cpf;
            Reservation = reservation;
            Time = time;
        }
        public string? PacientCPF { get; set; }
        public Guid Reservation { get; set; }
        public DateTime Time { get; set; }
        public void Validate()
        {
            if(PacientCPF == null)
            {
                AddNotifications(new Contract<bool>()
                    .IsNotNullOrEmpty(PacientCPF,"O CPF do paciente é necessário")
                    .AreNotEquals(Guid.Empty,Reservation,"Id da reserva é necessário")
                    );
            }
            else
            {
                AddNotifications(new Contract<bool>()
                    .AreNotEquals(Guid.Empty, Reservation, "Id da reserva é necessário")
                    );
            }
        }
    }
}
