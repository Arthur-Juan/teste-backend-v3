using System.Collections.Generic;

namespace TheatricalPlayersRefactoringKata.Data.Domain;

public class Invoice : BaseEntity
{

    public Customer Customer { get; private set; }
    public List<Performance> Performances { get; private set; }

    public Invoice()
    {
        
    }

    public Invoice(Customer customer, List<Performance> performance)
    {
        Customer = customer;
        Performances = performance;
    }

}
