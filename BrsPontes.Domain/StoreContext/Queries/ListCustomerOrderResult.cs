﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BrsPontes.Domain.StoreContext.Queries
{
    public class ListCustomerOrderResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }
        public decimal Total { get; set; }
    }
}
