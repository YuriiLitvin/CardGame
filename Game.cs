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
            var game = new List<Card>();
            var playersWithCards = DistributeCards();
            var roundIndex = 1;
            while (playersWithCards.Count > 1) 
            {
                Console.WriteLine("\nROUND" + roundIndex);

                if (playersWithCards.Any(_ => _.PackOfCards.Count == 0))
                {
                    var losers = playersWithCards.Where(_ => _.PackOfCards.Count == 0)
                                                 .Select(_ => _)
                                                 .ToList();
                    
                    foreach (var loser in losers)
                    {
                        playersWithCards.Remove(loser);
                        Console.WriteLine($"{loser.Name} left game");
                    }
                }

                foreach (var player in playersWithCards)
                {
                    Console.Write(player.Name + "  ");
                    var card = player.PackOfCards.First();
                    Console.Write(card.FullName + "  ");
                    Console.WriteLine($"Cards left {player.PackOfCards.Count}");
                    game.Add(card);
                    player.PackOfCards.Remove(card);
                    
                }
                
                roundIndex++;

                var winCardRate = game.Max(_ => _.Rate);
                var winCardIndex = game.FindIndex(_ => _.Rate == winCardRate);

                var winner = playersWithCards[winCardIndex];
                Console.WriteLine($"\n{winner.Name} win");
                playersWithCards[winCardIndex].PackOfCards = winner.PackOfCards.Concat(game).ToList();
                game.Clear();
                Console.ReadKey();
            }
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
        
        public List<Player> DistributeCards()
        {
            CardDeck newDeck = new CardDeck();
            var deck = newDeck.CreateCardDeck();
            var shuffledDeck = ShuffleCardDeck(deck);
            var playersWithCards = CreateList();

            while (shuffledDeck.Count != 0)
            {
                foreach (var player in playersWithCards)
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
            //foreach (var player in playersWithCards)
            //{
            //    Console.WriteLine(player.Name);
            //    foreach (var card in player.PackOfCards)
            //    {
            //        Console.WriteLine(card.FullName + " " + card.Rate);
            //    }
            //}
            //Console.ReadKey();
            return playersWithCards;
        }
    }   
   
}
