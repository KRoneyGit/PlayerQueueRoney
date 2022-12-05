using PlayerQueueRoney.Exceptions;

namespace PlayerQueueRoney.Models
{
    public class PlayerList : IPlayerList
    {
        public Player? toRemove { get; set; }
        public List<Player>? players { get; set; }
        public PlayerHeap? allPlayers { get; set; }
        public string? name { get; set; }

        public PlayerList()
        {
            players = new List<Player>();
            allPlayers = new PlayerHeap();
        }

        public void addPlayer(Player player)
        {
            if (player.name != null)
            {
                players.Add(player);
                if (allPlayers == null)
                {
                    allPlayers = new PlayerHeap();
                    allPlayers.add(player);
                }
                else if (!allPlayers.playerHeap.Contains(player))
                {
                    allPlayers.add(player);
                }
            }
        }

        public void nextPlayer()
        {
            if (players.Count != 0)
            {
                for (int i = 0; i < allPlayers.size; i++)
                {
                    if (allPlayers.playerHeap[i].name == players[0].name)
                    {
                        allPlayers.playerHeap[i].totalTurns++;
                        allPlayers.heapifyUp();
                        allPlayers.heapifyDown();
                    }
                }
                //int index = Array.IndexOf(allPlayers.playerHeap, players[0]);
                //allPlayers.playerHeap[index].totalTurns++;
                players.Add(players[0]);
                players.RemoveAt(0);
            }
            else
            {
                throw new QueueEmptyException();
            }
        }

        public void removePlayer(Player toRemove)
        {
            if (players.Count == 0)
            {
                throw new QueueEmptyException();
            }
            else if (!players.Contains(toRemove))
            {
                throw new NotInQueueException();
            }
            players.RemoveAt(players.IndexOf(toRemove));
        }
    }
}
