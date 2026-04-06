using System;
using System.Collections.Generic;


namespace Poker
{
    public class BlackjackGame : Game
    {
        public List<Player> broke { get; set; } = new List<Player>();
        public BlackjackDealer dealer { get; set; }
        public BlackjackGame(List<Player> players, int numberOfDecks, BlackjackDealer dealer) : base(players, numberOfDecks)
        {
            this.dealer = dealer;
        }
        public void start1()
        {
            currentPlayer = 0;
            foreach (var player in Players)
            {
                GameDeck.clearPlayer(player);
                player.currentHand = 0;
                Player.Hand newHand = new Player.Hand(new List<Cards>(), 0);
                player.Hands.Add(newHand);
                player.hasBlackjack = false;
            }
            GameDeck.Shuffle();
            dealer.Hands.Clear();
            DealDealerCards();

            currentPlayer = 0;
        }
        public bool isRoundOver()
        {
            return currentPlayer >= Players.Count;
        }
        public void resolveRound()
        {
            DealerPlay();
            int dealerValue = dealer.Hands[0].getHandValue();
            foreach(var player in Players)
            {
                if (!player.hasBlackjack && !dealer.hasBlackjack)
                {
                    for (int i = 0; i < player.Hands.Count; i++)
                    {
                        int playerValue = (player as Player).Hands[i].getHandValue();
                        if (playerValue > 21)
                        {
                            player.Hands[i].bet = 0;

                        }
                        else if (dealerValue > 21)
                        {
                            player.Balance += player.Hands[i].bet * 2;
                            player.Hands[i].bet = 0;

                        }
                        else if (playerValue > dealerValue)
                        {
                            player.Balance += player.Hands[i].bet * 2;
                            player.Hands[i].bet = 0;

                        }
                        else if (playerValue == dealerValue)
                        {
                            player.Balance += player.Hands[i].bet;
                            player.Hands[i].bet = 0;

                        }
                        else
                        {
                            player.Hands[i].bet = 0;

                        }
                        if (player.Balance <= 0)
                        {
                            broke.Add(player as Player);

                        }
                    }
                    foreach (var hand in player.Hands)
                    {
                        hand.bet = 0;
                    }
                } 
                else if(player.hasBlackjack && !dealer.hasBlackjack)
                {
                    
                    player.Balance += player.Hands[0].bet * 1.5f;
                    player.Hands[0].bet = 0;


                }
                else if(!player.hasBlackjack && dealer.hasBlackjack)
                {
                    for (int i = 0; i < player.Hands.Count; i++)
                    {
                        player.Hands[0].bet = 0;
                    }
                }
                else
                {
                    player.Balance += player.Hands[0].bet;
                    player.Hands[0].bet = 0;
                }
            }
            foreach(var player in broke)
            {
                Players.Remove(player);
            }
           
            
        }
        public bool checkblackjack(Player player)
        {
            if (player.Hands[0].getHandValue() == 21)
            {
                player.hasBlackjack = true;//možda nepotrebno al ostaviću
                return true;
            }
            else
            {
                return false;
            }
        }

        
        public void DealInitialCards()
        {

            foreach (var player in Players)
            {
                player.hasBlackjack = false;
                dealer.hasBlackjack = false;
                GameDeck.Deal(player);
                GameDeck.Deal(player);
                finishBlackjack();
            }
        }
        public void DealDealerCards()
        {
            Player.Hand newHand = new Player.Hand(new List<Cards>(), 0);
            dealer.Hands.Add(newHand);
            GameDeck.Deal(dealer);
            GameDeck.Deal(dealer);
        }
        public void DealerPlay()
        {
            while (dealer.Hands[0].getHandValue() < 17)
            {
                GameDeck.Deal(dealer);
            }
        }
        public void Split()
        {
            Player player = Players[currentPlayer ] as Player;
            int handNum = player.currentHand;
            if ((player.Hands[handNum].Cards.Count== 2)&&(player.Hands[handNum].Cards[0].Rank == player.Hands[handNum].Cards[1].Rank))
            {

                Cards temp = player.Hands[handNum].Cards[1];
                player.Hands[handNum].Cards.RemoveAt(1);
                List<Cards> temp2 = new List<Cards> { temp }; 
                Player.Hand newHand = new Player.Hand(temp2, player.Hands[player.currentHand].bet);
                player.Balance -= player.Hands[player.currentHand].bet; //deduct bet for new hand
                player.Hands.Add(newHand);
                
                GameDeck.Deal(player);
                player.currentHand++; //have to do this as the deal functions only affects current hand
                GameDeck.Deal(player);
                player.currentHand--;
                
            }
            else { }
        }
        public void Hit()
        {
            Player player = Players[currentPlayer ];
            GameDeck.Deal(player);
            if (player.Hands[player.currentHand].getHandValue()>21)
            {
                dealer.Balance += player.Hands[player.currentHand].bet; 
                player.Hands[player.currentHand].bet = 0;
                player.currentHand++;
                if (player.IsDone())
                {
                    currentPlayer++;
                    //if (isRoundOver())
                    //{
                    //    resolveRound();
                        
                    //}
                    
                }

            }
        }
        public void Stand()
        {
            Player player = Players[currentPlayer];
            player.currentHand++;
            if (player.IsDone())
            {
                currentPlayer++;
                //if (isRoundOver())
                //{
                //    resolveRound();
                //}
                
            }
           // player.currentHand--;
        }
        public void DoubleDown()
        {
            Player player = Players[currentPlayer ];
            if (player.Balance >= player.Hands[player.currentHand].bet)
            {
                player.Hands[player.currentHand].bet *= 2;
                player.Balance -= player.Hands[player.currentHand].bet/2;
                
                GameDeck.Deal(player);
                if (player.Hands[player.currentHand].getHandValue()>21)
                {
                    dealer.Balance += player.Hands[player.currentHand].bet;
                    player.Hands[player.currentHand].bet = 0;
                    player.currentHand++;
                    if (player.IsDone())
                    {
                        currentPlayer++;
                    }
                }
                else
                {
                    Stand();
                }
                    
            }
            else
            {
                throw new Exception("Insufficient balance to double down.");
            }

        }
        public void finishBlackjack() 
        {
            if(checkblackjack(Players[currentPlayer])||checkblackjack(dealer))
            {
                currentPlayer++;
                Players[currentPlayer-1].currentHand++;
                if (isRoundOver())
                {
                    resolveRound();
                }
            }

        }
    }
}

