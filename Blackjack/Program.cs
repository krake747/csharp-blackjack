Console.Title = "Blackjack";

//string name = ColoredConsole.Prompt("What is your name?").ToUpper();

IPlayer player, player2;
player = new ComputerPlayer();
player2 = new ComputerPlayer();

// Add dealer.
Party casino = new Party(player);
casino.Characters.Add(new Dealer());

// Add gamblers.
Party gamblers = new Party(player2);
gamblers.Characters.Add(new Gambler());
gamblers.Characters.Add(new Gambler());
gamblers.Characters.Add(new Gambler());

Round round = new Round(casino, gamblers);
round.Run();

Console.ReadKey();