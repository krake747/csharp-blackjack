public class Hand
{
    private List<Card> _cards;
    public List<Card> Cards => _cards;
    public int CardCount => _cards.Count;
    public int Score => CalculateScore(true);
    public int HiddenScore => CalculateScore(false);
    public bool AllFaceUp => _cards.All(c => c.FaceUp);

    public Hand() { _cards = new List<Card>(); }
    public Hand(int startingHand, Deck deck, bool faceUp = false)
    {
        if (deck is null) throw new DeckException("No deck available to draw from!");
        if (deck.Cards.Count == 0) throw new DeckException("No more cards to draw!");

        _cards = new List<Card>();
        for (int i = 0; i < startingHand; i++) deck.DrawTopCard(this, faceUp);
    }

    public void AddCard(Deck deck, bool faceUp = false) => deck.DrawTopCard(this, faceUp);

    public void AddSpecificCard(Card card) => _cards.Add(card);

    public void Print()
    {
        foreach (Card card in _cards) card.Print(true);
        Console.WriteLine($"({this.Score})");
    }
    
    private int CalculateScore(bool faceUp = false)
    {
        // Caculate hidden score or score of face up cards.
        var cards = faceUp ? _cards.Where(c => c.FaceUp).ToList() : _cards;
        
        // Total Score
        int totalScore = cards.Sum(c => c.Score);

        // Has 21.
        if (totalScore <= 21) return totalScore;

        // Has no Aces and has bust.
        bool hasAces = cards.Any(c => c.Rank == Rank.Ace);
        if (!hasAces && totalScore > 21) return totalScore;

        // Has Aces 
        int acesCount = cards.Count(c => c.Rank == Rank.Ace);
        int acesScore = cards.Sum(x => x.Score);

        while (acesCount > 0)
        {
            acesCount--;
            acesScore -= 10;
            
            if (acesScore <= 21) return acesScore;
        }

        // has bust.
        return cards.Sum(x => x.Score);
    }
}
