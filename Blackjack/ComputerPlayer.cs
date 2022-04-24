public class ComputerPlayer : IPlayer
{
    private readonly Random _random = new Random();
    public IAction ChooseAction(Round round, Character character)
    {
        Thread.Sleep(500);
        if (character == round.Dealer)
        {
            return character.Hand switch
            {
                { Cards.Count: 0 } => new DealAction(),
                { AllFaceUp: false } => new RevealAction(),
                { AllFaceUp: true, Score: < 16 } => new HitAction(),
                { AllFaceUp: true, Score: >= 16 } => new StandAction(),
                _ => new DoNothingAction(),
            };
        }

        if (character == round.Gambler)
        {
            return character.Hand switch
            {
                { Score: < 17 } => new HitAction(),
                { Score: >= 17 } =>  new StandAction(),
                _ => new DoNothingAction(),
            };
        }

        return new DoNothingAction();
    }
}