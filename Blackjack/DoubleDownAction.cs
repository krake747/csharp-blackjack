/// <summary>
/// An action type that does nothing (besides say that the character did nothing).
/// </summary>
public class DoubleDownAction : IAction
{
    public void Run(Round round, Character character) => Console.WriteLine($"{character.Name} did NOTHING.");
}