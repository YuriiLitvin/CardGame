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
            var table = new Dictionary<Card,Player>();
            var dealer = new Dealer();
            var players = new PlayerListCreator().Players;
            var deck = new DeckCreator().Deck;
            dealer.DistributeCards(deck, players);



            for (int round = 1; round <= finalRound; round++) 
            {
                DisplayRound(round);

                foreach (var player in players)
                {
                    DisplayName(player);
                    var card = player.PlayCard();
                    
                    table.Add(card,player);
                }

                ShowCurrentWinner(table);

                RemoveLosers(players);

                table.Clear();
                
                if (round == finalRound)
                {
                    ShowMatchWinner(players);
                }
            }
            Console.ReadKey();
        }

        
        private void DisplayName(Player player)
        {
            Console.WriteLine($"\n{player.Name}");
        }

        private void DisplayRound(int round)
        {
            Console.WriteLine($"\nROUND #{round}\n");
        }
        private void ShowCurrentWinner(Dictionary<Card,Player> table)
        {
            var currentWinner = table.
                FirstOrDefault(_ => _.Key.Rate == table.Keys.Max(c => c.Rate)).Value;
            

            Console.WriteLine($"\n{currentWinner.Name} wins current game");

            currentWinner.TakeCards(table.Keys); 
        }

        private void ShowMatchWinner(List<Player> players)
        {
            var matchWinner = players.OrderByDescending(_ => _.CardsInHand.Count)
                                             .FirstOrDefault();

            Console.WriteLine($"\n{matchWinner.Name} wins this match");
        }
        
        private void RemoveLosers(List<Player> players)
        {
            foreach (var loser in players.Where(_ => _.CardsInHand.Count == 0).ToList())
            {
                players.Remove(loser);
                Console.WriteLine($"\n{loser.Name} left game");
            }
        }
    }
}
