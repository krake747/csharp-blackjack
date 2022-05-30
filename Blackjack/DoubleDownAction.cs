/// <summary>
/// Represents the action to "Double Down". 
/// </summary>
public class DoubleDownAction : IAction
{
    public void Run(Round round, Character character)
    {
        if (character.Hand.Score < 21) character.Hand.AddCard(round.Deck, isFaceUp: true);
        Console.Write($"{character.Name} DOUBLES DOWN and hits for one final card! Draws "); character.Hand.Cards.Last().Print();
        Console.WriteLine();
    }
}