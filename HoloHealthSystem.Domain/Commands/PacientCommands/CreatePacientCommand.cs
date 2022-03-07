using Flunt.Notifications;
using Flunt.Validations;
using HoloHealthSystem.Domain.Commands.Contracts;
using HoloHealthSystem.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloHealthSystem.Domain.Commands.PacientCommands
{
    public class CreatePacientCommand : Notifiable<Notification>, ICommand
    {
        public CreatePacientCommand() { }
        public CreatePacientCommand(string email, string given_name, string family_name, DateTime birth, string cpf)
        {
            
            Email = new Email(email);
            Name = new Name(given_name, family_name);
            Birth = birth;
            CPF = new CPF(cpf);
        }
        public Email? Email { get; set; }
        public Name? Name { get; set; }
        public DateTime Birth { get; set; }
        public CPF? CPF { get; set; }
        public void Validate()
        {
            if (Email == null || Name == null || CPF == null)
            {
                AddNotifications(new Contract<bool>()
                    .IsNotNull(Email, "O e-mail é necessário")
                    .IsNotNull(Name, "O CRM é necessário")
                    .IsNotNull(CPF, "O CPF é necessário")
                    );
            }
            else
            {
                AddNotifications(Email, Name, CPF);
            }
        }
    }
}
