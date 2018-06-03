using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
