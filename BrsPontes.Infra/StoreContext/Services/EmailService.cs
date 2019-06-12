using BrsPontes.Domain.StoreContext.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BrsPontes.Infra.StoreContext.Services
{
    public class EmailService : IEmailServices
    {
        public void Send(string to, string from, string subject, string body)
        {
            //TODO: Implementar
        }
    }
}
