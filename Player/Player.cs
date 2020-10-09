using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGame
{
    public class Player
    {
        public List<Card> CardsInHand { get; set; } = new List<Card>();

        public string Name { get; set; }

        public Card PlayCard()
        {
            var card = ShowTopCard();
            return GiveCard(card);
        }

        private Card ShowTopCard() 
        {
            var card = CardsInHand.FirstOrDefault();
            Console.Write($"{card.Rank} of {card.Suit}");
            return card;
        }

        private Card GiveCard(Card card)
        {
            Console.Write($"\tLeft {CardsInHand.Count} cards\n");
            CardsInHand.Remove(card);
            return card;
        } 
        
        public void TakeCards(Card card) 
        {
            CardsInHand.Add(card);
        }
        
        public void TakeCards(IEnumerable<Card> gameSet)
        {
            foreach (var card in gameSet)
            {
                CardsInHand.Add(card);
            }
        }
    
    }
}
