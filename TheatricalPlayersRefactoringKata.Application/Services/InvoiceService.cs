using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheatricalPlayersRefactoringKata.Data;
using TheatricalPlayersRefactoringKata.Data.Domain;
using TheatricalPlayersRefactoringKata.Data.Errors;
using TheatricalPlayersRefactoringKata.Data.Errors.Exceptions;
using TheatricalPlayersRefactoringKata.Data.Model.Input;
using TheatricalPlayersRefactoringKata.Data.Model.Output;

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

        customer.AddInvoice(invoice);

        await _appDbContext.SaveChangesAsync();
        return invoice;
    }

    public async Task<List<InvoiceDTO>> GetInvoicesByCustomerAsync(string customer)
    {
        var customerEntity = await _appDbContext.Customers.FirstOrDefaultAsync(x => x.Name == customer);
        if(customerEntity == null)
        {
            throw new InvalidCustomerException(DomainErrors.Customer.CustomerNotFound);
        }

        var invoices = await _appDbContext.Invoices.AsNoTracking()
            .Where(x => x.Customer == customerEntity)
            .Include(x => x.Customer)
            .Include(x => x.Performances)
            .ThenInclude(p => p.Play)
            .ToListAsync();


        var invoicesDto = new List<InvoiceDTO>();

        foreach (var invoice in invoices)
        {
            var performancesDto = new List<PerformanceDTO>();
            foreach (var performance in invoice.Performances) {
                performancesDto.Add(new PerformanceDTO( performance.Id ,performance.Audience, performance.Play.Name, performance.Play.Lines));
                
            }

            invoicesDto.Add(new InvoiceDTO(invoice.Id ,invoice.Customer.Name, performancesDto));
        }

        return invoicesDto;
    }
}
