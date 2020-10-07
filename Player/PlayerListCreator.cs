using System;
using System.Collections.Generic;


namespace CardGame
{
    public class PlayerListCreator
    {
        private readonly int playerMinCount = 2;
        private readonly int playerMaxCount = 10;

        private readonly Random random = new Random();

        public List<Player> Players { get; set; }
        
        public PlayerListCreator()
        {
            this.Players = this.Create();
        }
        private List<Player> Create()
        {
            var playerCount = random.Next(playerMinCount, playerMaxCount);

            var players = new List<Player>();

            for (int index = 1; index <= playerCount; index++)
            {
                players.Add( 
                    new Player 
                    {
                        Name = "Player#" + index
                    });
            }
            return players;
        }
        
    }
   

}
