using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PokerGame.Domain.Tests
{
    [TestClass]
    public class DeckTests
    {
        [TestMethod]
        public void Given_new_Deck_Object_When_Fill_Then_Deck_has_52_cards()
        {
            Deck deck = new Deck();

            deck.FillDeck();

            Assert.AreEqual(52, deck.Cards.Count);
        }
    }
}
