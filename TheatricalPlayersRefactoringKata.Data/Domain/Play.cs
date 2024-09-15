
using TheatricalPlayersRefactoringKata.Data.Enums;
using TheatricalPlayersRefactoringKata.Data.Errors;
using TheatricalPlayersRefactoringKata.Data.Errors.Exceptions.Genre;

namespace TheatricalPlayersRefactoringKata.Data.Domain;

public class Play : BaseEntity
{
  
    public string Name { get; private set; }
    public int Lines { get; private set; }
    public string Type { get; private set; }
    public GenreEnum Genre { get; private set; }

    public string? Slug { get; private set; }

    public Play()
    {
        
    }


    public void SetGenre(string type)
    {
        GenreEnum genre;
        if (Enum.TryParse<GenreEnum>(type, out genre))
        {
            Genre = genre;
        }
        else
        {
            throw new InvalidGenreException(DomainErrors.Genre.InvalidGenre);
        }

    }

    public Play(string name, int lines, string type, string slug)
    {
        Name = name;
        Lines = lines;
        SetGenre(type);
        Type = type;
        Slug = slug;
    }

    public Play(string name, int lines, string type)
    {
        Name = name;
        Lines = lines;
        Type = type;
        SetGenre(type);
    }
}
