
namespace CardGame
{
    public class Card
    {
        private int rate = 0;
        
        public Suit Suit { get; set; }

        public Rank Rank { get; set; }

        public Card(Suit suit, Rank rank)
        {
            Suit = suit;
            Rank = rank;
        }
        public int Rate
        {
            get 
            {
                return rate == 0 ? (rate = (int) Rank): rate; 
            } 
        }


    }
}
