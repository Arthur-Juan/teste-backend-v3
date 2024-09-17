using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheatricalPlayersRefactoringKata.Data.Domain;

public class Genre : BaseEntity
{
    public string? Name { get; set; }

    public Genre(string name)
    {
        Name = name;
    }

}
