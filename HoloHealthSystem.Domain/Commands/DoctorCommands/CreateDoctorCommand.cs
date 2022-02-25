using Flunt.Notifications;
using Flunt.Validations;
using HoloHealthSystem.Domain.Commands.Contracts;
using HoloHealthSystem.Domain.Enums;
using HoloHealthSystem.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloHealthSystem.Domain.Commands.DoctorCommands
{
    public class CreateDoctorCommand : Notifiable<Notification>, ICommand
    {
        public CreateDoctorCommand() { }
        public CreateDoctorCommand(string crm,EEspecialty especialty,string email,string given_name,string family_name,DateTime birth,string cpf)
        {
            CRM = crm;
            eEspecialty = especialty;
            Email = new Email(email);
            Name = new Name(given_name, family_name);
            Birth = birth;
            CPF = new CPF(cpf);
        }

        public string? CRM { get; set; }
        public EEspecialty eEspecialty { get; set; }
        public Email? Email { get; set; }
        public Name? Name { get; set; }
        public DateTime Birth { get; set; }
        public CPF? CPF { get; set; }

        public void Validate()
        {
            if (Email == null || Name == null || CPF == null|| CRM==null)
            {
                AddNotifications(new Contract<bool>()
                    .IsNotNullOrEmpty(CRM,"O CRM é necessário")
                    .IsNotNull(Email, "O e-mail é necessário")
                    .IsNotNull(Name, "O CRM é necessário")
                    .IsNotNull(CPF,"O CPF é necessário")
                    );
            }
            else
            {
                AddNotifications(new Contract<bool>()
                    .AreEquals(CRM.Length,8,"O CRM precisa ter 8 digitos"),
                    Email, Name,CPF
                    );
            }
        }
    }
}
