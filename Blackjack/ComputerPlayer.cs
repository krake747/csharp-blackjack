public class ComputerPlayer : IPlayer
{
    private readonly Random _random = new Random();
    public IAction ChooseAction(Round round, Character character)
    {
        Thread.Sleep(500);
        if (character == round.Dealer)
        {
            return character switch
            {
                { Hand.CardCount: 0 } => new DealAction(),
                { Hand.AllFaceUp: false } => new RevealAction(),
                { Hand.AllFaceUp: true, Hand.Score: < 16 } => new DoHitAction(),
                { Hand.AllFaceUp: true, Hand.Score: >= 16 } => new StandAction(),
                _ => new DoNothingAction(),
            };
        }

        if (character == round.Gambler)
        {
            return character switch
            {
                { Hand.Score: < 16 } => new DoHitAction(),
                { Hand.Score: >= 16 and <= 21 } => _random.NextDouble() > 0.90 ? new DoHitAction() : new StandAction(),
                _ => new DoNothingAction(),
            };
        }


        return new DoNothingAction();
    }
}