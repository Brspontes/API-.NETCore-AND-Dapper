﻿using BrsPontes.Domain.StoreContext.Enums;
using BrsPontes.Shared.Commands;
using FluentValidator;
using System;
using System.Collections.Generic;
using System.Text;

namespace BrsPontes.Domain.StoreContext.Commands.CustomerCommands.Input
{
    public class AddAddressCommand : Notifiable, ICommands
    {
        public Guid Id { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public EAddressType Type { get; set; }

        bool ICommands.Valid()
        {
            return Valid;
        }
    }
}
