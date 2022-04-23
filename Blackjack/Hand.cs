/// <summary>
/// Represents a character's hand.
/// </summary>
public class Hand
{
    private List<Card> _cards;
    public List<Card> Cards => _cards;
    public int Score => CalculateScore(true);
    public int HiddenScore => CalculateScore();
    public bool AllFaceUp => _cards.All(c => c.IsFaceUp);

    /// <summary>
    /// Constructs an empty hand.
    /// </summary>
    public Hand()
    {
        _cards = new List<Card>();
    }

    /// <summary>
    /// Constructs a starting hand from a given deck.
    /// </summary>
    /// <param name="startingHand"></param>
    /// <param name="deck"></param>
    /// <param name="IsFaceUp"></param>
    /// <exception cref="DeckException"></exception>
    public Hand(int startingHand, Deck deck, bool isFaceUp = false)
    {
        if (deck is null) throw new DeckException("No deck available to draw from!");
        if (deck.Cards.Count == 0) throw new DeckException("No more cards to draw!");

        _cards = new List<Card>();
        for (int i = 0; i < startingHand; i++) deck.DrawTopCard(this, isFaceUp);
    }

    public void AddCard(Deck deck, bool isFaceUp = false) => deck.DrawTopCard(this, isFaceUp);

    public void AddSpecificCard(Card card) => _cards.Add(card);

    /// <summary>
    /// Prints the cards in hand to the console window.
    /// </summary>
    public void Print()
    {
        foreach (Card card in _cards) card.Print(true);
        Console.WriteLine($"({this.Score})");
    }
    
    /// <summary>
    /// Calculates the total score of all face up cards in hand.  
    /// </summary>
    /// <param name="IsFaceUp"></param>
    /// <returns></returns>
    private int CalculateScore(bool IsFaceUp = false)
    {
        // Caculate hidden score or score of face up cards.
        var cards = IsFaceUp ? _cards.Where(c => c.IsFaceUp).ToList() : _cards;
        
        // Total Score
        int totalScore = cards.Sum(c => c.Score);

        // Total score is 21 or less.
        if (totalScore <= 21) return totalScore;

        // Has no Aces and has bust.
        bool hasAces = cards.Any(c => c.Rank == Rank.Ace);
        if (!hasAces && totalScore > 21) return totalScore;

        // Has Aces 
        int acesCount = cards.Count(c => c.Rank == Rank.Ace);
        int acesScore = cards.Sum(c => c.Score);

        while (acesCount > 0)
        {
            acesCount--;
            acesScore -= 10;
            
            if (acesScore <= 21) return acesScore;
        }

        // Has bust.
        return totalScore;
    }
}
