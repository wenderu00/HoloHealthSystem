using Flunt.Notifications;
using Flunt.Validations;
using HoloHealthSystem.Domain.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloHealthSystem.Domain.Commands.StateCommands
{
    public class CreateStateCommand : Notifiable<Notification>, ICommand
    {
        public CreateStateCommand() { }
        public CreateStateCommand(string name)
        {
            Name = name;
        }
        public string? Name { get; set; }
        public void Validate()
        {
            AddNotifications(
                new Contract<bool>()
                .Requires()
                .IsNotNull(Name,"Nome do estado é necessário")
                .IsGreaterThan(Name,3,"O nome é muito pequeno")
                );
        }
    }
}
