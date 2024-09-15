using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheatricalPlayersRefactoringKata.Data.Errors.Exceptions.Play;

public class InvalidPlayException : Exception
{
    public InvalidPlayException(string message) : base(message)
    {
        
    }
}
