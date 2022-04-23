public class StandAction : IAction
{
    public void Run(Round round, Character character)
    {
        character.IsStand = true;
        Console.WriteLine($"{character.Name} STOOD!");
    }
}