/// <summary>
/// /// Represents the action to "Hit". 
/// </summary>
public class DoHitAction : IAction
{
    public void Run(Round round, Character character)
    {
        if (character.Hand.Score < 21) character.Hand.AddCard(round.Deck, isFaceUp: true);
        Console.Write($"{character.Name} hits! Draws "); character.Hand.Cards.Last().Print();
        Console.WriteLine();
    }
}
