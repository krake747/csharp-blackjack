public static class RoundRenderer
{
    public static void Render(Round round, Character activeCharacter)
    {
        // Display the top banner.
        Console.WriteLine("=============================================== TURN ===============================================");

        Console.WriteLine();
        Console.Write($"{round.Dealer.Name,10}: "); round.Dealer.Hand.Print();
        Console.WriteLine();

        // Display the middle banner.
        Console.WriteLine("------------------------------------------------ VS ------------------------------------------------");

        Console.WriteLine();
        Console.Write($"{round.Gambler.Name,10}: "); round.Gambler.Hand.Print();
        Console.WriteLine();

        // Display the bottom banner.
        Console.WriteLine("====================================================================================================");
    }

    public static void RenderDealRound(Round round)
    {
        // Display the top banner.
        Console.WriteLine("=============================================== DEAL ===============================================");

        Console.WriteLine();
        Console.Write($"{round.Dealer.Name,10}: "); round.Dealer.Hand.Print();
        Console.WriteLine();

        // Display the middle banner.
        Console.WriteLine("------------------------------------------------ VS ------------------------------------------------");

        Console.WriteLine();
        Console.Write($"{round.Gambler.Name,10}: "); round.Gambler.Hand.Print();
        Console.WriteLine();

        // Display the bottom banner.
        Console.WriteLine("====================================================================================================");
    }
}

