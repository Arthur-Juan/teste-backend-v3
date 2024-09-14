using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheatricalPlayersRefactoringKata.Data;
using TheatricalPlayersRefactoringKata.Data.Domain;
using TheatricalPlayersRefactoringKata.Data.Errors;
using TheatricalPlayersRefactoringKata.Data.Model.Input;

namespace TheatricalPlayersRefactoringKata.Application.Services
{
    public class CustomerService
    {
        private readonly AppDbContext _appDbContext;

        public CustomerService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Customer> CreateAsync(CreateCustomerDTO createCustomerDto)
        {
            var customerExists = _appDbContext.Customers.AsNoTracking()
                .Where(c => c.Name == createCustomerDto.name).FirstOrDefault();

            if(customerExists != null)
            {
                throw new Exception(DomainErrors.Customer.CustomerExists);
            }

            //todo -> add mapper
            var customer = new Customer(createCustomerDto.name);
            await _appDbContext.AddAsync(customer);
            await _appDbContext.SaveChangesAsync();
            return customer;
        }
    }
}
