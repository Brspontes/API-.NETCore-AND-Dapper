using BrsPontes.Shared.Commands;
using FluentValidator;
using FluentValidator.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BrsPontes.Domain.StoreContext.Commands.OrderCommands.Input
{
    public class PlaceOrderCommand : Notifiable, ICommands
    {
        public Guid Customer { get; set; }
        public  IList<OrderItemCommand> OrderItems { get; set; }

        public PlaceOrderCommand()
        {
            OrderItems = new List<OrderItemCommand>();
        }

        public bool Valid()
        {
            AddNotifications(new ValidationContract().Requires()
                .HasLen(Customer.ToString(), 36, "Customer", "Identificador do cliente inválido")
                .IsGreaterThan(OrderItems.Count, 0, "Items", "Nenhum item do pedido encontrado"));

            return Valid();
        }
    }

    public class OrderItemCommand
    {
        public Guid Product { get; set; }
        public decimal Quantity { get; set; }
    }
}
