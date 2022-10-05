using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class Game
    {
        public string Player { get; }
        public string Opponent { get;  }
        public DateTime Date { get;  }
        public int Rating { get; }


        public Game(string Player, string Opponent, DateTime Date, int Rating)
        {
            this.Player = Player;
            this.Opponent = Opponent;
            this.Date = Date;
            this.Rating = Rating;
        }
    }
}
