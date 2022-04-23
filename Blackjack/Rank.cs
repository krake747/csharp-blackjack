/// <summary>
/// An enumeration for card ranks.
/// </summary>
public enum Rank
{
    Ace = 1,
    Two = 2,
    Three = 3,
    Four = 4,
    Five = 5,
    Six = 6,
    Seven = 7,
    Eight = 8,
    Nine = 9,
    Ten = 10,
    Jack = 11,
    Queen = 12,
    King = 13,
}

/// <summary>
/// Extension class for Enum Rank.
/// </summary>
public static class RankExtensions
{
    public static char GetSymbol(this Rank rank) => rank switch
    {
        Rank.Ace => 'A',
        Rank.Two => '2',
        Rank.Three => '3',
        Rank.Four => '4',
        Rank.Five => '5',
        Rank.Six => '6',
        Rank.Seven => '7',
        Rank.Eight => '8',
        Rank.Nine => '9',
        Rank.Ten => 'T',
        Rank.Jack => 'J',
        Rank.Queen => 'Q',
        Rank.King => 'K',
        _ => throw new ArgumentException("Rank is not defined!")
    };

    public static int GetScore(this Rank rank) => rank switch
    {
        Rank.Ace => 11,
        Rank.Jack or Rank.Queen or Rank.King => 10,
        _ => (int)rank,
    };
}