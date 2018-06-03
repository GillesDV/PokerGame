using System.Collections.Generic;

namespace PokerGame.Domain
{
    public class PokerTable
    {
        public List<Player> Players { get; set; }
        public Deck Deck { get; set; }
        public List<Card> FaceUpCards { get; set; }

        public PokerTable(List<Player> players, Deck deck)
        {
            Players = players;
            Deck = deck;
            FaceUpCards = new List<Card>();
        }
    }
}
