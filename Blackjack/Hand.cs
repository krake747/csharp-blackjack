/// <summary>
/// Represents a character's hand.
/// </summary>
public class Hand
{
    private List<Card> _cards = new List<Card>();
    public List<Card> Cards => _cards;
    public int Score => CalculateScore(true);
    public int HiddenScore => CalculateScore();
    public bool AllFaceUp => _cards.All(c => c.IsFaceUp);
    public bool TwoCardsInHand => _cards.Count == 2;
    public bool AceAndTwo => _cards.Any(c => c.Rank == Rank.Ace) && _cards.Any(c => c.Score == 2) && TwoCardsInHand;
    public bool AceAndThree => _cards.Any(c => c.Rank == Rank.Ace) && _cards.Any(c => c.Score == 3) && TwoCardsInHand;
    public bool AceAndFour => _cards.Any(c => c.Rank == Rank.Ace) && _cards.Any(c => c.Score == 4) && TwoCardsInHand;
    public bool AceAndFive => _cards.Any(c => c.Rank == Rank.Ace) && _cards.Any(c => c.Score == 5) && TwoCardsInHand;
    public bool AceAndSix => _cards.Any(c => c.Rank == Rank.Ace) && _cards.Any(c => c.Score == 6) && TwoCardsInHand;
    public bool AceAndSeven => _cards.Any(c => c.Rank == Rank.Ace) && _cards.Any(c => c.Score == 7) && TwoCardsInHand;
    public bool AceAndEight => _cards.Any(c => c.Rank == Rank.Ace) && _cards.Any(c => c.Score == 8) && TwoCardsInHand;
    public bool IsPair => TwoCardsInHand ? _cards[0].Rank == _cards[1].Rank : false;
    public bool Twos => AllCardsEqualScore(2) && TwoCardsInHand;
    public bool Threes => AllCardsEqualScore(3) && TwoCardsInHand;
    public bool Fours => AllCardsEqualScore(4) && TwoCardsInHand;
    public bool Fives => AllCardsEqualScore(5) && TwoCardsInHand;
    public bool Sixes => AllCardsEqualScore(6) && TwoCardsInHand;
    public bool Sevens => AllCardsEqualScore(7) && TwoCardsInHand;
    public bool Eights => AllCardsEqualScore(8) && TwoCardsInHand;
    public bool Nines => AllCardsEqualScore(9) && TwoCardsInHand;
    public bool Tens => AllCardsEqualScore(10) && TwoCardsInHand;
    public bool Aces => _cards.All(c => c.Rank == Rank.Ace) && TwoCardsInHand;


    /// <summary>
    /// Constructs an empty hand.
    /// </summary>
    public Hand() { }

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

        for (int i = 0; i < startingHand; i++) AddCard(deck, isFaceUp);
    }
    
    /// <summary>
    /// Add a single card to hand.
    /// </summary>
    /// <param name="card"></param>
    public void AddCard(Card card) => _cards.Add(card);

    /// <summary>
    /// Draw a card from a deck and add to hand.
    /// </summary>
    /// <param name="deck"></param>
    /// <param name="isFaceUp"></param>
    /// <exception cref="DeckException"></exception>
    public void AddCard(Deck deck, bool isFaceUp = false) => _cards.Add(deck.Draw(isFaceUp) ?? throw new DeckException("No more cards to draw!"));

    /// <summary>
    /// Reveals all face down cards in hand.
    /// </summary>
    public void Reveal()
    {
        foreach (Card card in Cards) if (!card.IsFaceUp) card.FlipOver();
    }

    private bool AllCardsEqualScore(int score) => _cards.All(c => c.Score == score);
    
    /// <summary>
    /// Calculates the total score of all face up cards in hand.  
    /// </summary>
    /// <param name="isFaceUp"></param>
    /// <returns></returns>
    private int CalculateScore(bool isFaceUp = false)
    {
        // Caculate hidden score or score of face up cards.
        var cards = isFaceUp ? _cards.Where(c => c.IsFaceUp).ToList() : _cards;
        
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
