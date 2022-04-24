public class DealAction : IAction
{
    public void Run(Round round, Character dealer)
    {
        // First Turn
        List<Character> gamblers = round.GetOppositeParty(dealer).Characters;
        foreach (Character gambler in gamblers) gambler.Hand = new Hand(1, round.Deck, isFaceUp: true);
        dealer.Hand = new Hand(1, round.Deck, isFaceUp: true);

        //Second Turn
        foreach (Character gambler in gamblers) gambler.Hand.AddCard(round.Deck, isFaceUp: true);
        dealer.Hand.AddCard(round.Deck, isFaceUp: false);

        Console.WriteLine("Deal round is over.");
        Console.WriteLine();
    }
}
