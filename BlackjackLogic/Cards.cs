
namespace Poker
{
    public class Cards
    {
        public string Rank { get; set; }
        public string CardSuit { get; set; }
        public Cards(string cardRank, string cardSuit)
        {
            this.Rank = cardRank;
            this.CardSuit = cardSuit;
        }
        public int Value(bool isAceHigh)
        {
            if (Rank == "A")
            {
                return isAceHigh ? 11 : 1;
            }
            else if (Rank == "K" || Rank == "Q" || Rank == "J")
            {
                return 10;
            }
            else
            {
                return int.Parse(Rank);
            }
        }

    }



}

