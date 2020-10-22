using System;
using System.Collections.Generic;
using System.Linq;

namespace PuttingLeague.Models
{
    public class Match
    {
        public int Week { get; set; }
        public DateTime DatePlayed { get; set; }
        public int Player1Id { get; set; }
        public int Player2Id { get; set; }
        public List<Round> Rounds { get; set; }
        public int Player1Score
        {
            get
            {
                return Rounds.Sum(r => r.Player1Score);
            }
        }
        public int Player1PuttsMade
        {
            get
            {
                return Rounds.Sum(r => r.Player1PuttsMade);
            }
        }
        public int Player2Score
        {
            get
            {
                return Rounds.Sum(r => r.Player2Score);
            }
        }
        public int Player2PuttsMade
        {
            get
            {
                return Rounds.Sum(r => r.Player2PuttsMade);
            }
        }

        public Match()
        {
            Rounds = new List<Round>();
        }
    }
}
