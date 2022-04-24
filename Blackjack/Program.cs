Console.Title = "Blackjack";

//string name = ColoredConsole.Prompt("What is your name?").ToUpper();

IPlayer player = new ComputerPlayer();

// Add dealer.
Party casino = new Party(new ComputerPlayer());
casino.Characters.Add(new Dealer());

// Add gamblers.
Party gamblers = new Party(player);
gamblers.Characters.Add(new Gambler());

Round round = new Round(casino, gamblers);
round.Run();

Console.ReadKey();