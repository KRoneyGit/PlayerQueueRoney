namespace PlayerQueueRoney.Models
{
    public class PlayerQueue : IPlayerQueue
    {
        public string name { get; set; }

        public Player? newPlayer { get; set; }
        public Player[] queue { get; set; }

        public List<Player> allPlayers { get; set; }

        public int head { get; set; }
        public int tail { get; set; }
        public int size { get; set; }


        public PlayerQueue()
        {
            size = 0;
            head = -1;
            tail = -1;

            queue = new Player[10];
            allPlayers = new List<Player>();
        }

        public bool isFull()
        {
            if (tail == head - 1) return true;
            else if (tail == queue.Length - 1 && head == 0) return true;
            else return false;
        }

        public bool isEmpty()
        {
            return size == 0;
        }

        public void addPlayer(Player player)
        {
            if (isEmpty())
            {
                queue[++head] = player;
                tail++;
                size++;
            }
            else if (!isFull())
            {
                tail = ++tail % queue.Length;
                queue[tail] = player;
                size++;
            }
            else if (isFull())
            {
                Player[] temp = new Player[queue.Length + 1];
                if (head == 0)
                {
                    for (int i = 0; i < queue.Length; i++)
                    {
                        temp[i] = queue[i];
                    }
                }
                else
                {
                    for (int i = 0; i < tail; i++)
                    {
                        temp[i] = queue[i];
                    }
                    for (int i = head; i < queue.Length; i++)
                    {
                        temp[i + 1] = queue[i];
                    }
                }
                head++;
                queue = temp;
                queue[++tail % queue.Length] = player;
                size++;
            }
            string[] currentPlayers = new string[allPlayers.Count];
            for (int i = 0; i < allPlayers.Count; i++)
            {
                currentPlayers[i] = allPlayers[i].name;
            }
            if (!currentPlayers.Contains(player.name))
            {
                allPlayers.Add(player);
            }
        }

        public void nextPlayer()
        {
            addPlayer(queue[head]);
            allPlayers.RemoveAt(allPlayers.IndexOf(queue[head]));
            queue[head].totalTurns++;
            allPlayers.Add(queue[head]);
            size--;
            head = ++head % queue.Length;
        }

        public Player peek()
        {
            return queue[head];
        }

        public void removePlayer()
        {
            head = ++head % queue.Length;
            size--;

            if (isEmpty())
            {
                head = -1;
                tail = -1;
            }
        }

        public List<Player> currentQueue()
        {
            List<Player> currentOrder = new List<Player>();
            if (isEmpty())
            {
                Player empty = new Player("");
                currentOrder.Add(empty);
            }
            else if (head == 0)
            {
                for (int i = 0; i <= tail; i++)
                {
                    currentOrder.Add(queue[i]);
                }
            }
            else
            {
                for (int i = head; i < queue.Length; i++)
                {
                    currentOrder.Add(queue[i]);
                }
                for (int i = 0; i < tail; i++)
                {
                    currentOrder.Add(queue[i]);
                }
            }
            return currentOrder;
        }
    }
}
