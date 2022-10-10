using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Lab1
{
    public class GameAccount
    {
        public string UserName { get; set; }
        public int CurrentRating { get; private set; }

        public static int GamesCount = 0;
        public int StartRating = 10;

        private List<Game> GamesList = new List<Game>();

        public GameAccount(string UserName)
        {
            this.UserName = UserName;
            CurrentRating = StartRating;
        }

        public void WinGame(GameAccount opponent, DateTime date, int rating)
        {
            if (rating < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rating), "Rating should be positive!");
            }
            if (opponent.CurrentRating - rating < 1)
            {
                opponent.CurrentRating = 1;
            }
            else 
            { 
                opponent.CurrentRating -= rating; 
            }
            this.CurrentRating += rating;
            GamesCount++;
            var playerGame = new Game(this, opponent, date, rating, "Victory");
            var opponentGame = new Game(opponent, this, date, -rating, "Defeat");
            this.GamesList.Add(playerGame);
            opponent.GamesList.Add(opponentGame);
        }
        public void LoseGame(GameAccount opponent, DateTime date, int rating)
        {
            if (rating < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rating), "Rating should be positive!");
            }
            if (this.CurrentRating - rating < 1)
            {
                this.CurrentRating = 1;
            }
            else
            {
                this.CurrentRating -= rating;
            }
            opponent.CurrentRating += rating;
            GamesCount++;
            var playerGame = new Game(this, opponent, date, -rating, "Defeat");
            var opponentGame = new Game(opponent, this, date, rating, "Victory");
            this.GamesList.Add(playerGame);
            opponent.GamesList.Add(opponentGame);
        }
        public string GetStats()
        {
            var statistics = new System.Text.StringBuilder();
            statistics.AppendLine($"{this.UserName}'s Stats:");
            statistics.AppendLine("Date\t\tPlayer\tOpponent\tStatus\t\tRating\tGame ID");

            foreach (var game in this.GamesList)
            {
                statistics.AppendLine($"{game.Date.ToShortDateString()}\t{game.Player.UserName}\t{game.Opponent.UserName}\t\t{game.Status}\t\t{game.Rating.ToString("+#;-#;0")}\t{game.ID}");
            }

            //statistics.AppendLine($"Total Games Played: {GamesCount}");
            return statistics.ToString();
        }
    }
}
