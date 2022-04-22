/// <summary>
/// An enumeration for card suits.
/// </summary>
public enum Suit
{
    Clubs = 1,
    Spades = 2,
    Hearts = 3,
    Diamonds = 4
}

public static class SuitExtensions
{
    public static char GetSymbol(this Suit suit)
    {
        return suit switch
        {
            Suit.Clubs => '\u2663',
            Suit.Spades => '\u2660',
            Suit.Hearts => '\u2665',
            Suit.Diamonds => '\u2666',
            _ =>throw new ArgumentException("Suit is not defined!")
        };
    }
}