namespace PlayerQueueRoney.Models
{
    public interface IPlayerList
    {
        public Player toRemove { get; set; }
        public List<Player> players { get; set; }
        public PlayerHeap allPlayers { get; set; }
        public string name { get; set; }
        public void addPlayer(Player player);
        public void nextPlayer();
        public void removePlayer(Player toRemove);
    }
}
