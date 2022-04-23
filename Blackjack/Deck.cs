using System.Runtime.Serialization;

/// <summary>
/// Represents a Deck of Ccards.
/// </summary>
public class Deck
{
    private readonly Random _random = new Random();
    private List<Card> _cards = new List<Card>();
    public List<Card> Cards => _cards;
    /// <summary>
    /// Gets whether the deck is empty
    /// </summary>
    public bool Empty => _cards.Count == 0;

    /// <summary>
    /// Constructs a Deck with with 52 cards.
    /// </summary>
    public Deck() 
    {
        foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                _cards.Add(new Card(suit, rank));
    }

    /// <summary>
    /// Cuts the deck of cards at the given location
    /// </summary>
    /// <param name="location">the location at which to cut the deck</param>
    public void Cut(int location)
    {
        int cutIndex = _cards.Count - location;
        Card[] newCards = new Card[_cards.Count];
        _cards.CopyTo(cutIndex, newCards, 0, location);
        _cards.CopyTo(0, newCards, location, cutIndex);
        _cards.Clear();
        _cards.InsertRange(0, newCards);
    }

    /// <summary>
    /// Shuffles the deck. This implementation traverses the list backwards, from the last element up to the second,
    /// repeatedly swapping a randomly selected element into the "current position".
    /// Elements are randomly selected from the portion of the list that runs from the first element to the current position, inclusive.
    /// </summary>
    public void Shuffle()
    {
        for (int i = _cards.Count - 1; i > 0; i--)
        {
            int randomIndex = _random.Next(i + 1);
            Card tempCard = _cards[i];
            _cards[i] = _cards[randomIndex];
            _cards[randomIndex] = tempCard;
        }
    }

    /// <summary>
    /// Draw the top card from the deck. If the deck is empty, returns null
    /// </summary>
    /// <returns>the top card</returns>
    public Card? DrawTopCard()
    {
        if (!Empty)
        {
            Card topCard = _cards[_cards.Count - 1];
            _cards.RemoveAt(_cards.Count - 1);
            return topCard;
        }
        else
            return null;
    }

    /// <summary>
    /// Draw the top card from the deck and add to hand. If the deck is empty, returns null.
    /// </summary>
    /// <returns>the top card</returns>
    public Card? DrawTopCard(Hand hand, bool faceUp = false)
    {
        if (!Empty)
        {
            Card topCard = _cards[_cards.Count - 1];
            if (faceUp == true) topCard.FlipOver();
            _cards.RemoveAt(_cards.Count - 1);
            hand.Cards.Add(topCard);
            return topCard;
        }
        else
            return null;
    }

    /// <summary>
    /// Prints the contents of the deck.
    /// </summary>
    public void Print() => _cards.ForEach(c => Console.WriteLine($"{c.Rank} of {c.Suit}"));
}

[Serializable]
internal class DeckException : Exception 
{
    public DeckException() { }    
    public DeckException(string message) : base(message) { }
    public DeckException(string message, Exception innerException) : base(message, innerException) { }
    protected DeckException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}