public class WinChecker
{
    private Party _casino;
    private Party _gamblers;
    public WinChecker(Party casino, Party gamblers)
    {
        _casino = casino;
        _gamblers = gamblers;
    }

    public bool IsOver => IsDealerOver && IsGamblersOver;
    public bool IsDealerOver => _casino.Characters.All(c => c.HasBlackjack || c.HasTwentyOne || c.HasBust || c.IsStanding);
    public bool IsGamblersOver => _gamblers.Characters.All(c => c.HasBlackjack || c.HasTwentyOne || c.HasBust || c.IsStanding);
}

