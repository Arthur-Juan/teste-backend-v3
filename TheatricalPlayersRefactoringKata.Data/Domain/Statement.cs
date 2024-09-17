using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheatricalPlayersRefactoringKata.Data.Domain;

public class Statement : BaseEntity
{
    public Customer? Customer { get; set; }
    public List<Invoice>? Invoices { get; set; }
    public List<PerformanceCost>?  PerformanceCost { get; set; }
    public Decimal? TotalCost { get; set; }

    public Decimal? Credits { get; set; }

    public Decimal? CalculateCost()
    {
        if(PerformanceCost == null)
        {
            return 0;
        }

        return PerformanceCost.Sum(x => x.Cost);
    }

}



public class PerformanceCost : BaseEntity
{
    public Statement? Statement { get; set; }
    public Performance? Performance { get; set; }
    public Decimal? Cost { get; set; }  
}
