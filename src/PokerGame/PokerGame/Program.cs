﻿using PokerGame.Domain;
using System;
using System.Collections.Generic;

namespace PokerGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var players = new List<Player>()
            {
                new Player("Gilles"),
                new Player("Jack"),
                new Player("John"),
                new Player("Layla")
            };

            Console.Write("A poker game is about to start." + Environment.NewLine);
            var deck = new Deck();
            deck.FillDeck();

            Console.Write("Shuffling deck..." + Environment.NewLine);
            deck.ShuffleDeck();

            var table = new PokerTable(players, deck);

            Console.Write("Dealing cards..." + Environment.NewLine);
            Console.Write(Environment.NewLine);

            var numberOfPlayers = players.Count;
            for (int i = 0; i < numberOfPlayers; i++)
            {
                table.Players[i].Cards = table.Deck.DrawCards(2);
                var currentPlayer = table.Players[i];
                Console.Write($"Player {currentPlayer.Name} got {currentPlayer.Cards[0].ToString()} and {currentPlayer.Cards[1].ToString()}");
                Console.Write(Environment.NewLine);
            }
            Console.Write(Environment.NewLine);
            
            Console.Write("Flop:" + Environment.NewLine);
            table.FaceUpCards.AddRange(table.Deck.DrawCards(3));
            Console.Write($"{table.FaceUpCards[0].ToString()}, {table.FaceUpCards[1].ToString()}, {table.FaceUpCards[2].ToString()}");
            Console.Write(Environment.NewLine);

            Console.Write("Turn: " + Environment.NewLine);
            table.FaceUpCards.AddRange(table.Deck.DrawCards(1));
            Console.Write(table.FaceUpCards[3].ToString());
            Console.Write(Environment.NewLine);

            Console.Write("River: " + Environment.NewLine);
            table.FaceUpCards.AddRange(table.Deck.DrawCards(1));
            Console.Write(table.FaceUpCards[4].ToString());
            Console.Write(Environment.NewLine);
            Console.Write(Environment.NewLine);

            var resultOfPokerGame = ResultCalculator.CalculateGameResult(table.Players, table.FaceUpCards);
            var winningPokerHand = resultOfPokerGame.ResultOfPoker.ToString().Replace('_', ' ');

            if(resultOfPokerGame.Names.Count == 1)
            {
                Console.Write($"{resultOfPokerGame.Names[0]} wins with a {winningPokerHand}."); 
            }
            else
            {
                var winningPlayerNames = string.Join(", ", resultOfPokerGame.Names);
                Console.Write($"The winners are: {winningPlayerNames} with a {winningPokerHand}. Split pot.");
            }

            Console.Write(Environment.NewLine);
            Console.Write("Game over. Press enter to exit game.");
            Console.ReadLine();
        }
    }
}
