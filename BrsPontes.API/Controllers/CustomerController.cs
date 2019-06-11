using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrsPontes.Domain.StoreContext.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BrsPontes.API.Controllers
{
    public class CustomerController : Controller
    {
        [HttpGet]
        [Route("customers")]
        public List<Customer> Get()
        {
            return null;
        }

        [HttpGet]
        [Route("customers/{id}")]
        public Customer GetById(Guid id)
        {
            return null;
        }

        [HttpGet]
        [Route("customers/{id}/orders")]
        public List<Order> GetOrders()
        {
            return null;
        }

        [HttpPost]
        [Route("customers")]
        public Customer Post([FromBody]Customer customer)
        {
            return null;
        }

        [HttpPut]
        [Route("customers/{id}")]
        public Customer Put([FromBody] Customer customer)
        {
            return null;
        }

        [HttpDelete]
        [Route("customers/{id}")]
        public string Delete(Guid id)
        {
            return null;
        }
    }
}