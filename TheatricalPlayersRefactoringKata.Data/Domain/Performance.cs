namespace TheatricalPlayersRefactoringKata.Data.Domain;

public class Performance : BaseEntity
{

    public string PlayId { get; private set; }
    public int Audience { get; private set; }

    public Performance()
    {
        
    }

    public Performance(string playID, int audience)
    {
        PlayId = playID;
        Audience = audience;
    }

}
