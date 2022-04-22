Console.Title = "Blackjack";

string name = ColoredConsole.Prompt("What is your name?").ToUpper();

IPlayer player1, player2;
player1 = new ConsolePlayer(name);
player2 = new ComputerPlayer();

Deck deck = new Deck();
deck.Shuffle();

Hand hand = new Hand(2, deck);

Card card = new Card(Suit.Hearts, Rank.Ace);
card.FlipOver();
card.Print();

Console.ReadKey();