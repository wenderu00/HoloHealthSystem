﻿using Flunt.Notifications;
using Flunt.Validations;
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
        public MarkAsDoneApointmentCommand() { }
        public MarkAsDoneApointmentCommand(Guid apoint)
        {
            Apointment = apoint;
        }
        public Guid Apointment { get; set; }
        public void Validate()
        {
            AddNotifications(new Contract<bool>().AreNotEquals(Guid.Empty, Apointment, "A consulta é necessária"));
        }
    }
}
