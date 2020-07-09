using System;

namespace CardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Game newGame = new Game();
            newGame.DistributeCards();
            //CardDeck pack = new CardDeck();
            //pack.CreatePackOfCards();
        }
    }
}
