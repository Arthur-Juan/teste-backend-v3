using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheatricalPlayersRefactoringKata.Data.Model.Input
{
    public record CreatePlayDTO(string name, int lines, string type, string slug);
    
   
}
