public class Round
{
    public Dealer Dealer { get; }
    public Gambler Gambler { get; }
    public Deck Deck { get; } = new Deck();

    public Round(Dealer dealer, Gambler gambler)
    { 
        Dealer = dealer;
        Gambler = gambler;
        Deck.Shuffle();
    }

    public void Run() 
    {      
        // Dealer deals cards to Gambler and himself.
        Dealer.Player.ChooseAction(this, Dealer).Run(this, Dealer);
        RoundRenderer.RenderDealRound(this);

        // Run rounds until the final outcome is known.
        while (!IsOver)
        {
            // Run Gambler round until all gamblers stand, are bust or have Blackjack.
            while (!IsGamblerOver)
            {
                // For each Gambler on the table do action.
                foreach (Gambler gambler in new List<Gambler> { Gambler })
                {
                    Console.WriteLine(); // Slight separation gap.

                    // Display who's turn it is.
                    Console.WriteLine($"{gambler.Name} is taking a turn...");

                    // Have the player in charge pick an action for the character, and then run that action.
                    gambler.Player.ChooseAction(this, gambler).Run(this, gambler);

                    RoundRenderer.Render(this, (Character)gambler);

                    if (IsGamblerOver) break;
                }
            } 
            
            // Dealer reveals hidden card.
            Dealer.Player.ChooseAction(this, Dealer).Run(this, Dealer);
            RoundRenderer.Render(this, (Character)Dealer);

            if (Dealer.IsBust || Dealer.IsStand) break;
            if (!Dealer.IsBust && Gambler.IsBust) break;
            if (Gambler.HasBlackjack && !Dealer.HasBlackjack) break;
            if (!Dealer.IsBust && IsGamblerOver && Dealer.Hand.Score > Gambler.Hand.Score) break;
        }

        Console.WriteLine($"Round is over!");
        if (Dealer.IsBust) ColoredConsole.WriteLine($"Gambler wins!", ConsoleColor.Green);
        else if (Dealer.Hand.Score > Gambler.Hand.Score && !Dealer.IsBust) ColoredConsole.WriteLine($"House wins!", ConsoleColor.Red);
        else if  (Gambler.IsBust) ColoredConsole.WriteLine($"House wins!", ConsoleColor.Red);
        else if (Dealer.Hand.Score < Gambler.Hand.Score && !Gambler.IsBust) ColoredConsole.WriteLine($"Gambler wins!", ConsoleColor.Green);
        else ColoredConsole.WriteLine($"No one wins!", ConsoleColor.Yellow);
    }

    public bool IsOver => Dealer.IsBust || Dealer.HasBlackjack;    
    public bool IsGamblerOver => Gambler.IsBust || Gambler.IsStand || Gambler.HasBlackjack;    
}