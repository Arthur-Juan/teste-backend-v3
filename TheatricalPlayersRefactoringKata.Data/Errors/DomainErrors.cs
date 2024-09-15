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
            public const string CustomerNotFound = "customer not found";
        }

        public static class Play
        {
            public const string PlayExists = "this play already exists";
            public const string PlayNotFound = "play not found";

        }

        public static class Genre
        {
            public const string InvalidGenre = "Invalid Genre";
        }
    }
}
