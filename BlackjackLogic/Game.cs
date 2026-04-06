using System.Collections.Generic;


namespace Poker
{
    public class Game
    {
        public int currentPlayer { get; set; } = 0;
        public List<Player> Players { get; set; } = new List<Player>();
        public Deck GameDeck { get; set; }
        public int NumberOfDecks { get; set; }
        public Game(List<Player> players, int numberOfDecks)
        {
            this.Players=players;
            this.NumberOfDecks = numberOfDecks;
            GameDeck = new Deck(numberOfDecks);
            GameDeck.Shuffle();
            currentPlayer = 0;
        }
    }
}

