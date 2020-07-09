using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGame
{
    class CardDeck
    {
        public Card Card { get; set; }
        public List<Card> CreateCardDeck() 
        {
            List<Card> cards = new List<Card>();
            var suits = Enum.GetNames(typeof(Suit));
            var names = Enum.GetNames(typeof(Value));
            var values = Enum.GetValues(typeof(Value));

            foreach (var suit in suits)
            {
                for (int index = 0; index < names.Count(); index++)
                {
                    cards.Add(
                    new Card()
                    {
                        FullName = $"{names[index]} of {suit}",
                        Rate = (int) values.GetValue(index)
                    }); 
                }
            }
            return cards;

            //foreach (var card in cards)
            //{
            //    Console.WriteLine(card.FullName + " " + card.Rate);
            //}
            //Console.ReadKey();
        }

    }
}
