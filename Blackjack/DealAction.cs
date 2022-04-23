public class DealAction : IAction
{
    public void Run(Round round, Character dealer)
    {
        // First Turn
        round.Gambler.Hand = new Hand(1, round.Deck, isFaceUp: true);
        dealer.Hand = new Hand(1, round.Deck, isFaceUp: true);

        //Second Turn
        round.Gambler.Hand.AddCard(round.Deck, isFaceUp: true);
        dealer.Hand.AddCard(round.Deck, isFaceUp: false);

        Console.WriteLine("Deal round is over.");
    }
}
