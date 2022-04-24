public class Party
{
    /// <summary>
    /// The player that is making decisions for this party.
    /// </summary>
    public IPlayer Player { get; }

    /// <summary>
    /// The list of characters that in the party.
    /// </summary>
    public List<Character> Characters { get; } = new List<Character>();

    /// <summary>
    /// Creates a new party with the given player controlling it.
    /// </summary>
    /// <param name="player">The player that will control this party.</param>
    public Party(IPlayer player) => Player = player;
}

