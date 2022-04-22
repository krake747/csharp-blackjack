public class Hand
{
    private List<Card> _cards;
    public List<Card> Cards => _cards;
    public int CurrentValue => CalculateHandValue();
    public Hand(int startingHand, Deck deck)
    {
        if (deck is null) throw new DeckException("No deck available to draw from!");
        if (deck.Cards.Count == 0) throw new DeckException("No more cards to draw!");

        _cards = new List<Card>();
        for (int i = 0; i < startingHand; i++) deck.DrawTopCard(this);
    }

    public void AddValue(Card card, ref int currentSum)
    {
        currentSum += card.Rank switch
        {
            Rank.Ace => currentSum <= 11 ?  11 :  1,
            Rank.Jack or Rank.Queen or Rank.King => 10,
            _ => (int)card.Rank,
        };
    }

    private int CalculateHandValue()
    {
        int currentSum = 0;
        foreach (Card card in _cards) AddValue(card, ref currentSum);

        return currentSum;
    }
}
