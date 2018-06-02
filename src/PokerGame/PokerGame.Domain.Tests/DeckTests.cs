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
        public void Given_existing_Deck_When_Shuffle_Then_Order_of_Cards_is_Different()
        {
            Deck deckToShuffle = new Deck();
            deckToShuffle.FillDeck();

            deckToShuffle.ShuffleDeck();

            Deck deckOriginal = new Deck();
            deckOriginal.FillDeck();
            Assert.AreNotEqual(deckOriginal, deckToShuffle);
        }

        [TestMethod]
        public void Given_existing_Deck_When_DrawCards_Then_Returns_right_number_of_Cards()
        {
            Deck deck = new Deck();
            deck.FillDeck();

            const int amountOfCards = 4;
            var drawnCards = deck.DrawCards(amountOfCards);

            Assert.AreEqual(amountOfCards, drawnCards.Count);
        }

        [TestMethod]
        public void Given_existing_Deck_When_DrawCards_Then_Cards_are_out_of_Deck()
        {
            Deck deck = new Deck();
            deck.FillDeck();

            const int amountOfCards = 2;
            var expectedCardsInDeck = 52 - amountOfCards;
            var drawnCards = deck.DrawCards(amountOfCards);

            Assert.AreEqual(expectedCardsInDeck, deck.Cards.Count);
            Assert.IsFalse(deck.Cards.Contains(drawnCards[0]));
            Assert.IsFalse(deck.Cards.Contains(drawnCards[1]));
        }

    }
}
