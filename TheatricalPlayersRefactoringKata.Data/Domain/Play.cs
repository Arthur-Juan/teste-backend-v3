namespace TheatricalPlayersRefactoringKata.Data.Domain;

public class Play : BaseEntity
{
  
    public string Name { get; private set; }
    public int Lines { get; private set; }
    public string Type { get; private set; }
    public string? Slug { get; private set; }
    public Play()
    {
        
    }
    public Play(string name, int lines, string type, string slug)
    {
        Name = name;
        Lines = lines;
        Type = type;
        Slug = slug;
    }

    public Play(string name, int lines, string type)
    {
        Name = name;
        Lines = lines;
        Type = type;
    }
}
