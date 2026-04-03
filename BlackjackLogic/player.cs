using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//popraviti resolve da sve lepo resi
namespace Poker
{
   
    public class Player
    {
        public string Name { get; set; }
        public float Balance { get ; set;   }//enkapsulirano
        
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
        public Player(string name, float balance)
        {
            this.Name = name;
            this.Balance = balance;
        }//konstruktor
        public List<Hand> Hands { get; set; } = new List<Hand>();
        public int currentHand { get; set; } = 0;
        public bool IsDone()
        {
            return currentHand >= Hands.Count;
        }
        public void PlaceBet(float amount)
        {
            if (amount <= Balance)
            {
                Hands[currentHand].bet = amount;
                Balance -= amount;

            }
            else
            {
                throw new Exception("Insufficient balance to place bet.");
            }
        }
    }



}

