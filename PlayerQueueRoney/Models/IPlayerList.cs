namespace PlayerQueueRoney.Models
{
    //interface class for PlayerListClass
    public interface IPlayerList
    {
        public List<Player> players { get; set; }
        public PlayerHeap allPlayers { get; set; }
        public string name { get; set; }
        public string errorMessage { get; set; }
        public void addPlayer(Player player);
        public void nextPlayer();
        public void removePlayer(string toRemove);
    }
}
