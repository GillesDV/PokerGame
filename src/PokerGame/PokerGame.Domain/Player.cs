using System.Collections.Generic;

namespace PokerGame.Domain
{
    public class Player
    {
        public string Name { get; set; }
        public List<Card> Cards { get; set; }

        public Player(string name)
        {
            Cards = new List<Card>();
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
