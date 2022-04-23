public class Dealer : Character
{
    public override string Name => "DEALER";
    public IPlayer Player { get; }
    public Dealer(IPlayer player) => Player = player;
}

