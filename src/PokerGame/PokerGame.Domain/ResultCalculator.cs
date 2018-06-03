using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame.Domain
{
    public static class ResultCalculator
    {
        public static List<Player> CalculateGameResult(List<Player> players, List<Card> faceUpCards)
        {
            List<Player> winningPlayers = new List<Player>();
            foreach (var player in players)
            {
                player.Cards.AddRange(faceUpCards);
            }

            //check for full house (3 of the same value + 2 of the same value)
            foreach (var player in players)
            {
                var tripleCard = player.Cards.GroupBy(card => card.Value)
                                    .Where(group => group.Count() == 3)
                                    .Select(c => c.Key).ToList();
                var doubleCard = player.Cards.GroupBy(card => card.Value)
                    .Where(group => group.Count() == 2)
                    .Select(c => c.Key).ToList();

                if (tripleCard.Count != 0 && doubleCard.Count != 0)
                {
                    winningPlayers.Add(player);
                }
            }
            if (winningPlayers.Count > 0)
            {
                return winningPlayers;
            }

            //check for flush (5 times same Suit)
            foreach (var player in players)
            {
                var duplicateSuit = player.Cards.GroupBy(card => card.Suit)
                                    .Where(group => group.Count() >= 5)
                                    .Select(c => c.Key).ToList();
                if (duplicateSuit.Count != 0)
                {
                    winningPlayers.Add(player);
                }
            }
            if (winningPlayers.Count > 0)
            {
                return winningPlayers;
            }
            
            //check for straight (5 enumerating Values)
            foreach (var player in players)
            {
                var ascendingCardIndexes = player.Cards.OrderBy(card => card.Value)
                                    .Select(card => (int) card.Value).Distinct().ToList();

                int amountOfSequentialCards = 1;
                for (int i = 0; i < ascendingCardIndexes.Count - 1; i++)
                {
                    if(ascendingCardIndexes[i+1] - ascendingCardIndexes[i] == 1)
                    {
                        amountOfSequentialCards++;
                    }
                }
                if (amountOfSequentialCards >= 5)
                {
                    winningPlayers.Add(player);
                }
            }
            if (winningPlayers.Count > 0)
            {
                return winningPlayers;
            }

            //check high card
            var playerHighCards = new int[players.Count];
            for (int i = 0; i <= players.Count -1; i++)
            {
                playerHighCards[i] = players[i].Cards
                                        .OrderByDescending(card => card.Value)
                                        .Select(card => (int)card.Value)
                                        .Take(1)
                                        .Single();
            }
            int HighCard = playerHighCards.Max();
            
            foreach(var player in players)
            {
                if(player.Cards.Any(card => (int) card.Value == HighCard))
                {
                    winningPlayers.Add(player);
                }
            }

            if (winningPlayers.Count > 0)
            {
                return winningPlayers;
            }

            throw new ArgumentException("Cannot calculate who wins");
        }
    }
}
