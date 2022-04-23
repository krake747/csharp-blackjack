﻿Console.Title = "Blackjack";

//string name = ColoredConsole.Prompt("What is your name?").ToUpper();

IPlayer player1 = new ComputerPlayer();

Dealer dealer = new Dealer(new ComputerPlayer());
Gambler gambler = new Gambler(player1);

Hand hand = new Hand();
hand.AddSpecificCard(new Card(Suit.Hearts, Rank.Ace) { FaceUp = true });
hand.AddSpecificCard(new Card(Suit.Diamonds, Rank.Ace) { FaceUp = true });
hand.AddSpecificCard(new Card(Suit.Diamonds, Rank.Jack) { FaceUp = true });

Round round = new Round(dealer, gambler);
round.Run();

Console.ReadKey();