using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGame
{
    public class Match
    {
        private readonly int finalRound = 25;

        public void Start()
        {
            var currentGame = new Dictionary<Card,Player>();
            var dealer = new Dealer();
            var players = dealer.DistributeCards();
       
            
            
            for (int round = 1; round <= finalRound; round++) 
            {
                Console.WriteLine($"\nROUND #{round}\n");

                foreach (var player in players)
                {
                    DisplayName(player);
                    var card = player.PlayCard();
                    
                    currentGame.Add(card,player);
                    
                }

                GetCurrentWinner(currentGame);

                RemoveLoser(players);

                currentGame.Clear();
                
                if (round == finalRound)
                {
                    GetMatchWinner(players);
                }
            }
            Console.ReadKey();
        }

        
        private void DisplayName(Player player)
        {
            Console.WriteLine($"\n{player.Name}");
        }

        private void GetCurrentWinner(Dictionary<Card,Player> currentGame)
        {
            var winCard = currentGame.Select(_ => _.Key)
                                         .OrderByDescending(c => c.Rate)
                                         .FirstOrDefault();

            var currentWinner = currentGame.Where(pair => pair.Key == winCard)
                                           .Select(pair => pair.Value)
                                           .FirstOrDefault();

            Console.WriteLine($"\n{currentWinner.Name} wins current game");

            currentWinner.TakeCards(currentGame.Select(_ => _.Key).ToList());
        }

        private void GetMatchWinner(List<Player> players)
        {
            var matchWinner = players.OrderByDescending(_ => _.CardCount)
                                             .FirstOrDefault();

            Console.WriteLine($"\n{matchWinner.Name} wins this match");
        }
        
        private void RemoveLoser(List<Player> players)
        {
            if (players.Any(_ => _.CardCount == 0))
            {
                var losers = players.Where(_ => _.CardCount == 0)
                                             .Select(_ => _)
                                             .ToList();

                foreach (var loser in losers)
                {
                    players.Remove(loser);
                    Console.WriteLine($"{loser.Name} left game");
                }
            }
        }
       
        
        
    }
}
