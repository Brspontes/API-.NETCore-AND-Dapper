using BrsPontes.Domain.StoreContext.ValuesObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace BrsPontes.Domain.StoreContext.Entitys
{
    public class Customer
    {
        public Customer(Name name, Document document, Email email, string phone, string shippingAddress, string billingAddress)
        {
            Name = name;
            Document = document;
            Email = email;
            Phone = phone;
            ShippingAddress = shippingAddress;
            BillingAddress = billingAddress;
        }

        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public string Phone { get; private set; }
        public string ShippingAddress { get; private set; }
        public string BillingAddress { get; private set; }

        public override string ToString()
        {
            return Name.ToString();
        }
    }
}
