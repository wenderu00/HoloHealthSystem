using Flunt.Notifications;
using HoloHealthSystem.Domain.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloHealthSystem.Domain.Commands.ApointmentCommands
{
    public class MarkAsDoneApointmentCommand : Notifiable<Notification>, ICommand
    {
        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
