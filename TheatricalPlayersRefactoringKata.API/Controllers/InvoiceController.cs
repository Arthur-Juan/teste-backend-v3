using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using TheatricalPlayersRefactoringKata.Application.Services;
using TheatricalPlayersRefactoringKata.Data.Domain;
using TheatricalPlayersRefactoringKata.Data.Model.Input;

namespace TheatricalPlayersRefactoringKata.API.Controllers
{
    [Route("api/invoice")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly StatementPrinterService _statementPrinterService;
        private readonly InvoiceService _invoiceService;
        public InvoiceController(StatementPrinterService statementPrinterService, InvoiceService invoiceService)
        {
            _statementPrinterService = statementPrinterService;
            _invoiceService = invoiceService;
        }

       

        [HttpPost("create")]
        public async Task<IActionResult> CreateInvoice(CreateInvoiceDTO data)
        {
            await _invoiceService.Create(data);
            return NoContent();
        }

        [HttpGet("{customer}")]
        public async Task<IActionResult> GetInvoicesByClient(string customer)
        {
            if (string.IsNullOrWhiteSpace(customer))
            {
                return BadRequest("customer is required");
            }

            var result = await _invoiceService.GetInvoicesByCustomerAsync(customer);
            return Ok(result);
        }

    }
}
