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
        public int GamesCount = 0;

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
                throw new InvalidOperationException("The opponent's rating is too low for this game!");
            }
            this.CurrentRating += rating;
            opponent.CurrentRating -= rating;
            GamesCount++;
            var game = new Game(this, opponent, date, rating, "Victory");
            GamesList.Add(game);
        }
        public void LoseGame(GameAccount opponent, DateTime date, int rating)
        {
            if (rating < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rating), "Rating should be positive!");
            }
            if (this.CurrentRating - rating < 1)
            {
                throw new InvalidOperationException("The player's rating is too low for this game!");
            }
            this.CurrentRating -= rating;
            opponent.CurrentRating += rating;
            GamesCount++;
            var game = new Game(this, opponent, date, -rating, "Defeat");
            GamesList.Add(game);
        }
        public string GetStats()
        {
            var statistics = new System.Text.StringBuilder();
            int index = 0;
            statistics.AppendLine($"{this.UserName}'s Stats:");
            statistics.AppendLine("Date\t\tPlayer\tOpponent\tStatus\t\tRating\tGame Index");

            foreach (var game in GamesList)
            {
                index++;
                statistics.AppendLine($"{game.Date.ToShortDateString()}\t{game.Player.UserName}\t{game.Opponent.UserName}\t\t{game.Status}\t\t{game.Rating.ToString("+#;-#;0")}\t{index.ToString()}");
            }

            statistics.AppendLine($"Total Games Played: {GamesCount}");
            return statistics.ToString();
        }
    }
}
