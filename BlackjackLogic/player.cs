using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Poker
{
   
    public partial class Player
    {
        public string Name { get; set; }
        public float Balance { get ; set;  }//enkapsulirano
        public bool hasBlackjack { get; set; } = false;
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

