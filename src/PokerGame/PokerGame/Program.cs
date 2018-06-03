using PokerGame.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Console.Write($"Player {table.Players[i].Name} got {table.Players[i].Cards[0].ToString()} and {table.Players[i].Cards[1].ToString()}");
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

            var winningPlayers = ResultCalculator.CalculateGameResult(table.Players, table.FaceUpCards);

            if(winningPlayers.Count == 1)
            {
                Console.Write($"{winningPlayers[0].Name} wins."); 
            }
            else
            {
                var winningPlayerNames = string.Join(", ", winningPlayers);
                Console.Write($"The winners are: {winningPlayerNames}. Split pot.");
            }

            Console.Write(Environment.NewLine);
            Console.Write("Game over. Press enter to exit game.");
            Console.ReadLine();
        }
    }
}
