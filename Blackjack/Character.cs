public abstract class Character
{
    public abstract string Name { get; }
    public Hand Hand { get; set; } = new Hand();
    public bool HasBlackjack => Hand.Cards.Count == 2 
                                && Hand.Score == 21 
                                && Hand.Cards.Any(c => c.Rank == Rank.Ace) 
                                && Hand.Cards.Any(c => c.Rank.GetScore() == 10);
    public bool HasTwentyOne => Hand.Score == 21;
    public bool HasBust => Hand.Score > 21;
    public bool IsStanding { get; set; } = false;
}

