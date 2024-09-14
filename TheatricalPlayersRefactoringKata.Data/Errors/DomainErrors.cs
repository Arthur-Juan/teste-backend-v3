using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheatricalPlayersRefactoringKata.Data.Errors
{
    public static class DomainErrors
    {

        public static class Customer
        {
            public const string CustomerExists = "this customer already exists";
        }
    }
}
