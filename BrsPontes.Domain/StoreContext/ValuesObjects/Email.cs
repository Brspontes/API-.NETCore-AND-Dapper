﻿using FluentValidator;
using FluentValidator.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BrsPontes.Domain.StoreContext.ValuesObjects
{
    public class Email : Notifiable
    {
        public Email(string address)
        {
            Address = address;

            AddNotifications(new ValidationContract().Requires()
                .IsEmail(Address, "Email", "O e-mail é inválido"));
        }

        public string Address { get; private set; }

        public override string ToString()
        {
            return Address;
        }
    }
}
