using PlayerQueueRoney.Exceptions;
using System;
using System.ComponentModel;

namespace PlayerQueueRoney.Models
{
    //PlayerHeap class for sorting players based on total turns at game
    public class PlayerHeap
    {
        //properties for heap capacity, size, and data type of Player
        public int capacity;
        public int size = 0;
        public Player[] playerHeap;

        //constructor to set initial size of heap to 5, this is increased as needed
        public PlayerHeap() 
        {
            capacity = 5;
            playerHeap = new Player[capacity];
        }

        //method to find left child of current node
        public int getLeftChildIndex(int parentIndex)
        {
            return 2 * parentIndex + 1;
        }

        //method to find right child of current node
        public int getRightChildIndex(int parentIndex)
        {
            return 2 * parentIndex + 2;
        }

        //method to find parent of current node
        public int getParentIndex(int childIndex)
        {
            //due to integer rounding in C#, this conditional statement was needed in as a double
            //otherwise the math and integer rounding would result in index 0 (root) having a parent of index 0
            double child = childIndex;
            if ((child - 1) / 2 < 0)
            {
                return -1;
            }

            return (childIndex - 1) / 2;
        }

        //method to determine if current node has a left child by using method above and comparing to heap size
        public bool hasLeftChild(int index)
        {
            return getLeftChildIndex(index) < size;
        }

        //method to determine if current node has a right child by using method above and comparing to heap size
        public bool hasRightChild(int index)
        {
            return getRightChildIndex(index) < size;
        }

        //method to determine if current node has a parent by using method above and comparing to heap size
        public bool hasParent(int index)
        {
            return getParentIndex(index) >= 0;
        }

        //method for retrieving left child, using method above to check if child exists
        //after confirming child exists, it calls another method above to get the child index
        //and then returns the heap of that index
        public Player leftChild(int index)
        {
            if (!hasLeftChild(index))
            {
                throw new NodeNullException();
            }
            return playerHeap[getLeftChildIndex(index)];
        }

        //method for retrieving right child, using method above to check if child exists
        //after confirming child exists, it calls another method above to get the child index
        //and then returns the heap of that index
        public Player rightChild(int index)
        {
            if (!hasRightChild(index))
            {
                throw new NodeNullException();
            }
            return playerHeap[getRightChildIndex(index)];
        }

        //method for retrieving parent, using method above to check if parent exists
        //after confirming parent exists, it calls another method above to get the parent index
        //and then returns the heap of that index
        public Player parent(int index)
        {
            if (!hasParent(index))
            {
                throw new NodeNullException();
            }
            return playerHeap[getParentIndex(index)];
        }


        //method to swap the index location of two nodes
        //begins by checking if either node is null and throwing an exception if it is
        //it then creatres a temporary node and assigns the value of one node to the temporary
        //next it assigns the value of the second node to the first node location
        //finally it assigns the value of the temporary node to the second node location, completing the swap
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

        //method to ensure array used for heap has space for additional nodes
        //begins by checking if size is equal to capacity
        //if it is not equal, then there is space and no code runs
        //if not equal, change capacity property to double current amount
        //then create a temporary array to store the heap
        //next initialize the original heap property with the new capacity
        //use for loop to iterate through all elements in temporary array and assign values to new heap
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

        //method to get value of root in heap
        //starts by checking if root is null, if so an exception is thrown
        //if not null, it checks if size is zero, this would be the case if the array was initalized, but no nodes added
        //if size is zero, return a new node of Player type
        //if not zero, return element at root
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


        //method for getting the root of the heap and removing it at the same time
        //starts by checking if root is null, if so throw an exception
        //just like method above, if it isn't null but size equals zero, send a new empty node
        //otherwise assign a temporary node of Player type the value of the root
        //then take the value of the last item in the heap and assign it to the root location
        //call method below to sort heap correctly, and then return the temporary node
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


        //method to add node of Player type to heap
        //start by ensuring space in heap with method above
        //then assign node to heap at end by using current size value, which will always be one more than index of last node
        //increment size and call method below to sort the heap correctly again
        public void add(Player player)
        {
            ensureExtraCapacity();
            playerHeap[size] = player;
            size++;
            heapifyUp();
        }

        //method to sort heap when a new node is added to end of heap
        //start by setting an index value as the last item in the heap (one less than size of heap)
        //then it creates a loop where it checks if the current index has a parent
        //loop also checks if the totalTurns property of the parent node is less than the totalTurns property of the current node
        //while those conditions remain true, it calls the swap method above to switch node locations
        //then it sets a new value to index that is the parent of the current index
        public void heapifyUp()
        {
            int index = size - 1;
            while (hasParent(index) && parent(index).totalTurns < playerHeap[index].totalTurns)
            {
                swap(getParentIndex(index), index);
                index = getParentIndex(index);
            }
        }

        //method to sort heap when a node is removed from the root
        //start by setting an index value equal to the root, 0
        //next create a while loop that checks if current index has a left child
        //while that condition is true, start by setting a variable to determine which child has larger value
        //intially sets this to left child, but then uses conditional statement to check if a right child exists
        //if there is a right child, it compares the values in each child
        //if the right child has a greater value than the left, it assigns larger child's index to the variable
        //it is not necessary to do this same check for the left because if a node has any child it will be the left first
        //so inital value is assigned to left, then a check is made if the right child exists, and if it should be used instead
        //after finding the child with the greater value, it checks if the current node is greater than the larger child
        //if the current node is greater, the loop is broken as there is no need for further action
        //if the current node is not greater, it calls the swap method above to change the location of each node
        //finally it sets the new index location to that of the larger child before a new iteration of the loop begins
        public void heapifyDown()
        {
            int index = 0;
            while (hasLeftChild(index))
            {
                int largerChildIndex = getLeftChildIndex(index);
                if (hasRightChild(index) && rightChild(index).totalTurns > leftChild(index).totalTurns)
                {
                    largerChildIndex = getRightChildIndex(index);
                }

                if (playerHeap[index].totalTurns > playerHeap[largerChildIndex].totalTurns)
                {
                    break;
                }
                else
                {
                    swap(index, largerChildIndex);
                    index = largerChildIndex;
                }
            }
        }

        //method to return an array of sorted values in heap from largest to smallest
        //begins by checking if the root is null, if so it throws an exception
        //next it creates an array of Player type to store the sorted list
        //then it creates a variable for the index and sets it to the root, 0
        //a loop is then created to iterate through the heap by checking if the size is greater than 0
        //while that condition is true the current index of the sorted list is assigned the value of the root of the heap
        //this is done using the pull method above, then the index is incremented for the next iteration
        //when this is done, each Player in the sorted list is added back to the heap using the method above
        //finally, the sorted list is returned
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
                sorted[index] = pull();
                index++;
            }
            foreach (Player player in sorted)
            {
                add(player);
            }
            return sorted;
        }
    }
}
