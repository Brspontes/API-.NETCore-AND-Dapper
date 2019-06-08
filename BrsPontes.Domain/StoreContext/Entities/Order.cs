using BrsPontes.Domain.StoreContext.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrsPontes.Domain.StoreContext.Entities
{
    public class Order
    {
        private readonly IList<OrderItem> _items;
        private readonly IList<Delivery> _deliveries;

        public Order(Customer customer)
        {
            Customer = customer;
            CreateDate = DateTime.Now;
            Status = EOrderStatus.Created;
            _items = new List<OrderItem>();
            _deliveries = new List<Delivery>();
        }

        public Customer Customer { get; private set; }
        public string Number { get; private set; }
        public DateTime CreateDate { get; private set; }
        public EOrderStatus Status { get; private set; }
        public IReadOnlyCollection<OrderItem> Items => _items.ToArray();
        public IReadOnlyCollection<Delivery> Deliveries => _deliveries.ToArray();

        public void AddItem(OrderItem item)
        {
            //Validar Item
            //Adiciona ao pedido
            _items.Add(item);
        }

        //public void AddDelivery(Delivery delivery)
        //{
        //    _deliveries.Add(delivery);
        //}

        //CRIAR PEDIDO
        public void Place()
        {
            Number = Guid.NewGuid()
               .ToString()
               .Replace("-", "")
               .Substring(0, 8)
               .ToUpper();
            //Validar
        }

        //PAGAR PEDIDO
        public void Pay()
        {
            Status = EOrderStatus.Paid;
        }

        //ENVIAR PEDIDO
        public void Ship()
        {
            //A cada 5 produtos uma entrega
            var deliveries = new List<Delivery>();
            var count = 1;
            foreach (var item in _items)
            {
                if(count == 5)
                {
                    count = 1;
                    deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));
                }
            }

            //Envia todas as entregas
            deliveries.ForEach(x => x.Ship());
            //Adiciona as entregas ao pedido
            deliveries.ForEach(x => _deliveries.Add(x));
        }

        //CANCELAR PEDIDO
        public void Cancel()
        {
            Status = EOrderStatus.Canceled;
            _deliveries.ToList().ForEach(x => x.Cancel());
        }
    }
}
