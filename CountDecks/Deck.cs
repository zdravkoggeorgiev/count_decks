using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CountDecks
{
    class Deck
    {
        private string _suits;
        private string _colors;
        private Dictionary<string, int> _cards;

        public int CardsCounter { get; private set; } = 0;
        public int DecksCounter  => _cards.Select(item => item.Value).Min();

        public Deck()
        {
            // Standard set of 52 playing cards; 13 of each suit clubs, diamonds, hearts, and spades
            _suits = "A234567891JQK";
            _colors = "SHDC";
            _cards = InitializeCards(_suits, _colors);
        }

        public Deck(string suits, string colors)
        {
            _suits = suits;
            _colors = colors;
            _cards = InitializeCards(_suits, _colors);
        }

        static private Dictionary<string, int> InitializeCards(string suits, string colors)
        {
            var result = new Dictionary<string, int>();
            var i = 0;
            foreach (var color in colors)
                foreach (var suit in suits)
                    result.Add(new string(new char[] { suit, color }), 0);

            return result;
        }

        public void Add(string key)
        {
            _cards[key]++;
            CardsCounter++;
        }

        public int this[string stringIndex]
        {
            get
            {
                return _cards[stringIndex];
            }
        }
    }
}
