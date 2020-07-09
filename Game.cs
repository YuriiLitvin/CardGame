using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGame
{
    class Game
    {

        readonly Random random = new Random();
        public PlayerCreator Creator { get; set; }
        public List<Card> PackOfCards { get; set; }

        public void Start()
        {
            
        }
       
        private List<Player> CreateList()
        {
            int playerMinCount = 2;
            int playerMaxCount = 10;
            var playerCount = random.Next(playerMinCount, playerMaxCount);

            var creator = new PlayerCreator();

            List<Player> Players = new List<Player>();

            for (int index = 1; index <= playerCount; index++)
            {
                Players.Add(creator.CreatePlayer(index));
            }
            return Players;
        }

        private List<Card> ShuffleCardDeck(List<Card> cardDeck)
        {
            List<Card> shuffledDeck = new List<Card>();
            
            while (shuffledDeck.Count < cardDeck.Count)
            {
                int randomIndex = random.Next(0, cardDeck.Count);
                if (!shuffledDeck.Contains(cardDeck[randomIndex]))
                {
                    shuffledDeck.Add(cardDeck[randomIndex]);
                }
            }
            return shuffledDeck;
        }
        
        public void DistributeCards()
        {
            CardDeck newDeck = new CardDeck();
            var deck = newDeck.CreateCardDeck();
            var shuffledDeck = ShuffleCardDeck(deck);
            var players = CreateList();

            while (shuffledDeck.Count != 0)
            {
                foreach (var player in players)
                {
                    var card = shuffledDeck.First();
                    player.PackOfCards.Add(card);
                    shuffledDeck.Remove(card);
                    if (shuffledDeck.Count == 0)
                    {
                        break;
                    }
                
                }

            }
            foreach (var player in players)
            {
                Console.WriteLine(player.Name);
                foreach (var card in player.PackOfCards)
                {
                    Console.WriteLine(card.FullName + " " + card.Rate);
                }
            }
            Console.ReadKey();
        
        }
    }   
   
}
