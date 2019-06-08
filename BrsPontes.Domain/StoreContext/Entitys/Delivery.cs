using BrsPontes.Domain.StoreContext.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BrsPontes.Domain.StoreContext.Entitys
{
    public class Delivery
    {
        public Delivery(DateTime stimatedDeliveryDate)
        {
            StimatedDeliveryDate = stimatedDeliveryDate;
            CrateDate = DateTime.Now;
            Status = EDeliveryStatus.Waiting;
        }

        public DateTime CrateDate { get; private set; }
        public DateTime StimatedDeliveryDate { get; private set; }
        public EDeliveryStatus Status { get; private set; }
    }
}
