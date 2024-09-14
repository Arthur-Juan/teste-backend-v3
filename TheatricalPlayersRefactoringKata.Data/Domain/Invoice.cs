using System.Collections.Generic;

namespace TheatricalPlayersRefactoringKata.Data.Domain;

public class Invoice : BaseEntity
{

    public string Customer { get; private set; }
    public List<Performance> Performances { get; private set; }

    public Invoice()
    {
        
    }

    public Invoice(string customer, List<Performance> performance)
    {
        Customer = customer;
        Performances = performance;
    }

}
