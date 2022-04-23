public class ConsolePlayer : IPlayer
{
    public string Name { get; }
    public IAction ChooseAction(Round round, Character character) => throw new NotImplementedException();

    public ConsolePlayer(string name) => Name = name.ToUpper();

}
