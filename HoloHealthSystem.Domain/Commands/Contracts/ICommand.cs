﻿using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloHealthSystem.Domain.Commands.Contracts
{
    public interface ICommand
    {
        void Validate();
    }
}
