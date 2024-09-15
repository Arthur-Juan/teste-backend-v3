using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheatricalPlayersRefactoringKata.Data.Domain;

namespace TheatricalPlayersRefactoringKata.Data.Model.Input
{
    public record CreateInvoiceDTO(string customer, List<CreatePerformanceDTO> performances);
}
