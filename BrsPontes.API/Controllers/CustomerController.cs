using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrsPontes.Domain.StoreContext.Entities;
using BrsPontes.Domain.StoreContext.Queries;
using BrsPontes.Domain.StoreContext.Repositories;
using BrsPontes.Domain.StoreContext.ValuesObjects;
using Microsoft.AspNetCore.Mvc;

namespace BrsPontes.API.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        [Route("customers")]
        public IEnumerable<ListCustomerQueryResult> Get()
        {
            return _customerRepository.Get();
        }

        [HttpGet]
        [Route("customers/{id}")]
        public GetCustomerQueryResult GetById(Guid id)
        {
            return _customerRepository.Get(id);
        }

        [HttpGet]
        [Route("customers/{id}/orders")]
        public IEnumerable<ListCustomerOrderResult> GetOrders(Guid Id)
        {
            return _customerRepository.GetOrders(Id);
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