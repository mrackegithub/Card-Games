using System;

//popraviti resolve da sve lepo resi
namespace Poker
{
    public class Simulation
    {
        public void Dispose()
        {
            // Očisti resurse
            GC.Collect();  // Prinudi garbage collector
        }
        public int pV = 0;
        public int dV = 0;
        public string Action = "";
        
        public int wins = 0;
        public int losses = 0;
        public int draws = 0;
        public StrategyManager manager = new StrategyManager();
        public Strategy strat;
        public string mHandType = "";
        int trials = 100000;
        
        public Simulation(int playerValue, int dealerValue, string action, Strategy strats, string handType)
        {
            this.pV = playerValue;
            this.dV = dealerValue;
            this.Action = action;
            this.strat = strats;
            mHandType = handType;
        }

        private static Random _rnd = new Random();
        public void simulate(int playerValue, int dealerValue,int thisaces, string action, string HandType)
        {
            int aces = thisaces;
            int acesDealer = 0;
            acesDealer = (dealerValue == 11) ? 1 : 0;
            
            int randomValue = _rnd.Next(2, 15);//kada imamo soft hand kec se sam dodaje pa dobijemo infinite loop
            void stand()
            {
                randomValue = 0;
                while (dealerValue < 17)
                {
                    randomValue = _rnd.Next(2,15);
                    if (randomValue == 11)
                    {
                       
                        randomValue = 11;
                        acesDealer++;
                    }
                    else if (randomValue >10 )
                    {
                        randomValue = 10;
                    }
                    dealerValue += randomValue;
                    if(dealerValue > 21 && acesDealer > 0)
                    {
                        while (dealerValue > 21 && acesDealer > 0)
                        {
                            dealerValue -= 10;
                            acesDealer--;
                        }
                    }
                    
                }
                if (dealerValue > 21 || playerValue > dealerValue)
                {
                    if(action=="double")
                    {
                        wins = wins + 2;
                    }
                    wins++;
                }
                else if (playerValue == dealerValue)
                {
                    
                    draws++;

                }
                else
                {
                    if (action == "double")
                    {
                        losses = losses + 2;
                    }
                    losses++;
                }
            }
            randomValue = _rnd.Next(2,15);
            if (randomValue == 11)
            {               
                randomValue = 11;
                aces++;
            }
            else if (randomValue >10)
            {
                randomValue = 10;
            }
            if (HandType == "hard")
            {
                if (action == "stand")
                {
                    stand();
                }
                else if (action == "double")
                {
                    playerValue += randomValue;
                    if (playerValue > 21 && aces == 0)
                    {
                        losses = losses+2;
                    }
                    else if (playerValue > 21 && aces > 0)
                    {
                        while (playerValue > 21 && aces > 0)
                        {
                            playerValue -= 10;
                            aces--;
                        }
                        stand();
                    }
                    else
                    {
                        stand();
                    }

                }
                    else if (action == "hit")
                    {
                        playerValue += randomValue;
                        if (playerValue > 21 && aces == 0)
                        {
                            losses++;
                        }
                        else if (playerValue > 21 && aces > 0)
                        {
                            while (playerValue > 21 && aces > 0)
                            {
                                playerValue -= 10;
                                aces--;
                            }
                            if(playerValue > 17)
                            {
                                stand();
                            }
                            else if (strat.getBestAction("hard", playerValue, dealerValue) == "double" || strat.getBestAction("hard", playerValue, dealerValue) == "stand" || strat.getBestAction("hard", playerValue, dealerValue) == "split")
                            {
                                stand();
                            }
                            else { simulate(playerValue, dealerValue, aces,action,HandType); }
                        }
                        else if (playerValue > 17)
                        {
                            stand();
                        }
                        else
                        {
                            if (strat.getBestAction("hard", playerValue, dealerValue) == "double" || strat.getBestAction("hard", playerValue, dealerValue) == "stand")
                            {
                                stand();
                            }
                            else { simulate(playerValue, dealerValue, aces,action,HandType); }
                        }
                    }


                
            }
            else if (HandType == "soft")
            {
                aces++;//potencijalna greska u logici
                if (action == "stand")
                {
                    stand();
                }
                else if (action == "double")
                {
                    playerValue += randomValue;
                    if (playerValue > 21 && aces == 0)
                    {
                        losses++;
                    }
                    else if (playerValue > 21 && aces > 0)
                    {
                        while (playerValue > 21 && aces > 0)
                        {
                            playerValue -= 10;
                            aces--;
                        }
                        stand();
                    }
                    else
                    {
                        stand();
                    }
                }
                else if (action == "hit")
                {
                    playerValue += randomValue;
                    if (playerValue > 21 && aces == 0)
                    {
                        losses++;
                    }
                    else if (playerValue > 21 && aces > 0)
                    {
                        while (playerValue > 21 && aces > 0)
                        {
                            playerValue -= 10;
                            aces--;
                        }
                        if (aces == 0) { 
                            HandType = "hard";
                        }
                        if(playerValue > 17)
                        {
                            stand();
                        }
                        else if (strat.getBestAction("hard", playerValue, dealerValue) == "double" || strat.getBestAction("hard", playerValue, dealerValue) == "stand" || strat.getBestAction("hard", playerValue, dealerValue) == "split")
                        {
                            stand();
                        }
                        else { simulate(playerValue, dealerValue, aces, action, HandType); }
                    }
                    else if (playerValue > 17)
                    {
                        stand();
                    }
                    else
                    {
                        if (strat.getBestAction("hard", playerValue, dealerValue) == "double" || strat.getBestAction("hard", playerValue, dealerValue) == "stand")
                        {
                            stand();
                        }
                        else { simulate(playerValue, dealerValue, aces, action, HandType); }

                    }
                }


            }
            else if (HandType == "pair")
            {
                if(playerValue == 22)
                {
                    playerValue = 12;
                    aces++;
                }
                if (action == "stand")
                {
                    stand();
                }
                else if (action == "double")
                {
                    playerValue += randomValue;
                    if (playerValue > 21 && aces == 0)
                    {
                        losses++;
                    }
                    else if (playerValue > 21 && aces > 0)
                    {
                        while (playerValue > 21 && aces > 0)
                        {
                            playerValue -= 10;
                            aces--;
                        }
                        stand();
                    }
                    else
                    {
                        stand();
                    }
                }
                else if (action == "hit")
                {
                    playerValue += randomValue;
                    if (playerValue > 21 && aces == 0)
                    {
                        losses++;
                    }
                    else if (playerValue > 21 && aces > 0)
                    {
                        while (playerValue > 21 && aces > 0)
                        {
                            playerValue -= 10;
                            aces--;
                        }
                        if(playerValue > 17)
                        {
                            stand();
                        }
                        else if (strat.getBestAction("hard", playerValue, dealerValue) == "double" || strat.getBestAction("hard", playerValue, dealerValue) == "stand" || strat.getBestAction("hard", playerValue, dealerValue) == "split")
                        {
                            stand();
                        }
                        else { simulate(playerValue, dealerValue, aces, action, HandType); }
                    }
                    else if (playerValue > 17)
                    {
                        stand();
                    }
                    else
                    {
                        if (strat.getBestAction("hard", playerValue, dealerValue) == "double" || strat.getBestAction("hard", playerValue, dealerValue) == "stand")
                        {
                            stand();
                        }
                        else { simulate(playerValue, dealerValue, aces, action, HandType); }

                    }
                }
                else if (action == "split")
                {
                    playerValue = playerValue/2;

                    randomValue = _rnd.Next(2,15);
                    int aceTemp = aces;
                    if (randomValue == 11)
                    {
                        randomValue = 11;
                        aces++;
                       
                    }
                    else if (randomValue > 10)
                    {
                        
                        randomValue = 10;
                    }
                    if (randomValue == playerValue)
                    {
                        HandType = "pair";
                    }
                    else { HandType = "hard"; }
                    
                    int a = playerValue;
                    playerValue = playerValue + randomValue;
                    string bestAction = strat.getBestAction("hard", playerValue, dealerValue);
                    
                    string temp = action;
                    action = bestAction;
                    
                    simulate(playerValue, dealerValue, aces, action, HandType);
                    playerValue = a;
                    aces = aceTemp;
                    randomValue = _rnd.Next(2, 15);
                    if (randomValue == 11)
                    {
                        
                        randomValue = 11;
                        aces++;

                    }
                    
                    else if (randomValue >10)
                    {
                        randomValue = 10;
                    }
                    if (randomValue == playerValue)
                    {
                        HandType = "pair";
                    }
                    else { HandType = "hard"; }
                    playerValue = playerValue + randomValue;
                    bestAction = strat.getBestAction("hard", playerValue, dealerValue);
                    action = bestAction;
                    simulate(playerValue, dealerValue,aces, action, HandType);
                    action = temp;
                    HandType = "pair";
                }
            }


        }

        public void runSimulation()
        {
            int aces = 0;
            if(mHandType == "soft")
            {
                aces = 1;
            }
            for (int i = 0; i < trials; i++)
            {
                simulate(pV, dV, aces,Action,mHandType);
            }
        }

    }



}

