/// <summary>
/// Represents the action to "Split". 
/// </summary>
public class SplitAction : IAction
{
    public void Run(Round round, Character character)
    {
        // Create a second hand.
        if (character.Hand.TwoCardsInHand && character.Hand.AllFaceUp)
        {
            character.SplitHand = new Hand();
            Card card = character.Hand.Cards.Last();
            character.Hand.Cards.Remove(card);
            character.SplitHand.Cards.Add(card);
        }
            
        Console.Write($"{character.Name} SPLITS the hand! ");
        Console.WriteLine();
    }
}