using FluentValidator;
using FluentValidator.Validation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using BrsPontes.Shared.Commands;

namespace BrsPontes.Domain.StoreContext.Commands.CustomerCommands.Input
{
    public class CreateCustomerCommand : Notifiable, ICommands
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public bool Valid()
        {
            AddNotifications(new ValidationContract().Requires()
                .HasMinLen(FirstName, 3, "FirstName", "O nome deve conter pelo menos três caracteres")
                .HasMaxLen(FirstName, 40, "FirstName", "O nome deve conter no máximo 40 caracteres")
                .HasMinLen(LastName, 3, "LastName", "O sobrenome deve conter no minimo 3 caracteres")
                .HasMaxLen(LastName, 40, "LastName", "O sobrenome deve conter no máximo 40 caracteres")
                .IsEmail(Email, "Email", "O e-mail é inválido")
                .HasLen(Document, 11, "Document", "CPF Inválido"));

            return Valid();
        }
    }
}
