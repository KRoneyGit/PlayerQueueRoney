using PlayerQueueRoney.Exceptions;
using PlayerQueueRoney.Models;
using System.Collections.Generic;
using Xunit.Sdk;

namespace TestsPlayerQueue
{
    public class PlayerHeapTests
    {
        [Fact]
        public void testGetLeftChildIndex()
        {
            PlayerHeap heap = new PlayerHeap();

            int actual = heap.getLeftChildIndex(3);
            int expected = 7;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void testGetRightChildIndex()
        {
            PlayerHeap heap = new PlayerHeap();

            int actual = heap.getRightChildIndex(3);
            int expected = 8;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void testGetParentIndex()
        {
            PlayerHeap heap = new PlayerHeap();

            int actual = heap.getParentIndex(3);
            int expected = 1;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void testHasLeftChildTrue()
        {
            PlayerHeap heap = new PlayerHeap();
            Player player1 = new Player("Kevin");
            Player player2 = new Player("Michelle");

            heap.add(player1);
            heap.add(player2);
            bool expected = true;
            bool actual = heap.hasLeftChild(0);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void testHasLeftChildFalse()
        {
            PlayerHeap heap = new PlayerHeap();
            Player player = new Player("Kevin");

            heap.add(player);
            bool expected = false;
            bool actual = heap.hasLeftChild(0);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void testHasRightChildTrue()
        {
            PlayerHeap heap = new PlayerHeap();
            Player player1 = new Player("Kevin");
            Player player2 = new Player("Michelle");
            Player player3 = new Player("Evan");

            heap.add(player1);
            heap.add(player2);
            heap.add(player3);
            bool expected = true;
            bool actual = heap.hasRightChild(0);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void testHasRightChildFalse()
        {
            PlayerHeap heap = new PlayerHeap();
            Player player1 = new Player("Kevin");
            Player player2 = new Player("Michelle");

            heap.add(player1);
            heap.add(player2);
            bool expected = false;
            bool actual = heap.hasRightChild(0);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void testHasParentTrue()
        {
            PlayerHeap heap = new PlayerHeap();
            Player player1 = new Player("Kevin");
            Player player2 = new Player("Michelle");

            heap.add(player1);
            heap.add(player2);
            bool expected = true;
            bool actual = heap.hasParent(1);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void testHasParentFalse()
        {
            PlayerHeap heap = new PlayerHeap();
            Player player = new Player("Kevin");

            heap.add(player);
            bool expected = false;
            bool actual = heap.hasParent(0);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void testLeftChild()
        {
            PlayerHeap heap = new PlayerHeap();
            Player player1 = new Player("Kevin");
            Player player2 = new Player("Michelle");
            heap.add(player1);
            heap.add(player2);

            string expected = new Player("Michelle").name;
            string actual = heap.leftChild(0).name;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void testLeftChildEmpty()
        {
            PlayerHeap heap = new PlayerHeap();
            Player player1 = new Player("Kevin");
            heap.add(player1);

            Assert.Throws<NodeNullException>(() => heap.leftChild(0));
        }

        [Fact]
        public void testRightChild()
        {
            PlayerHeap heap = new PlayerHeap();
            Player player1 = new Player("Kevin");
            Player player2 = new Player("Michelle");
            Player player3 = new Player("Evan");
            heap.add(player1);
            heap.add(player2);
            heap.add(player3);

            string expected = new Player("Evan").name;
            string actual = heap.rightChild(0).name;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void testRightChildEmpty()
        {
            PlayerHeap heap = new PlayerHeap();
            Player player1 = new Player("Kevin");
            heap.add(player1);

            Assert.Throws<NodeNullException>(() => heap.rightChild(0));
        }

        [Fact]
        public void testParent()
        {
            PlayerHeap heap = new PlayerHeap();
            Player player1 = new Player("Kevin");
            Player player2 = new Player("Michelle");
            heap.add(player1);
            heap.add(player2);

            string expected = new Player("Kevin").name;
            string actual = heap.parent(1).name;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void testParentEmpty()
        {
            PlayerHeap heap = new PlayerHeap();
            Player player1 = new Player("Kevin");
            heap.add(player1);

            Assert.Throws<NodeNullException>(() => heap.parent(0));
        }

        [Fact]
        public void testSwap()
        {
            PlayerHeap heap = new PlayerHeap();
            Player player1 = new Player("Kevin");
            Player player2 = new Player("Michelle");
            heap.add(player1);
            heap.add(player2);

            heap.swap(0, 1);

            string expected1 = "Michelle";
            string expected2 = "Kevin";
            string actual1 = heap.playerHeap[0].name;
            string actual2 = heap.playerHeap[1].name;

            Assert.Equal(expected1, actual1);
            Assert.Equal(expected2, actual2);
        }

        [Fact]
        public void testSwapEmptyNode()
        {
            PlayerHeap heap = new PlayerHeap();
            Player player1 = new Player("Kevin");
            heap.add(player1);

            Assert.Throws<NodeNullException>(() => heap.swap(0, 1));
        }

        [Fact]
        public void testEnsureExtraCapacity()
        {
            PlayerHeap heap = new PlayerHeap();
            Player player1 = new Player("Kevin");
            Player player2 = new Player("Michelle");
            Player player3 = new Player("Evan");
            Player player4 = new Player("Samantha");
            Player player5 = new Player("Jeff");
            heap.add(player1);
            heap.add(player2);
            heap.add(player3);
            heap.add(player4);
            heap.add(player5);

            heap.ensureExtraCapacity();
            int expected = 10;
            int actual = heap.capacity;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void testEnsureExtraCapacityNotFull()
        {
            PlayerHeap heap = new PlayerHeap();
            Player player1 = new Player("Kevin");
            heap.add(player1);

            heap.ensureExtraCapacity();
            int expected = 5;
            int actual = heap.capacity;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void testPeek()
        {
            PlayerHeap heap = new PlayerHeap();
            Player player1 = new Player("Kevin");
            heap.add(player1);

            string expected = "Kevin";
            string actual = heap.peek().name;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void testPeekEmpty()
        {
            PlayerHeap heap = new PlayerHeap();

            Assert.Throws<NodeNullException>(() => heap.peek());
        }

        [Fact]
        public void testPull()
        {
            PlayerHeap heap = new PlayerHeap();
            Player player1 = new Player("Kevin");
            Player player2 = new Player("Michelle");
            heap.add(player1);
            heap.add(player2);

            string expected1 = "Kevin";
            string expected2 = "Michelle";

            string actual1 = heap.pull().name;
            string actual2 = heap.playerHeap[0].name;

            Assert.Equal(expected1, actual1);
            Assert.Equal(expected2, actual2);
        }

        [Fact]
        public void testPullEmpty()
        {
            PlayerHeap heap = new PlayerHeap();

            Assert.Throws<NodeNullException>(() => heap.pull());
        }

        [Fact]
        public void testAdd()
        {
            PlayerHeap heap = new PlayerHeap();
            Player player1 = new Player("Kevin");
            heap.add(player1);

            string expected = "Kevin";
            string actual = heap.playerHeap[0].name;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void testHeapifyUpByAddingAndHeapifyDownByPulling()
        {
            PlayerHeap heap = new PlayerHeap();
            Player player1 = new Player("Kevin");
            Player player2 = new Player("Michelle");
            Player player3 = new Player("Evan");
            Player player4 = new Player("Samantha");
            Player player5 = new Player("Jeff");
            player1.totalTurns = 0;
            player2.totalTurns = 3;
            player3.totalTurns = 7;
            player4.totalTurns = 2;
            player5.totalTurns = 1;
            heap.add(player1);
            heap.add(player2);
            heap.add(player3);
            heap.add(player4);
            heap.add(player5);

            string expected1 = "Evan";
            string expected2 = "Michelle";
            string expected3 = "Samantha";
            string expected4 = "Jeff";
            string expected5 = "Kevin";

            string actual1 = heap.pull().name;
            string actual2 = heap.pull().name;
            string actual3 = heap.pull().name;
            string actual4 = heap.pull().name;
            string actual5 = heap.pull().name;

            Assert.Equal(expected1, actual1);
            Assert.Equal(expected2, actual2);
            Assert.Equal(expected3, actual3);
            Assert.Equal(expected4, actual4);
            Assert.Equal(expected5, actual5);
        }

        [Fact]
        public void testHeapifyUp()
        {
            PlayerHeap heap = new PlayerHeap();
            Player player1 = new Player("Kevin");
            Player player2 = new Player("Michelle");
            Player player3 = new Player("Evan");
            player2.totalTurns = 3;
            player1.totalTurns = 0;
            player3.totalTurns = 7;

            heap.playerHeap[0] = player1;
            heap.playerHeap[1] = player2;
            heap.playerHeap[2] = player3;
            heap.size = 3;

            heap.heapifyUp();

            string expected1 = "Evan";
            string expected2 = "Michelle";
            string expected3 = "Kevin";

            string actual1 = heap.playerHeap[0].name;
            string actual2 = heap.playerHeap[1].name;
            string actual3 = heap.playerHeap[2].name;

            Assert.Equal(expected1, actual1);
            Assert.Equal(expected2, actual2);
            Assert.Equal(expected3, actual3);
        }

        [Fact]
        public void testHeapifyDown()
        {
            PlayerHeap heap = new PlayerHeap();
            Player player1 = new Player("Kevin");
            Player player2 = new Player("Michelle");
            Player player3 = new Player("Evan");
            player2.totalTurns = 3;
            player1.totalTurns = 0;
            player3.totalTurns = 7;

            heap.playerHeap[0] = player1;
            heap.playerHeap[1] = player2;
            heap.playerHeap[2] = player3;
            heap.size = 3;

            heap.heapifyDown();

            string expected1 = "Evan";
            string expected2 = "Michelle";
            string expected3 = "Kevin";

            string actual1 = heap.playerHeap[0].name;
            string actual2 = heap.playerHeap[1].name;
            string actual3 = heap.playerHeap[2].name;

            Assert.Equal(expected1, actual1);
            Assert.Equal(expected2, actual2);
            Assert.Equal(expected3, actual3);
        }

        [Fact]
        public void testHeapSort()
        {
            PlayerHeap heap = new PlayerHeap();
            Player player1 = new Player("Kevin");
            Player player2 = new Player("Michelle");
            Player player3 = new Player("Evan");
            Player player4 = new Player("Samantha");
            Player player5 = new Player("Jeff");
            player1.totalTurns = 0;
            player2.totalTurns = 3;
            player3.totalTurns = 7;
            player4.totalTurns = 2;
            player5.totalTurns = 1;
            heap.add(player1);
            heap.add(player2);
            heap.add(player3);
            heap.add(player4);
            heap.add(player5);

            Player[] sorted = heap.heapSort();

            string expected1 = "Evan";
            string expected2 = "Michelle";
            string expected3 = "Samantha";
            string expected4 = "Jeff";
            string expected5 = "Kevin";

            string actual1 = sorted[0].name;
            string actual2 = sorted[1].name;
            string actual3 = sorted[2].name;
            string actual4 = sorted[3].name;
            string actual5 = sorted[4].name;

            Assert.Equal(expected1, actual1);
            Assert.Equal(expected2, actual2);
            Assert.Equal(expected3, actual3);
            Assert.Equal(expected4, actual4);
            Assert.Equal(expected5, actual5);
        }

        [Fact]
        public void testHeapSortEmpty()
        {
            PlayerHeap heap = new PlayerHeap();

            Assert.Throws<NodeNullException>(() => heap.heapSort());
        }
    }
}