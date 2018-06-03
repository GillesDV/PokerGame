using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
