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
            ColoredConsole.Write($"{character.Name,10} ", color); character.Hand.Print();
            Console.WriteLine();
        }

        // Display the middle banner.
        Console.WriteLine("------------------------------------------------ VS ------------------------------------------------");

        Console.WriteLine();
        foreach (Character character in round.Gamblers.Characters)
        {
            ConsoleColor color = character == activeCharacter ? ConsoleColor.Yellow : ConsoleColor.Gray;
            ColoredConsole.Write($"{character.Name,10} ", color); character.Hand.Print();
            Console.WriteLine();
        }

        // Display the bottom banner.
        Console.WriteLine("====================================================================================================");
        Console.WriteLine();
    }
}

