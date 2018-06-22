using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerGame.Domain
{
    public static class ResultCalculator
    {
        public static Result CalculateGameResult(List<Player> players, List<Card> faceUpCards)
        {
            var result = new Result();
            foreach (var player in players)
            {
                player.Cards.AddRange(faceUpCards);
            }

            //straight flush (5 enumerating values, same suit)
            foreach (var player in players)
            {
                var ascendingCards = player.Cards.OrderBy(card => card.Value)
                                    .Select(card => card).ToList();
                var cardsForStraightflush = new List<Card>();

                int amountOfSequentialCards = 1;
                for (int i = 0; i < ascendingCards.Count - 1; i++)
                {
                    cardsForStraightflush.Add(ascendingCards[i]);
                    if (ascendingCards[i + 1].Value - ascendingCards[i].Value == 1)
                    {
                        amountOfSequentialCards++;
                    }
                    else
                    {
                        var cardThatIsNotInSequence = ascendingCards.Where(card => card.Suit == ascendingCards[i].Suit 
                            && card.Value == ascendingCards[i].Value).Single();
                        cardsForStraightflush.Remove(cardThatIsNotInSequence);
                        if(amountOfSequentialCards > 1)
                        {
                            amountOfSequentialCards--;
                        }
                    }
                }
                 var duplicateSuits = cardsForStraightflush.GroupBy(card => card.Suit)
                    .Where(group => group.Count() >= 5)
                    .Select(c => c.Key).ToList();

                if (amountOfSequentialCards >= 5 && duplicateSuits.Count != 0)
                {
                    result.Names.Add(player.Name);
                }
            }
            if (result.Names.Count > 0)
            {
                result.ResultOfPoker = PokerHands.Straight_flush;
                return result;
            }

            //four of a kind (4 * same value)
            foreach (var player in players)
            {
                var quatreCard = player.Cards.GroupBy(card => card.Value)
                                    .Where(group => group.Count() == 4)
                                    .Select(c => c.Key).ToList();

                if (quatreCard.Count != 0)
                {
                    result.Names.Add(player.Name);
                }
            }
            if (result.Names.Count > 0)
            {
                result.ResultOfPoker = PokerHands.Four_of_a_kind;
                return result;
            }

            //full house (3 of the same value + 2 of the same value)
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
                    result.Names.Add(player.Name);
                }
            }
            if (result.Names.Count > 0)
            {
                result.ResultOfPoker = PokerHands.Full_house;
                return result;
            }

            //flush (5 times same Suit)
            foreach (var player in players)
            {
                var duplicateSuit = player.Cards.GroupBy(card => card.Suit)
                                    .Where(group => group.Count() >= 5)
                                    .Select(c => c.Key).ToList();
                if (duplicateSuit.Count != 0)
                {
                    result.Names.Add(player.Name);
                }
            }
            if (result.Names.Count > 0)
            {
                result.ResultOfPoker = PokerHands.Flush;
                return result;
            }
            
            //straight (5 enumerating Values)
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
                    else
                    {
                        amountOfSequentialCards--;
                    }
                }
                if (amountOfSequentialCards >= 5)
                {
                    result.Names.Add(player.Name);
                }
            }
            if (result.Names.Count > 0)
            {
                result.ResultOfPoker = PokerHands.Straight;
                return result;
            }

            //Three of a kind (3 * same value)
            foreach (var player in players)
            {
                var tripleCard = player.Cards.GroupBy(card => card.Value)
                                    .Where(group => group.Count() == 3)
                                    .Select(c => c.Key).ToList();

                if (tripleCard.Count != 0)
                {
                    result.Names.Add(player.Name);
                }
            }
            if (result.Names.Count > 0)
            {
                result.ResultOfPoker = PokerHands.Three_of_a_kind;
                return result;
            }

            //two pair (2 times double value)
            foreach (var player in players)
            {
                var doubleCards = player.Cards.GroupBy(card => card.Value)
                    .Where(group => group.Count() == 2)
                    .Select(c => c.Key).ToList();
                if(doubleCards.Count == 2)
                {
                    result.Names.Add(player.Name);
                }
            }
            if (result.Names.Count > 0)
            {
                result.ResultOfPoker = PokerHands.Two_pair;
                return result;
            }

            //pair (double value)
            foreach (var player in players)
            {
                var doubleCard = player.Cards.GroupBy(card => card.Value)
                    .Where(group => group.Count() == 2)
                    .Select(c => c.Key).ToList();

                if (doubleCard.Count != 0)
                {
                    result.Names.Add(player.Name);
                }
            }
            if (result.Names.Count > 0)
            {
                result.ResultOfPoker = PokerHands.Pair;
                return result;
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
            int highCard = playerHighCards.Max();
            
            foreach(var player in players)
            {
                if(player.Cards.Any(card => (int) card.Value == highCard))
                {
                    result.Names.Add(player.Name);
                }
            }

            if (result.Names.Count > 0)
            {
                result.ResultOfPoker = PokerHands.High_card;
                return result;
            }

            throw new ArgumentException("Cannot calculate who wins");
        }
    }
}
