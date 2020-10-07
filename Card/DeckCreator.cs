using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGame
{
    public class DeckCreator
    {
        public List<Card> Deck { get; set; }

        public DeckCreator()
        {
            this.Deck = this.Create();
        }
        
        public List<Card> Create() 
        {
            var deck = new List<Card>();
            
            var suits = Enum.GetNames(typeof(Suit));
            var rankTitles = Enum.GetNames(typeof(Rank));
            var rates = Enum.GetValues(typeof(Rank));

            foreach (var suit in suits)
            {
                for (int index = 0; index < rankTitles.Count(); index++)
                {
                    deck.Add( 
                    new Card()
                    {
                        Face = $"{rankTitles[index]} of {suit}",
                        Rate = (int) rates.GetValue(index)
                    }); 
                }
            }
            return deck;
        }
    }
}
