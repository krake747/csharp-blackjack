public static class RoundRenderer
{
    public static void Render(Round round, Character activeCharacter)
    {
        // Display the top banner.
        Console.WriteLine("=============================================== TURN ===============================================");

        Console.WriteLine();
        foreach (Character character in round.Casino.Characters)
        {
            ConsoleColor color = character == activeCharacter ? ConsoleColor.Yellow : ConsoleColor.Gray;
            ColoredConsole.Write($"{character.Name,10} ", color); PrintHand(character); PrintAction(character);
            Console.WriteLine();
        }

        // Display the middle banner.
        Console.WriteLine("------------------------------------------------ VS ------------------------------------------------");

        Console.WriteLine();
        foreach (Character character in round.Gamblers.Characters)
        {
            ConsoleColor color = character == activeCharacter ? ConsoleColor.Yellow : ConsoleColor.Gray;
            ColoredConsole.Write($"{character.Name,10} ", color); PrintHand(character); PrintAction(character);

            if (character.SplitHand is not null)
            {
                Console.Write(" || ");
                PrintSplitHand(character);
            }

            Console.WriteLine();
        }

        // Display the bottom banner.
        Console.WriteLine("====================================================================================================");
        Console.WriteLine();
    }

    /// <summary>
    /// Prints the cards in hand to the console.
    /// </summary>
    /// <param name="character"></param>
    public static void PrintHand(Character character)
    {
        foreach (Card card in character.Hand.Cards) card.Print(true);
        Console.Write($"({character.Hand.Score})");
    }

    /// <summary>
    /// Prints the cards of the splitted hand to the console.
    /// </summary>
    /// <param name="character"></param>
    public static void PrintSplitHand(Character character)
    {
        foreach (Card card in character.SplitHand!.Cards) card.Print(true);
        Console.Write($"({character.SplitHand.Score})");
    }

    /// <summary>
    /// Prints the final action of the character to the console.
    /// </summary>
    /// <param name="character"></param>
    private static void PrintAction(Character character)
    {
        (string action, ConsoleColor color) = character switch 
        {
            { HasBlackjack: true } => (" Blackjack!", ConsoleColor.Green),
            { HasTwentyOne: true } => (" TwentyOne!", ConsoleColor.Green),
            { HasBust: true } => (" Bust!", ConsoleColor.Red),
            { IsStanding: true } => (" Stands!", ConsoleColor.Gray),
            _ => ("", ConsoleColor.Gray)
        };

        ColoredConsole.Write(action, color);
    }
}

