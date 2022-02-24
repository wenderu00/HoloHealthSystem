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
    public class CreateClinicCommand : Notifiable<Notification>, ICommand
    {
        public CreateClinicCommand() { }
        public CreateClinicCommand(string name, string district, string street, string number,Guid city)
        {
            Name = name;
            District = district;
            Street = street;
            Number = number;
            City = city;
        }
        public string? Name { get; set; }
        public string? District { get;  set; }
        public string? Street { get; set; }
        public string? Number { get; set; }
        public Guid City { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract<bool>()
                .Requires()
                .IsNotNullOrEmpty(District, "É necessário o bairro")
                .IsNotNullOrEmpty(Street, "É necessário a rua")
                .IsNotNullOrEmpty(Number, "É necessário o número")
                .IsNotNullOrEmpty(Name, "Nome do consultório é necessário")
                .IsNotNull(City,"Cidade é necessária")
                .IsGreaterThan(Name, 3, "O nome é muito pequeno")
                );
        }
    }
}
