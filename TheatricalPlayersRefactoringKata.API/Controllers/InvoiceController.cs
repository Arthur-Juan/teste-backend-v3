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

        public InvoiceController(StatementPrinterService statementPrinterService)
        {
            _statementPrinterService = statementPrinterService;
        }

        [HttpPost]
        public IActionResult PrintStatment(CreateInvoiceDTO data)
        {

            var performances = new List<Performance>();
            foreach(var perf in data.createPerformanceDTO)
            {
                performances.Add(new Performance(perf.playId, perf.audience));
            }

            var invoice= new Invoice(data.customer, performances);

            var result = _statementPrinterService.Print(invoice, data.plays);

            return Ok(result);
        }

    }
}
