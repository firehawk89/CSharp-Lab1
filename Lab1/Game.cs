using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class Game
    {
        public GameAccount Player { get; }
        public GameAccount Opponent { get; }
        public DateTime Date { get; }
        public int Rating { get; }
        public string Status { get; }
        public int ID { get; }

        private static int gameID = 31201;

        public enum StatusList
        {
            Victory,
            Defeat
        }

        public Game(GameAccount Player, GameAccount Opponent, DateTime Date, int Rating, string Status)
        {
            this.Player = Player;
            this.Opponent = Opponent;
            this.Date = Date;
            this.Rating = Rating;
            this.Status = Status;
            ID = gameID;
            gameID++;
        }
    }
}
