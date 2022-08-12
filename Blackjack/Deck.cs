using System.Runtime.Serialization;

/// <summary>
/// Represents a Deck of Ccards.
/// </summary>
public class Deck
{
    private readonly Random _random = new Random();
    public Stack<Card> Cards { get; set; } = new Stack<Card>();
    public int Count => Cards.Count;
    public bool IsEmpty => Cards.Count == 0;

    /// <summary>
    /// Constructs a Deck with 52 face down cards.
    /// </summary>
    public Deck() 
    {
        List<Card> cards = new List<Card>();
        foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                cards.Add(new Card(suit, rank));

        Initialize(cards);
    }

    /// <summary>
    /// Shuffles the deck. This implementation traverses the list backwards, from the last element up to the second,
    /// repeatedly swapping a randomly selected element into the "current position".
    /// Elements are randomly selected from the portion of the list that runs from the first element to the current position, inclusive.
    /// </summary>
    public void Shuffle()
    {
        List<Card> cards = Cards.ToList();
        for (int i = Cards.Count - 1; i > 0; i--)
        {
            int randomIndex = _random.Next(i + 1);
            Card tempCard = cards[i];
            cards[i] = cards[randomIndex];
            cards[randomIndex] = tempCard;
        }

        Initialize(cards);
    }
    /// <summary>
    /// Add card face down to the deck.
    /// </summary>
    /// <param name="card"></param>
    public void Add(Card card) 
    {
        if (card.IsFaceUp) card.FlipOver();
        Cards.Push(card);
    }
    /// <summary>
    /// Peek the top card from the deck. If the deck is empty, returns null
    /// </summary>
    /// <param name="isFaceUp"></param>
    /// <returns>the top card</returns>
    public Card? Peek(bool isFaceUp = true)
    {
        if (IsEmpty) return null;

        Card topCard = Cards.Peek();
        if (isFaceUp && !topCard.IsFaceUp) topCard.FlipOver();
        return topCard;
    }

    /// <summary>
    /// Draw the top card from the deck. If the deck is empty, returns null
    /// </summary>
    /// <param name="isFaceUp"></param>
    /// <returns>the top card</returns>
    public Card? Draw(bool isFaceUp = false)
    {
        if (IsEmpty) return null;

        Card topCard = Cards.Pop();
        if (isFaceUp && !topCard.IsFaceUp) topCard.FlipOver();
        return topCard;
    }

    /// <summary>
    /// Prints the contents of the deck.
    /// </summary>
    public void Print() => Cards.ToList().ForEach(c => Console.WriteLine($"{c.Rank} of {c.Suit}"));

    /// <summary>
    /// Pushes all cards into the deck face down.
    /// </summary>
    /// <param name="cards"></param>
    private void Initialize(List<Card> cards)
    {
        Cards.Clear();
        cards.FindAll(c => c.IsFaceUp).ForEach(c => c.IsFaceUp = false);
        for (int i = 0; i < cards.Count; i++) Cards.Push(cards[i]);
    }
}

[Serializable]
internal class DeckException : Exception 
{
    public DeckException() { }    
    public DeckException(string message) : base(message) { }
    public DeckException(string message, Exception innerException) : base(message, innerException) { }
    protected DeckException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
