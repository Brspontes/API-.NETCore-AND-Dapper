using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrsPontes.Domain.StoreContext.Commands.CustomerCommands.Input;
using BrsPontes.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using BrsPontes.Domain.StoreContext.Entities;
using BrsPontes.Domain.StoreContext.Handlers;
using BrsPontes.Domain.StoreContext.Queries;
using BrsPontes.Domain.StoreContext.Repositories;
using BrsPontes.Domain.StoreContext.ValuesObjects;
using BrsPontes.Shared.Commands;
using Microsoft.AspNetCore.Mvc;

namespace BrsPontes.API.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly CustomerHandler _customerHandler;

        public CustomerController(ICustomerRepository customerRepository, CustomerHandler customerHandler)
        {
            _customerRepository = customerRepository;
            _customerHandler = customerHandler;
        }

        [HttpGet]
        [Route("customers")]
        //[ResponseCache] ADICIONAR CACHE PARA DESAFOGAR SERVIDOR EM QUANTIDADES DE REQUISIÇÕES PARA DADOS IMUTAVEIS
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
        public ICommandResult Post([FromBody]CreateCustomerCommand command)
        {
           return (CreateCustomerCommandResult)_customerHandler.Handle(command);
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