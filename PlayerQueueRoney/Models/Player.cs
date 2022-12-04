namespace PlayerQueueRoney.Models
{
    public class Player
    {
        public string name;
        public int totalTurns;

        public Player(string name)
        {
            this.name = name;
            this.totalTurns = 0;
        }
        public Player()
        {
            this.name = "";
            this.totalTurns = 0;
        }
    }
}
