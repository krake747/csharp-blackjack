public class ComputerPlayer : IPlayer
{
    public string Name => "DEALER";
    public IAction ChooseAction() => throw new NotImplementedException();
}

