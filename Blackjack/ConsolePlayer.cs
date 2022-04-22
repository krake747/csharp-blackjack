public class ConsolePlayer : IPlayer
{
    public string Name { get; }
    public IAction ChooseAction() => throw new NotImplementedException();

    public ConsolePlayer(string name) => Name = name.ToUpper();

}
