/// <summary>
/// Represents a Card.
/// </summary>
public class Card
{
    public Suit Suit { get; }
    public Rank Rank { get; }
    public bool FaceUp { get; set; } = false;

    /// <summary>
    /// Constructs a card with the given suit and rank.
    /// </summary>
    public Card(Suit suit, Rank rank)
    { 
        Suit = suit;
        Rank = rank;
    }
    
    /// <summary>
    /// Flips the card over.
    /// </summary>
    public void FlipOver() => FaceUp = !FaceUp;

    /// <summary>
    /// Prints a card with the given suit and rank in the console.
    /// </summary>
    public void Print() => ColoredConsole.WriteLine($"{Suit.GetSymbol()}{Rank.GetSymbol()}", this.SuitColor(), this.FaceUpColor());
}

public static class CardExtensions
{
    public static ConsoleColor SuitColor(this Card card) => card switch
    {
        { Suit: Suit.Clubs, FaceUp: true } => ConsoleColor.Black,
        { Suit: Suit.Spades, FaceUp: true } => ConsoleColor.Black,
        { Suit: Suit.Hearts, FaceUp: true } => ConsoleColor.Red,
        { Suit: Suit.Diamonds, FaceUp: true } => ConsoleColor.Red,
        _ => throw new ArgumentOutOfRangeException("No other call can be defined!")
    };

    public static ConsoleColor FaceUpColor(this Card card) => card.FaceUp == true ? ConsoleColor.White : ConsoleColor.Blue;
}
