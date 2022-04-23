public class RevealAction : IAction
{
    public void Run(Round round, Character character)
    {
        foreach(Card card in character.Hand.Cards) if (!card.FaceUp) card.FlipOver();
        Console.WriteLine($"{character.Name} reveals card.");
    }
}

