public class Round
{
    private WinChecker _winChecker;
    public bool IsOver => _winChecker.IsOver;
    public Party Casino { get; }
    public Character Dealer { get; }
    public Party Gamblers { get; }
    public Deck Deck { get; } = new Deck();
    
    public Round(Party casino, Party gamblers)
    {
        Casino = casino;
        Dealer = Casino.Characters[0];
        Gamblers = gamblers;
        Deck.Shuffle();
        _winChecker = new WinChecker(casino, gamblers);
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
            while (!_winChecker.IsGamblersOver)
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

                    if (_winChecker.IsGamblersOver) break;
                }
            }

            // Dealer reveals hidden card.
            Casino.Player.ChooseAction(this, Dealer).Run(this, Dealer);
            Console.WriteLine();
            RoundRenderer.Render(this, (Character)Dealer);
            
            if (_winChecker.IsDealerOver) break;
        }

        Console.WriteLine($"Round is over!");
    }
    public Party GetOppositeParty(Character character) => Casino.Characters.Contains(character) ? Gamblers : Casino;
    public Party GetParty(Character character) => Casino.Characters.Contains(character) ? Casino : Gamblers;
}