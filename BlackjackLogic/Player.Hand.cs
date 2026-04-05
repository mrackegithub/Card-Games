using System.Collections.Generic;


namespace Poker
{
   
    public partial class Player
    {
        public class Hand
        {
            public Hand(List<Cards> karte, float bet)
            {
                this.Cards = karte;
                this.bet = bet;
            }//konstruktor
            public float bet { get; set; } = 0;
            public List<Cards> Cards { get; set; } = new List<Cards>();
            
            public int getHandValue(bool isAceHigh = true)
            {
                int totalValue = 0;
                int aceCount = 0;
                foreach (var card in Cards)
                {
                    if (card.Rank == "A")
                    {
                        aceCount++;
                        totalValue += 11;
                    }
                    else
                    {
                        totalValue += card.Value(isAceHigh);
                    }
                }

                // Handle aces as 1 if needed to avoid busting
                while (totalValue > 21 && aceCount > 0)
                {
                    totalValue -= 10;
                    aceCount--;
                }
                return totalValue;
            }
        }
    }

}

