using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public class Card
    {
        public Suit Suit { get; }

        public Value Value { get; }

        public string FullName { get; set; }
        
        public int Rate { get; set; }
    }
}
