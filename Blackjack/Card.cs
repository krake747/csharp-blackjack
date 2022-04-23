 /// <summary>
/// Represents a Card.
/// </summary>
public class Card
{
    public Suit Suit { get; }
    public Rank Rank { get; }
    public int Score { get; }
    public bool IsFaceUp { get; set; } = false;

    /// <summary>
    /// Constructs a card with the given suit and rank.
    /// </summary>
    public Card(Suit suit, Rank rank)
    { 
        Suit = suit;
        Rank = rank;
        Score = rank.GetScore();
    }
    
    /// <summary>
    /// Flips the card over.
    /// </summary>
    public void FlipOver() => IsFaceUp = !IsFaceUp;

    /// <summary>
    /// Prints a card with the given suit and rank in the console.
    /// </summary>
    public void Print(bool addSpace = false)
    {
        char suitSymbol = !IsFaceUp ? ' ' : Suit.GetSymbol();
        char rankSymbol = !IsFaceUp ? ' ' : Rank.GetSymbol();
        ColoredConsole.Write($"{suitSymbol}{rankSymbol}", this.SuitColor(), this.FaceUpColor());
        if (addSpace) Console.Write(" ");
    }
}

/// <summary>
/// Extension class for the Card class.
/// </summary>
public static class CardExtensions
{
    public static ConsoleColor FaceUpColor(this Card card) => card.IsFaceUp ? ConsoleColor.White : ConsoleColor.DarkBlue;
    public static ConsoleColor SuitColor(this Card card) => card.Suit switch
    {
        Suit.Clubs or Suit.Spades => ConsoleColor.Black,
        Suit.Hearts or Suit.Diamonds => ConsoleColor.Red,
        _ => throw new ArgumentException("No other colors defined!")
    };
}
