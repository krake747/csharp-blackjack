 public class Gambler : Character
{
    public override string Name => "GAMBLER";
    public IPlayer Player { get; }
    public Gambler(IPlayer player)
    {
        Player = player;
    }
}