using PlayerQueueRoney.Exceptions;
using System;
using System.ComponentModel;

namespace PlayerQueueRoney.Models
{
    public class PlayerHeap
    {
        public int capacity;
        public int size = 0;
        public Player[] playerHeap;

        public PlayerHeap() 
        {
            capacity = 5;
            playerHeap = new Player[capacity];
        }

        public int getLeftChildIndex(int parentIndex)
        {
            return 2 * parentIndex + 1;
        }
        public int getRightChildIndex(int parentIndex)
        {
            return 2 * parentIndex + 2;
        }
        public int getParentIndex(int childIndex)
        {
            double child = childIndex;
            if ((child - 1) / 2 < 0)
            {
                return -1;
            }

            return (childIndex - 1) / 2;
        }

        public bool hasLeftChild(int index)
        {
            return getLeftChildIndex(index) < size;
        }
        public bool hasRightChild(int index)
        {
            return getRightChildIndex(index) < size;
        }
        public bool hasParent(int index)
        {
            return getParentIndex(index) >= 0;
        }

        public Player leftChild(int index)
        {
            if (!hasLeftChild(index))
            {
                throw new NodeNullException();
            }
            return playerHeap[getLeftChildIndex(index)];
        }
        public Player rightChild(int index)
        {
            if (!hasRightChild(index))
            {
                throw new NodeNullException();
            }
            return playerHeap[getRightChildIndex(index)];
        }
        public Player parent(int index)
        {
            if (!hasParent(index))
            {
                throw new NodeNullException();
            }
            return playerHeap[getParentIndex(index)];
        }

        public void swap(int indexOne, int indexTwo)
        {
            if (playerHeap[indexOne] == null || playerHeap[indexTwo] == null)
            {
                throw new NodeNullException();
            }
            Player temp = playerHeap[indexOne];
            playerHeap[indexOne] = playerHeap[indexTwo];
            playerHeap[indexTwo] = temp;
        }

        public void ensureExtraCapacity()
        {
            if (size == capacity)
            {
                capacity *= 2;
                Player[] temp = playerHeap;
                playerHeap = new Player[capacity];
                for (int i = 0; i < temp.Length; i++)
                {
                    playerHeap[i] = temp[i];
                }
            }
        }

        public Player peek()
        {
            if (playerHeap[0] == null)
            {
                throw new NodeNullException();
            }
            else if (size == 0)
            {
                return new Player();
            }
            return playerHeap[0];
        }

        public Player pull()
        {
            if (playerHeap[0] == null)
            {
                throw new NodeNullException();
            }
            else if (size == 0)
            {
                return new Player();
            }
            Player player = playerHeap[0];
            playerHeap[0] = playerHeap[--size];
            heapifyDown();
            return player;
        }

        public void add(Player player)
        {
            ensureExtraCapacity();
            playerHeap[size] = player;
            size++;
            heapifyUp();
        }

        public void heapifyUp()
        {
            int index = size - 1;
            while (hasParent(index) && parent(index).totalTurns < playerHeap[index].totalTurns)
            {
                swap(getParentIndex(index), index);
                index = getParentIndex(index);
            }
        }

        public void heapifyDown()
        {
            int index = 0;
            while (hasLeftChild(index))
            {
                int smallerChildIndex = getLeftChildIndex(index);
                if (hasRightChild(index) && rightChild(index).totalTurns > leftChild(index).totalTurns)
                {
                    smallerChildIndex = getRightChildIndex(index);
                }

                if (playerHeap[index].totalTurns > playerHeap[smallerChildIndex].totalTurns)
                {
                    break;
                }
                else
                {
                    swap(index, smallerChildIndex);
                    index = smallerChildIndex;
                }
            }
        }

        public Player[] heapSort()
        {
            if (playerHeap[0] == null)
            {
                throw new NodeNullException();
            }
            Player[] sorted = new Player[size];
            int index = 0;
            while (size > 0)
            {
                sorted[index] = this.pull();
                index++;
            }
            return sorted;
        }
    }
}
