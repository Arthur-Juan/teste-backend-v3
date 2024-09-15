using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheatricalPlayersRefactoringKata.Data;
using TheatricalPlayersRefactoringKata.Data.Domain;
using TheatricalPlayersRefactoringKata.Data.Errors;
using TheatricalPlayersRefactoringKata.Data.Errors.Exceptions;
using TheatricalPlayersRefactoringKata.Data.Model.Input;

namespace TheatricalPlayersRefactoringKata.Application.Services;

public class InvoiceService
{
    private readonly AppDbContext _appDbContext;

    public InvoiceService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<Invoice> Create(CreateInvoiceDTO createInvoice)
    {
        var customer = await _appDbContext.Customers.Where(x => x.Name == createInvoice.customer).FirstOrDefaultAsync();
        
        //customer
        if(customer == null)
        {
            throw new InvalidCustomerException(DomainErrors.Customer.CustomerNotFound);
        }

        var performances = new List<Performance>();
        foreach(var performance in createInvoice.performances)
        {
            var play = await _appDbContext.Plays.FirstOrDefaultAsync(x => x.Slug == performance.playSlug);
            if(play == null)
            {
                throw new Exception("Play not found");
            }

            performances.Add(new Performance(play, performance.audience));
        }

        var invoice = new Invoice(customer, performances);
        await _appDbContext.Invoices.AddAsync(invoice);

        customer.Invoices?.Add(invoice);

        await _appDbContext.SaveChangesAsync();
        return invoice;
    }
}
