namespace PuttingLeague.Models
{
    public class Round
    {
        public int Id { get; set; }
        public int Player1PuttsMade { get; set; }
        public int Player2PuttsMade { get; set; }
        public int Player1Score
        {
            get
            {
                return Player1PuttsMade == 2 ? 3 : Player1PuttsMade;
            }
        }
        public int Player2Score
        {
            get
            {
                return Player2PuttsMade == 2 ? 3 : Player2PuttsMade;
            }
        }
    }
}
