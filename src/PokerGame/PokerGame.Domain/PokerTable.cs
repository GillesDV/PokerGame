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

        public PokerTable(List<Player> players)
        {
            Players = players;
        }
    }
}
