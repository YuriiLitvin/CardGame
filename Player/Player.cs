using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGame
{
    public class Player
    {
        private List<Card> CardsInHand { get; set; } = new List<Card>();

        public string Name { get; set; }

        public int CardCount { get; set; }
        
        public Card PlayCard()
        {
            var card = ShowTopCard();
            return GiveTopCard(card);
        }

        private Card ShowTopCard() 
        {
            var card = CardsInHand.FirstOrDefault();
            Console.Write(card.Face);
            return card;
        }

        private Card GiveTopCard(Card card)
        {
            Console.Write($"\tLeft {CardsInHand.Count} cards\n");
            CardsInHand.Remove(card);
            CardCount = CardsInHand.Count;
            return card;
        } 
        
        public void TakeCards(Card card) 
        {
            CardsInHand.Add(card);
            CardCount = CardsInHand.Count;
        }
        
        public void TakeCards(List<Card> gameSet)
        {
            foreach (var card in gameSet)
            {
                CardsInHand.Add(card);
            }
            CardCount = CardsInHand.Count;
        }
    
    }
}
