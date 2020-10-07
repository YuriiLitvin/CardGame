using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGame
{
    public class Dealer
    {
        private readonly Random random = new Random();

        DeckCreator DeckCreator { get; set; } = new DeckCreator();
        PlayerListCreator PlayersCreator { get; set; } = new PlayerListCreator();

        public List<Card> ShuffleDeck(List<Card> deck)
        {
            var shuffledDeck = new List<Card>();

            while (shuffledDeck.Count < deck.Count)
            {
                int randomIndex = random.Next(0, deck.Count);
                if (!shuffledDeck.Contains(deck[randomIndex]))
                {
                    shuffledDeck.Add(deck[randomIndex]);
                }
            }
            return shuffledDeck;
        }
        
        public List<Player> DistributeCards()
        {
            var deck = DeckCreator.Deck;
            var shuffledDeck = ShuffleDeck(deck);
            var players = PlayersCreator.Players;

            while (shuffledDeck.Count != 0)
            {
                foreach (var player in players)
                {
                    var card = shuffledDeck.FirstOrDefault();
                    player.TakeCards(card);
                    shuffledDeck.Remove(card);
                    
                    if (shuffledDeck.Count == 0)
                    {
                        break;
                    }
                }
            }
            return players;
        }
    }
}
