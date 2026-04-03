using System;
using System.Collections.Generic;

//popraviti resolve da sve lepo resi
namespace Poker
{
    public class Deck
    {
        public int numberOfDecks { get; set; }
        public List<Cards> CardsAll { get; set; } = new List<Cards>();
        public Deck(int numberOfDecks)
        {
            string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
            this.numberOfDecks = numberOfDecks;
            for (int i = 0; i< numberOfDecks; i++)
            {
                foreach (string rank in ranks)
                {
                    foreach (string suit in suits)
                    {
                        CardsAll.Add(new Cards(rank, suit));
                    }
                }
            }
        }
        public List<Cards> UsedCards { get; set; } = new List<Cards>();
        public void Shuffle()
        {
            Random rand = new Random();
            for (int i = CardsAll.Count - 1; i > 0; i--)
            {
                int j = rand.Next(0, i + 1);
                var temp = CardsAll[i];
                CardsAll[i] = CardsAll[j];
                CardsAll[j] = temp;
            }
        }//fiser yates algoritam
        public void Deal(Player player)
        {
            if (CardsAll.Count < 51)
            {
                for (int i = 0; i < UsedCards.Count; i++)
                {
                    CardsAll.Add(UsedCards[i]);
                    UsedCards.RemoveAt(i);
                }
            }
            player.Hands[player.currentHand].Cards.Add(CardsAll[0]);
            UsedCards.Add(CardsAll[0]);
            CardsAll.RemoveAt(0);
        }
        
        
        public void clearPlayer(Player player)
        {
            
                for (int i = 0; i<player.Hands.Count; i++)
                {
                    for (int j = 0; j<player.Hands[i].Cards.Count; j++)
                    {
                        UsedCards.Add(player.Hands[i].Cards[j]);
                    }
                }
                player.Hands.Clear();
            
                
        }
    }



}

