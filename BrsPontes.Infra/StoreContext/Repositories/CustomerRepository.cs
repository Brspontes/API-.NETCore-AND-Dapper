using BrsPontes.Domain.StoreContext.Entities;
using BrsPontes.Domain.StoreContext.Repositories;
using BrsPontes.Infra.StoreContext.DataContext;
using Dapper;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrsPontes.Domain.StoreContext.Queries;

namespace BrsPontes.Infra.StoreContext.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public readonly SQLDataContext _context;

        public CustomerRepository(SQLDataContext context)
        {
            _context = context;
        }

        public bool CheckDocument(string document)
        {
            return _context.Connection.Query<bool>("spCheckDocument",
                new { Document = document },
                commandType: CommandType.StoredProcedure).FirstOrDefault();
        }

        public bool CheckEmail(string email)
        {
            return _context.Connection.Query<bool>("spCheckEmail",
                 new { Email = email },
                 commandType: CommandType.StoredProcedure).FirstOrDefault();
        }

        public IEnumerable<ListCustomerQueryResult> Get()
        {
            return _context.Connection.Query<ListCustomerQueryResult>(
                "SELECT [Id], CONCAT([FirstName], ' ', [LastName]) AS NAME, [Document], [Email] FROM [Customer]", new { }
                 ).ToList();
        }

        public GetCustomerQueryResult Get(Guid Id)
        {
            return _context.Connection.Query<GetCustomerQueryResult>(
               "SELECT [Id], CONCAT([FirstName], ' ', [LastName]) AS NAME, [Document], [Email] FROM [Customer]" +
               "WHERE [Id] = @Id", new { Id = Id }
                ).FirstOrDefault();
        }

        public CustomerOrdersCountResult GetCustomerOrdersCountResult(string document)
        {
            return _context.Connection.Query<CustomerOrdersCountResult>("spGetCustomerOrdersCount",
                new { Document = document },
                commandType: CommandType.StoredProcedure).FirstOrDefault();
        }

        public IEnumerable<ListCustomerOrderResult> GetOrders(Guid Id)
        {
            return _context.Connection.Query<ListCustomerOrderResult>(
                 "SELECT [Id], CONCAT([FirstName], ' ', [LastName]) AS NAME, [Document], [Email] FROM [Customer]", new { }
                  ).ToList();
        }

        public void Save(Customer customer)
        {
            _context.Connection.Execute("spCreateCustomer",
                new
                {
                    Id = customer.Id,
                    FirstName = customer.Name.FirstName,
                    LastName = customer.Name.LastName,
                    Document = customer.Document.Number,
                    Email = customer.Email.Address,
                    Phone = customer.Phone
                }, commandType: CommandType.StoredProcedure);

            foreach (var address in customer.Addresses)
            {
                _context.Connection.Execute("spCreateAddress",
                    new
                    {
                        Id = address.Id,
                        CustomerId = customer.Id,
                        Number = address.Number,
                        Complement = address.Complement,
                        District = address.District,
                        City = address.City,
                        State = address.State,
                        Country = address.Country,
                        ZipCode = address.ZipCode,
                        Type = address.Type
                    }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
