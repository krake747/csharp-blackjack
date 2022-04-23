public abstract class Character
{
    public abstract string Name { get; }
    public Hand Hand { get; set; } = new Hand();
    public bool HasBlackjack => Hand.Score == 21;
    public bool IsBust => Hand.Score > 21;
    public bool IsStand { get; set; } = false;
}

