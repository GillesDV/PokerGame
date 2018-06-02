using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PokerGame.Domain.Tests
{
    [TestClass]
    public class DeckTests
    {
        [TestMethod]
        public void Given_new_Deck_When_Fill_Then_Deck_has_52_cards()
        {
            Deck deck = new Deck();

            deck.FillDeck();

            Assert.AreEqual(52, deck.Cards.Count);
        }

        [TestMethod]
        {
            Deck deck = new Deck();
            deck.FillDeck();

            deck.ShuffleDeck();

            Deck deckOriginal = new Deck();
            deckOriginal.FillDeck();
            Assert.AreNotEqual(deckOriginal, deck);
        }
    }
}
