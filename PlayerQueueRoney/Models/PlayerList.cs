﻿namespace PlayerQueueRoney.Models
{
    public class PlayerList : IPlayerList
    {
        public Player? toRemove { get; set; }
        public List<Player>? players { get; set; }
        public List<Player>? allPlayers { get; set; }
        public string? name { get; set; }

        public PlayerList()
        {
            players = new List<Player>();
        }

        public void addPlayer(Player player)
        {
            players.Add(player);
            if (allPlayers == null)
            {
                allPlayers = new List<Player>();
                allPlayers.Add(player);
            }
            else if (!allPlayers.Contains(player))
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

        public void removePlayer(Player toRemove)
        {
            
            players.RemoveAt(players.IndexOf(toRemove));
        }
    }
}
