namespace PlayerQueueRoney.Models
{
    public interface IPlayerQueue
    {
        public string name { get; set; }
        public Player? newPlayer { get; set; }
        public Player[] queue { get; set; }

        public List<Player> allPlayers { get; set; }

        public int head { get; set; }
        public int tail { get; set; }
        public int size { get; set; }

        public bool isFull();

        public bool isEmpty();

        public void addPlayer(Player player);

        public void nextPlayer();

        public Player peek();

        public void removePlayer();

        public List<Player> currentQueue();
    }
}
