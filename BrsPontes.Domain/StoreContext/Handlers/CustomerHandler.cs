using BrsPontes.Domain.StoreContext.Commands.CustomerCommands.Input;
using BrsPontes.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using BrsPontes.Domain.StoreContext.Entities;
using BrsPontes.Domain.StoreContext.Repositories;
using BrsPontes.Domain.StoreContext.Services;
using BrsPontes.Domain.StoreContext.ValuesObjects;
using BrsPontes.Shared.Commands;
using FluentValidator;
using System;


namespace BrsPontes.Domain.StoreContext.Handlers
{
    public class CustomerHandler : Notifiable, 
        ICommandHandler<CreateCustomerCommand>, 
        ICommandHandler<AddAddressCommand>
    {

        private readonly ICustomerRepository _repository;
        private readonly IEmailServices _emailServices;

        public CustomerHandler(ICustomerRepository repository, IEmailServices emailServices)
        {
            _repository = repository;
            _emailServices = emailServices;
        }

        public ICommandResult Handle(CreateCustomerCommand command)
        {
            if (_repository.CheckDocument(command.Document))
                AddNotification("Document", "Usuário já cadastrado");
            if (_repository.CheckEmail(command.Email))
                AddNotification("Email", "Email já cadastrado");

            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);

            var customer = new Customer(name, document, email, command.Phone);

            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(customer.Notifications);

            if (Invalid)
                return new CommandResult(false, "Algo de errado não deu certo!!", Notifications);

            _repository.Save(customer);
            _emailServices.Send(email.Address, "brian.robert16@hotmail.com", "Wellcome", "Envio de email teste C#");

            return new CommandResult(true, "Bem vindo", 
                new
                {
                    Id = customer.Id,
                    Name = name.ToString(),
                    Email = email.Address
                });
        }

        public ICommandResult Handle(AddAddressCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
