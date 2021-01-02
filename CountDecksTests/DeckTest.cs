using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using CountDecks;
using System.Linq;

namespace CountDecksTests
{
    [TestClass]
    public class DeckTest
    {
        private const string _allSuits = "A234567891JQK";
        private const string _AllColors = "SHDC";

        [TestMethod]
        public void Single_Card_Is_Zero_Decks()
        {
            var deck = new Deck();

            deck.Add("QC");

            Assert.AreEqual(1, deck.CardsCounter);
            Assert.AreEqual(0, deck.DecksCounter);
        }

        [TestMethod]
        public void A_Deck_And_Extra_Card()
        {
            var deck = new Deck();
            _AllColors.SelectMany(c => _allSuits, (c, s) =>
                        new string(new char[] { s, c }))
                .ToList()
                .ForEach(a => deck.Add(a));

            deck.Add("QC");

            Assert.AreEqual(53, deck.CardsCounter);
            Assert.AreEqual(1, deck.DecksCounter);
            Assert.AreEqual(2, deck["QC"]); // only "QC" should have duplicate
        }

        [TestMethod]
        public void With_Many_Cards_Should_Be_Fast()
        {
            var deck = new Deck();
            var generatedCards = PseudoRandomGenerator();

            foreach (var card in generatedCards)
                deck.Add(card);

            Assert.AreEqual(generatedCards.Length, deck.CardsCounter);
            Assert.AreEqual(9834, deck.DecksCounter);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException), "The given key 'not_existing' was not present in the dictionary.")]
        public void Not_Existing_Should_Throw()
        {
            var deck = new Deck();

            deck.Add("not_existing");
        }

        private string[] PseudoRandomGenerator()
        {
            var size = _allSuits.Length * _AllColors.Length * 1000 * 10;
            var arr = new string[size];

            Random rnd = new Random(1000);
            for (int i = 0; i < size; i++)
            {
                var suit = rnd.Next() % _allSuits.Length;
                var color = rnd.Next() % _AllColors.Length;
                arr[i] = new string(new char[] { _allSuits[suit], _AllColors[color] });
            }

            return arr;
        }
    }
}
