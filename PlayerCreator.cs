using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public class PlayerCreator
    {
        //private const int playerMaxCount = 10;
        //private const int playerMinCount = 2;
        
        public Player CreatePlayer(int playerIndex)
        {
            //Random random = new Random();
            //var playerCount = random.Next(playerMinCount, playerMaxCount);

            //List<Player> Players = new List<Player>();

            //for (int index = 1; index <= playerMaxCount; index++)
            //{
                Player player = new Player
                {
                    Name = "Player#" + playerIndex,
                    //PackOfCards = null
                };
            //}
            return player;
        }
    }
}
