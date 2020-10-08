using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGame
{
    public class Player
    {
        private readonly List<Card> cardsInHand  = new List<Card>();

        public string Name { get; set; }

        public int CardCount { get; set; }
        
        public Card PlayCard()
        {
            var card = ShowTopCard();
            return GiveTopCard(card);
        }

        private Card ShowTopCard() 
        {
            var card = cardsInHand.FirstOrDefault();
            Console.Write($"{card.Rank} of {card.Suit}");
            return card;
        }

        private Card GiveTopCard(Card card)
        {
            Console.Write($"\tLeft {cardsInHand.Count} cards\n");
            cardsInHand.Remove(card);
            CardCount = cardsInHand.Count;
            return card;
        } 
        
        public void TakeCards(Card card) 
        {
            cardsInHand.Add(card);
            CardCount = cardsInHand.Count;
        }
        
        public void TakeCards(IEnumerable<Card> gameSet)
        {
            foreach (var card in gameSet)
            {
                cardsInHand.Add(card);
            }
            CardCount = cardsInHand.Count;
        }
    
    }
}
