namespace PlayerQueueRoney.Models
{
    public interface IPlayerList
    {
        public List<Player> players { get; set; }
        public List<Player> allPlayers { get; set; }
        public string newPlayer { get; set; }
        public void addPlayer(Player player);
        public void nextPlayer();
        public void removePlayer(int index);
    }
}
