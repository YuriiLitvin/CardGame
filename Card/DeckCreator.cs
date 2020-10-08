using System;
using System.Collections.Generic;

namespace CardGame
{
    public class DeckCreator
    {
        public List<Card> Deck { get; set; }
        
        public DeckCreator()
        {
            this.Deck = this.Create(); 
        }

        private List<Card> Create()
        {
            var deck = new List<Card>();

            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    deck.Add(new Card(suit, rank));
                }
            }
            return deck;
        }
    }
}
