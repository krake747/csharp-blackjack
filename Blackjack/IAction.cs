/// <summary>
/// Defines what all actions in the system must look like.
/// </summary>
public interface IAction
{
    void Run(Round round, Character character);
}

