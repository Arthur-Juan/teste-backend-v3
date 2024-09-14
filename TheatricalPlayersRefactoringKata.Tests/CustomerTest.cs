using ApprovalTests.Namers;
using Bogus;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheatricalPlayersRefactoringKata.Application.Services;
using TheatricalPlayersRefactoringKata.Data.Errors;
using TheatricalPlayersRefactoringKata.Data.Errors.Exceptions;
using TheatricalPlayersRefactoringKata.Data.Model.Input;
using Xunit;

namespace TheatricalPlayersRefactoringKata.Tests
{

    public class CustomerTest
    {
        private readonly CustomerService _customerService;

        public CustomerTest()
        {
            var serviceProvider = TestServiceProvider.CreateServiceProvider();
            _customerService = serviceProvider.GetRequiredService<CustomerService>();
        }
        private CreateCustomerDTO CreateRandomCustomer()
        {
            var faker = new Faker<CreateCustomerDTO>()
                .CustomInstantiator(f => new CreateCustomerDTO(f.Lorem.Word()));

            return faker.Generate();
        }

        [Fact]
        public async Task TestShouldReturnUserAfterCreate()
        {
            var customer = CreateRandomCustomer();
            var result = await _customerService.CreateAsync(customer);

            Assert.NotNull(result);
            Assert.Equal(result.Name, customer.name);
        }

      

        [Fact]
        public async Task TestShouldNotCreateMoreThanOneCustomerWithTheSameName()
        {
            var customer = CreateRandomCustomer();

            await _customerService.CreateAsync(customer);

            var exception = await Assert.ThrowsAsync<InvalidCustomerException>(async () =>
            {
                await _customerService.CreateAsync(customer);
            });

            Assert.Contains(DomainErrors.Customer.CustomerExists, exception.Message);
        }
    }
}
