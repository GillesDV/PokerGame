using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace PokerGame.Domain.Tests
{
    [TestClass]
    public class PokerTableTests
    {
        [TestMethod]
        public void Given_players_with_straight_and_flush_When_CalculateGameResult_Then_Player_with_Flush_wins()
        {
            var faceUpCards = new List<Card>()
            {
                new Card { Suit = Suit.Diamonds, Value = Value.Two},
                new Card { Suit = Suit.Diamonds, Value = Value.Four},
                new Card { Suit = Suit.Diamonds, Value = Value.Six},
                new Card { Suit = Suit.Clubs, Value = Value.Eight},
                new Card { Suit = Suit.Spades, Value = Value.Ace}
            };
            var player1 = new Player("Gilles");
            player1.Cards = new List<Card>
            {
                new Card { Suit = Suit.Diamonds, Value = Value.Queen},
                new Card { Suit = Suit.Diamonds, Value = Value.King}
            };
            var player2 = new Player("Jane");
            player2.Cards = new List<Card>
            {
                new Card { Suit = Suit.Hearts, Value = Value.Three},
                new Card { Suit = Suit.Spades, Value = Value.Five}
            };
            var players = new List<Player>()
            {
                player1, player2
            };

            var winningPlayer = ResultCalculator.CalculateGameResult(players, faceUpCards);

            Assert.AreEqual(1, winningPlayer.Count);
            Assert.AreEqual(player1.Name, winningPlayer[0].Name);
        }

        [TestMethod]
        public void Given_players_with_straight_and_Full_House_When_CalculateGameResult_Then_Player_with_Full_House_wins()
        {
            var faceUpCards = new List<Card>()
            {
                new Card { Suit = Suit.Diamonds, Value = Value.Two},
                new Card { Suit = Suit.Hearts, Value = Value.Four},
                new Card { Suit = Suit.Hearts, Value = Value.Six},
                new Card { Suit = Suit.Clubs, Value = Value.Six},
                new Card { Suit = Suit.Spades, Value = Value.Ace}
            };
            var player1 = new Player("Gilles");
            player1.Cards = new List<Card>
            {
                new Card { Suit = Suit.Diamonds, Value = Value.Six},
                new Card { Suit = Suit.Diamonds, Value = Value.Ace}
            };
            var player2 = new Player("Jane");
            player2.Cards = new List<Card>
            {
                new Card { Suit = Suit.Hearts, Value = Value.Three},
                new Card { Suit = Suit.Spades, Value = Value.Five}
            };
            var players = new List<Player>()
            {
                player1, player2
            };

            var winningPlayer = ResultCalculator.CalculateGameResult(players, faceUpCards);

            Assert.AreEqual(1, winningPlayer.Count);
            Assert.AreEqual(player1.Name, winningPlayer[0].Name);
        }

        [TestMethod]
        public void Given_players_with_straight_and_High_card_When_CalculateGameResult_Then_Player_with_Straight_wins()
        {
            var faceUpCards = new List<Card>()
            {
                new Card { Suit = Suit.Diamonds, Value = Value.Two},
                new Card { Suit = Suit.Hearts, Value = Value.Four},
                new Card { Suit = Suit.Hearts, Value = Value.Six},
                new Card { Suit = Suit.Clubs, Value = Value.King},
                new Card { Suit = Suit.Spades, Value = Value.Queen}
            };
            var player1 = new Player("Gilles");
            player1.Cards = new List<Card>
            {
                new Card { Suit = Suit.Diamonds, Value = Value.Three},
                new Card { Suit = Suit.Diamonds, Value = Value.Five}
            };
            var player2 = new Player("Jane");
            player2.Cards = new List<Card>
            {
                new Card { Suit = Suit.Hearts, Value = Value.Seven},
                new Card { Suit = Suit.Spades, Value = Value.Ace}
            };
            var players = new List<Player>()
            {
                player1, player2
            };

            var winningPlayer = ResultCalculator.CalculateGameResult(players, faceUpCards);

            Assert.AreEqual(1, winningPlayer.Count);
            Assert.AreEqual(player1.Name, winningPlayer[0].Name);
        }

        [TestMethod]
        public void Given_players_with_two_times_High_Card_When_CalculateGameResult_Then_Player_with_best_High_Card_wins()
        {
            var faceUpCards = new List<Card>()
            {
                new Card { Suit = Suit.Diamonds, Value = Value.Two},
                new Card { Suit = Suit.Hearts, Value = Value.Four},
                new Card { Suit = Suit.Hearts, Value = Value.Six},
                new Card { Suit = Suit.Clubs, Value = Value.King},
                new Card { Suit = Suit.Spades, Value = Value.Queen}
            };
            var player1 = new Player("Gilles");
            player1.Cards = new List<Card>
            {
                new Card { Suit = Suit.Diamonds, Value = Value.Three},
                new Card { Suit = Suit.Diamonds, Value = Value.Ace}
            };
            var player2 = new Player("Jane");
            player2.Cards = new List<Card>
            {
                new Card { Suit = Suit.Hearts, Value = Value.Seven},
                new Card { Suit = Suit.Spades, Value = Value.Eight}
            };
            var players = new List<Player>()
            {
                player1, player2
            };

            var winningPlayer = ResultCalculator.CalculateGameResult(players, faceUpCards);

            Assert.AreEqual(1, winningPlayer.Count);
            Assert.AreEqual(player1.Name, winningPlayer[0].Name);
        }


    }
}
