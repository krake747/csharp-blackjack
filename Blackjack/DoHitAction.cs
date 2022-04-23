/// <summary>
/// An action type that does nothing (besides say that the character did nothing).
/// </summary>
public class DoHitAction : IAction
{
    public void Run(Round round, Character character)
    {
        if (character.Hand.Score < 21) character.Hand.AddCard(round.Deck, faceUp: true);
        Console.Write($"{character.Name} hits! Draws "); character.Hand.Cards.Last().Print();
        Console.WriteLine();
    }
}
