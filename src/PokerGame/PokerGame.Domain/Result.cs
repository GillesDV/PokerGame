using System.Collections.Generic;

namespace PokerGame.Domain
{
    public class Result
    {
        public PokerHands ResultOfPoker { get; set; }
        public List<string> Names { get; set; }

        public Result()
        {
            Names = new List<string>();
        }
    }
}
