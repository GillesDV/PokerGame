using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame.Domain
{
    public class Deck
    {
        public List<Card> Cards { get; set; }

        public Deck()
        {
            Cards = new List<Card>();
        }

        public void FillDeck()
        {
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Value value in Enum.GetValues(typeof(Value)))
                {
                    Cards.Add(new Card
                    {
                        Suit = suit,
                        Value = value
                    });
                }
            }
        }

        public void ResetDeck()
        {
            Cards = new List<Card>();
            FillDeck();
        }

        public void ShuffleDeck()
        {
            Random rng = new Random();

            int counter = Cards.Count;
            while (counter > 1)
            {
                counter--;
                int k = rng.Next(counter + 1);
                var valueToSwap = Cards[k];
                Cards[k] = Cards[counter];
                Cards[counter] = valueToSwap;
            }
        }
    }
}
