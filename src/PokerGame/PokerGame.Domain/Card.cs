namespace PokerGame.Domain
{
    public class Card
    {
        public Value Value { get; set; }
        public Suit Suit { get; set; }

        public override string ToString()
        {
            return $"{Value} of {Suit}";
        }
    }
}
