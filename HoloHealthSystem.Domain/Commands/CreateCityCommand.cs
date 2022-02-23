using Flunt.Notifications;
using Flunt.Validations;
using HoloHealthSystem.Domain.Commands.Contracts;
using HoloHealthSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloHealthSystem.Domain.Commands.CityCommands
{
    public class CreateCityCommand : Notifiable<Notification>,ICommand
    {
        public CreateCityCommand() { }
        public CreateCityCommand(Guid state,string name)
        {
            State = state;
            Name = name;
        }

        public Guid? State { get; set; }
        public string? Name { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract<bool>()
                .Requires()
                .IsNotNull(State, "É necessário o estado")
                .IsNotNull(Name, "Nome da cidade é necessária")
                .IsGreaterThan(Name, 3, "O nome é muito pequeno")
                );
        }
    }
}
