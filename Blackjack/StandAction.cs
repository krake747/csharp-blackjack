/// <summary>
/// Represents the action to "Stand". 
/// </summary>
public class StandAction : IAction
{
    public void Run(Round round, Character character)
    {
        character.IsStanding = true;
        Console.WriteLine($"{character.Name} STOOD!");
    }
}