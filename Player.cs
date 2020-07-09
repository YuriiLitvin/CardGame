using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public class Player
    {
        public string Name { get; set; }
        public List<Card> PackOfCards { get; set; } = new List<Card>();
        
        public void GetBottomCard() { }

        public void TakeCards() { }

    }
}
