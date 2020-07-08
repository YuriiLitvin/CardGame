using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGame
{
    class PackOfCards
    {
        //public Card Card { get; set; }
        public void CreatePackOfCards() 
        {
            List<Card> cards = new List<Card>();
            var suits = Enum.GetNames(typeof(Suit));
            var values = Enum.GetNames(typeof(Value));

            foreach (var suit in suits)
            {
                foreach (var value in values)
                {
                    cards.Add(
                    new Card()
                    {
                        FullName = $"{value} of {suit}",
                        Rate = (int) Value.Ace
                    }); 
                }
            }
            //return cards;

            foreach (var card in cards)
            {
                Console.WriteLine(card.FullName);
            }
            Console.ReadKey();
        }

    }
}
