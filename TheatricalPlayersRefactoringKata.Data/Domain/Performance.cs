namespace TheatricalPlayersRefactoringKata.Data.Domain;

public class Performance : BaseEntity
{

    public Play Play { get; private set; }
    public int Audience { get; private set; }

    public Performance()
    {
        
    }

    public Performance(Play play, int audience)
    {
        Play = play;
        Audience = audience;
    }

}
