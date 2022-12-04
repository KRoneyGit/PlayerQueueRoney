namespace PlayerQueueRoney.Models
{
    public class PlayerList : IPlayerList
    {
        public List<Player> players { get; set; }
        public List<Player> allPlayers { get; set; }
        public string newPlayer { get; set; }

        public void addPlayer(Player player)
        {
            players.Add(player);
            if (!allPlayers.Contains(player))
            {
                allPlayers.Add(player);
            }
        }

        public void nextPlayer()
        {
            allPlayers[allPlayers.IndexOf(players[0])].totalTurns++;
            players[0].totalTurns++;
            players.Add(players[0]);
            players.RemoveAt(0);
        }

        public void removePlayer(int index)
        {
            players.RemoveAt(index);
        }
    }
}
