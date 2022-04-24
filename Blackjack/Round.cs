public class Round
{
    public Party Casino { get; }
    public Character Dealer { get; }
    public Party Gamblers { get; }
    public Character Gambler { get; set; }
    public Deck Deck { get; } = new Deck();

    public Round(Party casino, Party gamblers)
    {
        Casino = casino;
        Gamblers = gamblers;
        Deck.Shuffle();
        Dealer = Casino.Characters[0];
        Gambler = Gamblers.Characters[0];
    }
    public void Run() 
    {
        // Dealer deals cards to all gambler and himself.
        Casino.Player.ChooseAction(this, Dealer).Run(this, Dealer);
        RoundRenderer.Render(this, Dealer);

        // Run rounds until the final outcome is known.
        while (!IsOver)
        {
            // Run Gambler round until all gamblers stand, are bust or have Blackjack.
            while (!IsGamblersRoundOver)
            {
                // For each Gambler on the table do action.
                foreach (Character gambler in Gamblers.Characters)
                {
                    // Display who's turn it is.
                    Console.WriteLine($"{gambler.Name} is taking a turn...");

                    // Have the player in charge pick an action for the character, and then run that action.
                    Gamblers.Player.ChooseAction(this, gambler).Run(this, gambler);

                    Console.WriteLine();

                    RoundRenderer.Render(this, gambler);

                    if (IsGamblersRoundOver) break;
                }
            }

            // Dealer reveals hidden card.
            Casino.Player.ChooseAction(this, Dealer).Run(this, Dealer);
            Console.WriteLine();
            RoundRenderer.Render(this, (Character)Dealer);
            

            if (Dealer.HasBust || Dealer.IsStanding) break;
            if (!Dealer.HasBust && Gambler.HasBust) break;
            if (Gambler.HasBlackjack && !Dealer.HasBlackjack) break;
            if (!Dealer.HasBust && IsGamblersRoundOver && Dealer.Hand.Score > Gambler.Hand.Score) break;
        }

        Console.WriteLine($"Round is over!");
        if (Dealer.HasBust) ColoredConsole.WriteLine($"Gambler wins!", ConsoleColor.Green);
        else if (Dealer.Hand.Score > Gambler.Hand.Score && !Dealer.HasBust) ColoredConsole.WriteLine($"House wins!", ConsoleColor.Red);
        else if  (Gambler.HasBust) ColoredConsole.WriteLine($"House wins!", ConsoleColor.Red);
        else if (Dealer.Hand.Score < Gambler.Hand.Score && !Gambler.HasBust) ColoredConsole.WriteLine($"Gambler wins!", ConsoleColor.Green);
        else ColoredConsole.WriteLine($"No one wins!", ConsoleColor.Yellow);
    }

    public bool IsOver => Dealer.HasBust || Dealer.HasBlackjack;    
    public bool IsGamblersRoundOver => Gambler.HasBlackjack || Gambler.HasTwentyOne || Gambler.HasBust || Gambler.IsStanding;
    public Party GetCasinoParty(Character character) => Casino.Characters.Contains(character) ?  Gamblers : Casino;
    public Party GetGamblersParty(Character character) => Casino.Characters.Contains(character) ? Casino : Gamblers;
    
}