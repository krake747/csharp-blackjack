/// <summary>
/// Represents a Card.
/// </summary>
public class Card
{
    public Suit Suit { get; }
    public Rank Rank { get; }
    public int Score { get; }
    public bool FaceUp { get; set; } = false;

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
    public void FlipOver() => FaceUp = !FaceUp;

    /// <summary>
    /// Prints a card with the given suit and rank in the console.
    /// </summary>
    public void Print(bool addSpace = false)
    {
        char suitSymbol = !FaceUp ? ' ' : Suit.GetSymbol();
        char rankSymbol = !FaceUp ? ' ' : Rank.GetSymbol();
        ColoredConsole.Write($"{suitSymbol}{rankSymbol}", this.SuitColor(), this.FaceUpColor());
        if (addSpace) Console.Write(" ");
    }


}

/// <summary>
/// Extension class for the Card class.
/// </summary>
public static class CardExtensions
{
    public static ConsoleColor FaceUpColor(this Card card) => card.FaceUp == true ? ConsoleColor.White : ConsoleColor.DarkBlue;
    public static ConsoleColor SuitColor(this Card card) => card switch
    {
        { Suit: Suit.Clubs or Suit.Spades } => ConsoleColor.Black,
        { Suit: Suit.Hearts or Suit.Diamonds } => ConsoleColor.Red,
        _ => throw new ArgumentException("No other colors defined!")
    };
}
