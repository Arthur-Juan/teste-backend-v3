using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheatricalPlayersRefactoringKata.Data.Domain
{
    public  class Customer : BaseEntity
    {
        public string? Name {  get; private set; }
        public List<Invoice>? Invoices { get; private set; } 


        public void AddInvoice(Invoice invoice)
        {
            if(Invoices == null)
            {
                Invoices = new List<Invoice>();
            }

            Invoices.Add(invoice);
        }

        public Customer(string name)
        {
            Name = name;
        }


        //para EFcore
        public Customer()
        {
            
        }
    }
}
