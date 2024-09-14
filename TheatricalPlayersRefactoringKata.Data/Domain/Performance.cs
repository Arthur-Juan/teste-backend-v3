namespace TheatricalPlayersRefactoringKata.Data.Domain;

public class Performance : BaseEntity
{

    public Play Play { get; private set; }
    public int Audience { get; private set; }
    public string PlayId { get; set; }
    public Performance()
    {
        
    }

    public Performance(Play play, int audience)
    {
        Play = play;
        Audience = audience;
    }

    public Performance(string play, int audience)
    {
        PlayId = play;
        Audience = audience;
    }


}
