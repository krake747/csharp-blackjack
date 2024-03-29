﻿public class WinChecker
{
    private Party _casino;
    private Party _gamblers;
    public WinChecker(Party casino, Party gamblers)
    {
        _casino = casino;
        _gamblers = gamblers;
    }

    public bool IsOver => IsDealerRoundOver && IsGamblersRoundOver;
    public bool DealerHasBlackjack => _casino.Characters.All(c => c.HasHiddenBlackjack);
    public bool IsDealerRoundOver => _casino.Characters.All(c => c.HasBlackjack || c.HasTwentyOne || c.HasBust || c.IsStanding);
    public bool IsGamblersRoundOver => _gamblers.Characters.All(c => c.HasBlackjack || c.HasTwentyOne || c.HasBust || c.IsStanding);
    
}

