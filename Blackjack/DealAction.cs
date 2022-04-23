public class DealAction : IAction
{
    public void Run(Round round, Character dealer)
    {
        // First Turn
        round.Gambler.Hand = new Hand(1, round.Deck, faceUp: true);
        dealer.Hand = new Hand(1, round.Deck, faceUp: true);

        //Second Turn
        round.Gambler.Hand.AddCard(round.Deck, faceUp: true);
        dealer.Hand.AddCard(round.Deck, faceUp: false);

        Console.WriteLine("Deal round is over.");
    }
}
