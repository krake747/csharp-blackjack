public class ComputerPlayer : IPlayer
{
    private readonly Random _random = new Random();
    public IAction ChooseAction(Round round, Character character)
    {
        Thread.Sleep(750);
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

        List<Character> gamblers = round.GetParty(character).Characters;
        if (gamblers.Contains(character))
        {
            Hand gamblersHand = character.Hand;
            List<Hand> hands = new List<Hand>();
            if (character.SplitHand is not null)
            {
                 Hand gamblersSplitHand = character.SplitHand;
                hands.Add(gamblersHand);
                hands.Add(gamblersSplitHand);
            }
            
            Hand dealersHand = round.Dealer.Hand;
            Card dealersUpCard = dealersHand.Cards[0].IsFaceUp ? dealersHand.Cards[0] : throw new Exception("Dealer's card is not face up.");
            return BasicStrategy(gamblersHand, dealersUpCard); 
        }

        return new DoNothingAction();
    }

    private IAction BasicStrategy(Hand gamblersHand, Card dealersUpCard)
    {
        return (gamblersHand, dealersUpCard) switch
        {
            // Score 8 to 17
            ({ IsPair: false, Score: 8 }, { Score: >= 2 and <= 11 }) => new HitAction(),
            ({ IsPair: false, Score: 9 }, { Score: >= 3 and <= 6 }) => _random.NextDouble() > 0.5 ? new DoubleDownAction() : new HitAction(),
            ({ IsPair: false, Score: 9 }, { Score: 2 or >= 7 and <= 11 }) => new HitAction(),
            ({ IsPair: false, Score: 10 }, { Score: >= 2 and <= 9 }) => _random.NextDouble() > 0.5 ? new DoubleDownAction() : new HitAction(),
            ({ IsPair: false, Score: 10 }, { Score: >= 10 and <= 11 }) => new HitAction(),
            ({ IsPair: false, Score: 11 }, { Score: >= 2 and <= 11 }) => _random.NextDouble() > 0.5 ? new DoubleDownAction() : new HitAction(),
            ({ IsPair: false, Score: 12 }, { Score: >= 2 and <= 3 or >= 7 and <= 11 }) => new HitAction(),
            ({ IsPair: false, Score: 12 }, { Score: >= 4 and <= 6 }) => new StandAction(),
            ({ IsPair: false, Score: 13 }, { Score: >= 2 and <= 6 }) => new StandAction(),
            ({ IsPair: false, Score: 13 }, { Score: >= 7 and <= 11 }) => new HitAction(),
            ({ IsPair: false, Score: 14 }, { Score: >= 2 and <= 6 }) => new StandAction(),
            ({ IsPair: false, Score: 14 }, { Score: >= 7 and <= 11 }) => new HitAction(),
            ({ IsPair: false, Score: 15 }, { Score: >= 2 and <= 6 }) => new StandAction(),
            ({ IsPair: false, Score: 15 }, { Score: >= 7 and <= 11 }) => new HitAction(),
            ({ IsPair: false, Score: 16 }, { Score: >= 2 and <= 6 }) => new StandAction(),
            ({ IsPair: false, Score: 16 }, { Score: >= 7 and <= 11 }) => new HitAction(),
            ({ IsPair: false, Score: 17 }, { Score: >= 2 and <= 11 }) => new StandAction(),
            ({ IsPair: false, Score: 17 }, { Rank: Rank.Ace }) => new StandAction(),
            // Hand contains 1 Ace 
            ({ AceAndTwo: true }, { Score: >= 5 and <= 6 }) => _random.NextDouble() > 0.5 ? new DoubleDownAction() : new HitAction(),
            ({ AceAndTwo: true }, { Score: >= 2 and <= 11 }) => new HitAction(),
            ({ AceAndThree: true }, { Score: >= 5 and <= 6 }) => _random.NextDouble() > 0.5 ? new DoubleDownAction() : new HitAction(),
            ({ AceAndThree: true }, { Score: >= 2 and <= 11 }) => new HitAction(),
            ({ AceAndFour: true }, { Score: >= 4 and <= 6 }) => _random.NextDouble() > 0.5 ? new DoubleDownAction() : new HitAction(),
            ({ AceAndFour: true }, { Score: >= 2 and <= 11 }) => new HitAction(),
            ({ AceAndFive: true }, { Score: >= 4 and <= 6 }) => _random.NextDouble() > 0.5 ? new DoubleDownAction() : new HitAction(),
            ({ AceAndFive: true }, { Score: >= 2 and <= 11 }) => new HitAction(),
            ({ AceAndSix: true }, { Score: >= 3 and <= 6 }) => _random.NextDouble() > 0.5 ? new DoubleDownAction() : new HitAction(),
            ({ AceAndSix: true }, { Score: >= 2 and <= 11 }) => new HitAction(),
            ({ AceAndSeven: true }, { Score: >= 3 and <= 6 }) => _random.NextDouble() > 0.5 ? new DoubleDownAction() : new StandAction(),
            ({ AceAndSeven: true }, { Score: >= 2 and <= 8 }) => new StandAction(),
            ({ AceAndSeven: true }, { Score: >= 9 and <= 11 }) => new HitAction(),
            ({ AceAndEight: true }, { Score: >= 2 and <= 11 }) => new StandAction(),
            // Hand contains pairs
            ({ Twos: true }, { Score: >= 2 and <= 3 }) => _random.NextDouble() > 0.1 ? new SplitAction() : new HitAction(),
            ({ Twos: true }, { Score: >= 4 and <= 7 }) => new SplitAction(),
            ({ Twos: true }, { Score: >= 8 and <= 11 }) => new HitAction(),
            ({ Threes: true }, { Score: >= 2 and <= 3 }) => _random.NextDouble() > 0.1 ? new SplitAction() : new HitAction(),
            ({ Threes: true }, { Score: >= 4 and <= 7 }) => new SplitAction(),
            ({ Threes: true }, { Score: >= 8 and <= 11 }) => new HitAction(),
            ({ Fours: true }, { Score: >= 5 and <= 6 }) => new SplitAction(),
            ({ Fours: true }, { Score: >= 2 and <= 11 }) => new HitAction(),
            ({ Fives: true }, { Score: >= 2 and <= 9 }) => _random.NextDouble() > 0.5 ? new DoubleDownAction() : new HitAction(),
            ({ Fives: true }, { Score: >= 2 and <= 11 }) => new HitAction(),
            ({ Sixes: true }, { Score: >= 2 and <= 6 }) => _random.NextDouble() > 0.1 ? new SplitAction() : new HitAction(),
            ({ Sixes: true }, { Score: >= 2 and <= 11 }) => new HitAction(),
            ({ Sevens: true }, { Score: >= 2 and <= 7 }) => _random.NextDouble() > 0.1 ? new SplitAction() : new HitAction(),
            ({ Sevens: true }, { Score: >= 2 and <= 11 }) => new HitAction(),
            ({ Eights: true }, { Score: >= 2 and <= 11 }) => new SplitAction(),
            ({ Nines: true }, { Score: >= 2 and <= 6 or 8 and 9 }) => new SplitAction(),
            ({ Nines: true }, { Score: 7 or 10 or 11 }) => new StandAction(),
            ({ Tens: true }, { Score: >= 2 and <= 11 }) => new StandAction(),
            ({ Aces: true }, { Score: >= 2 and <= 11 }) => new SplitAction(),
            // Basic Actions
            ({ Score: < 17 }, _) => new HitAction(),
            ({ Score: >= 17 }, _) => new StandAction(),

            _ => new DoNothingAction(),
        };
    }
}