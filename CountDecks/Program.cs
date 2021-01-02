using System;

namespace CountDecks
{
    class Program
    {
        static void Main(string[] args)
        {
            var Cards = new Deck();
            Cards.Add("2H");
            Console.WriteLine($"There are {Cards.CardsCounter} number of cards processed and {Cards.DecksCounter} full decks");
        }
    }
}
