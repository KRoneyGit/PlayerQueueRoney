using PlayerQueueRoney.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace PlayerQueueRoney.Models
{
    //PlayerList class used as model for sending player information to view
    public class PlayerList : IPlayerList
    {
        //properties
        //List<Player> for a list of current players
        //PlayerHeap for a heap of all players, even those not in queue
        //name to use as parameter for removing players from queue
        //error message to output error to user for name input
        public List<Player>? players { get; set; }
        public PlayerHeap? allPlayers { get; set; }
        public string? name { get; set; }
        public string? errorMessage { get; set; }

        //constructor for creating an empty PlayerList
        public PlayerList()
        {
            players = new List<Player>();
            allPlayers = new PlayerHeap();
        }

        //method for adding players to PlayerList
        //starts by taking the input name and changing it to have an inital uppercase letter followed by lower case
        //continues by checking if the new player that is being added has a null value in their name property
        //if it is not null, a flag variable called found is initialized to determine if the name is found in the current queue
        //if the list of players has a count of zero, the player is added with the List Add method
        //otherwise a foreach loop is made to check all players in the list
        //inside the loop a check is made to see if the player in the list has a name value
        //it also checks if the name matches the player being added
        //if it does match the found value is set to true and the loop is broken
        //after the loop a check is made to see if the player to be added was found in the list
        //if not, the player is added
        //after checking and adding a player to the list of current players found is set back to false
        //a cheeck is made to see if the first node in the playerHeap used for tracking all players is empty
        //if it is empty a new playerHeap is made and the player is added to it
        //if it is not empty a loop is created to check all players in the heap
        //inside the loop it is again checked if the player's name value is not null, and if it matches the new player's name
        //if the player is found in the all players list found is set to true and the loop is broken
        //after the loop a check is made if found is true or not, if not the player is added to the heap
        public void addPlayer(Player player)
        {
            player.name = player.name.Substring(0,1).ToUpper() + player.name.Substring(1).ToLower();
            if (player.name != null)
            {
                bool found = false;
                if (players.Count == 0)
                {
                    players.Add(player);
                }
                else
                {
                    foreach (Player p in players)
                    {
                        if (p.name != null && p.name == player.name)
                        {
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        players.Add(player);
                    }
                }
                found = false;
                if (allPlayers.playerHeap[0] == null)
                {
                    allPlayers = new PlayerHeap();
                    allPlayers.add(player);
                }
                else
                {
                    foreach (Player p in allPlayers.playerHeap)
                    {
                        if (p != null && p.name == player.name)
                        {
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        allPlayers.add(player);
                    }
                }
            }
        }

        //a method to go to the next player in queue to play
        //it starts by checking if the list of players is empty by checking the count of items in the list
        //if it is not empty a loop is created to iterate through all players in the heap used for tracking all players
        //inside the loop a check is done to compare the names of the first person on the player list to all players
        //if the name matches the totalTurns property for that player is incremented
        //then the methods to sort the heap are both called to ensure that the heap is sorted correctly
        //after the loop the player is added to the end of the list and then removed from the front of the list
        //if the players list is found to be empty, an exception is thrown instead
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
                players.Add(players[0]);
                players.RemoveAt(0);
            }
            else
            {
                throw new QueueEmptyException();
            }
        }

        //a method to remove a player from the current list of players
        //it starts by checking if the players list is empty using the count property of the List type
        //if it is empty an exception is thrown
        //otherwise a flag variable of found is created to determine if the player is currently on the list
        //a loop is then created to iterate through each player on the list
        //each player's name is compared with the parameter passed into the method to see if they match
        //if they do match the remove method of List is called to remove the player
        //next found is set to true and the loop is broken as there is no further need to iterate through it
        //finally a check is done to see if found is true, if it isn't an exception is thrown
        public void removePlayer(string toRemove)
        {
            if (players.Count == 0)
            {
                throw new QueueEmptyException();
            }
            bool found = false;
            foreach (Player player in players)
            {
                if (player.name == toRemove)
                {
                    players.Remove(player);
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                throw new NotInQueueException();
            }

        }
    }
}
