namespace TheatricalPlayersRefactoringKata.Data.Domain;

public class Performance : BaseEntity
{
    private string _playId;
    private int _audience;

    public string PlayId { get => _playId; set => _playId = value; }
    public int Audience { get => _audience; set => _audience = value; }

    public Performance()
    {
        
    }

    public Performance(string playID, int audience)
    {
        this._playId = playID;
        this._audience = audience;
    }

}
