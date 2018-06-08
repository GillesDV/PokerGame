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
                new Card (Suit.Diamonds, Value.Two),
                new Card (Suit.Diamonds, Value.Four),
                new Card (Suit.Diamonds, Value.Six),
                new Card (Suit.Clubs, Value.Eight),
                new Card (Suit.Spades, Value.Ace)
            };
            var player1 = new Player("Gilles");
            player1.Cards = new List<Card>
            {
                new Card (Suit.Diamonds, Value.Queen),
                new Card (Suit.Diamonds, Value.King)
            };
            var player2 = new Player("Jane");
            player2.Cards = new List<Card>
            {
                new Card (Suit.Hearts, Value.Three),
                new Card (Suit.Spades, Value.Five)
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
                new Card (Suit.Diamonds, Value.Two),
                new Card (Suit.Hearts, Value.Four),
                new Card (Suit.Hearts, Value.Six),
                new Card (Suit.Clubs, Value.Six),
                new Card (Suit.Spades, Value.Ace)
            };
            var player1 = new Player("Gilles");
            player1.Cards = new List<Card>
            {
                new Card (Suit.Diamonds, Value.Six),
                new Card (Suit.Diamonds, Value.Ace)
            };
            var player2 = new Player("Jane");
            player2.Cards = new List<Card>
            {
                new Card (Suit.Hearts, Value.Three),
                new Card (Suit.Spades, Value.Five)
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
                new Card (Suit.Diamonds, Value.Two),
                new Card (Suit.Hearts, Value.Four),
                new Card (Suit.Hearts, Value.Six),
                new Card (Suit.Clubs, Value.King),
                new Card (Suit.Spades, Value.Queen)
            };
            var player1 = new Player("Gilles");
            player1.Cards = new List<Card>
            {
                new Card (Suit.Diamonds, Value.Three),
                new Card (Suit.Diamonds, Value.Five)
            };
            var player2 = new Player("Jane");
            player2.Cards = new List<Card>
            {
                new Card (Suit.Hearts, Value.Seven),
                new Card (Suit.Spades, Value.Ace)
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
                new Card (Suit.Diamonds, Value.Two),
                new Card (Suit.Hearts, Value.Four),
                new Card (Suit.Hearts, Value.Six),
                new Card (Suit.Clubs, Value.King),
                new Card (Suit.Spades, Value.Queen)
            };
            var player1 = new Player("Gilles");
            player1.Cards = new List<Card>
            {
                new Card (Suit.Diamonds, Value.Three),
                new Card (Suit.Diamonds, Value.Ace)
            };
            var player2 = new Player("Jane");
            player2.Cards = new List<Card>
            {
                new Card (Suit.Hearts, Value.Seven),
                new Card (Suit.Spades, Value.Eight)
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
        public void Given_players_with_ThreeOfAKind_and_TwoPair_When_CalculateGameResult_Then_Player_with_ThreeOfAKind_wins()
        {
            var faceUpCards = new List<Card>()
            {
                new Card (Suit.Diamonds, Value.Two),
                new Card (Suit.Hearts, Value.Four),
                new Card (Suit.Hearts, Value.Six),
                new Card (Suit.Clubs, Value.King),
                new Card (Suit.Spades, Value.Queen)
            };
            var player1 = new Player("Gilles");
            player1.Cards = new List<Card>
            {
                new Card (Suit.Diamonds, Value.King),
                new Card (Suit.Spades, Value.King)
            };
            var player2 = new Player("Jane");
            player2.Cards = new List<Card>
            {
                new Card (Suit.Hearts, Value.Two),
                new Card (Suit.Diamonds, Value.Queen)
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
        public void Given_players_with_TwoPair_and_Pair_When_CalculateGameResult_Then_Player_with_TwoPair_wins()
        {
            var faceUpCards = new List<Card>()
            {
                new Card (Suit.Diamonds, Value.Two),
                new Card (Suit.Hearts, Value.Four),
                new Card (Suit.Hearts, Value.Six),
                new Card (Suit.Clubs, Value.King),
                new Card (Suit.Spades, Value.Queen)
            };
            var player1 = new Player("Gilles");
            player1.Cards = new List<Card>
            {
                new Card (Suit.Diamonds, Value.King),
                new Card (Suit.Diamonds, Value.Queen)
            };
            var player2 = new Player("Jane");
            player2.Cards = new List<Card>
            {
                new Card (Suit.Hearts, Value.Three),
                new Card (Suit.Spades, Value.Queen)
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
        public void Given_players_with_Pair_and_HighCard_When_CalculateGameResult_Then_Player_with_Pair_wins()
        {
            var faceUpCards = new List<Card>()
            {
                new Card (Suit.Diamonds, Value.Two),
                new Card (Suit.Hearts, Value.Four),
                new Card (Suit.Hearts, Value.Six),
                new Card (Suit.Clubs, Value.King),
                new Card (Suit.Spades, Value.Queen)
            };
            var player1 = new Player("Gilles");
            player1.Cards = new List<Card>
            {
                new Card (Suit.Diamonds, Value.Jack),
                new Card (Suit.Diamonds, Value.Queen)
            };
            var player2 = new Player("Jane");
            player2.Cards = new List<Card>
            {
                new Card (Suit.Hearts, Value.Three),
                new Card (Suit.Spades, Value.Seven)
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
