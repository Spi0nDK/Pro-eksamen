using Realms;

public class GameModel : RealmObject
{
//i det her script har vi varibler, forskellige datayper og en funktion


    // Her bliver gamemodel lavet, s� spillerens gamertag og scoren gemt.

    [PrimaryKey]
    public string gamerTag { get; set; }

    public int KillScore { get; set; }

    public GameModel() { }

    public GameModel(string gamerTag, int KillScore) // Det her er 
    {
        this.gamerTag = gamerTag; // Det her definere spillerens navn.
        this.KillScore = KillScore; // Det her er spillerens highscore.
    }

}
