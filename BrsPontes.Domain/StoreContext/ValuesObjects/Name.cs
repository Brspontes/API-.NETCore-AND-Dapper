using FluentValidator;
using FluentValidator.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BrsPontes.Domain.StoreContext.ValuesObjects
{
    public class Name : Notifiable
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new ValidationContract().Requires()
                .HasMinLen(FirstName, 3, "FirstName", "O nome deve conter pelo menos três caracteres")
                .HasMaxLen(firstName, 40, "FirstName", "O nome deve conter no máximo 40 caracteres")
                .HasMinLen(lastName, 3, "LastName", "O sobrenome deve conter no minimo 3 caracteres")
                .HasMaxLen(firstName, 40, "LastName", "O sobrenome deve conter no máximo 40 caracteres"));
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
