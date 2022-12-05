using PlayerQueueRoney.Exceptions;
using PlayerQueueRoney.Models;
using Xunit.Sdk;

namespace TestsPlayerQueue
{
    public class PlayerListTests
    {
        [Fact]
        public void testAddToEmpty()
        {
            PlayerList list= new PlayerList();
            list.addPlayer(new Player("Kevin"));

            string expected = "Kevin";
            String actual = list.players[0].name;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void testAddToExistingList()
        {
            PlayerList list = new PlayerList();
            list.addPlayer(new Player("Kevin"));
            list.addPlayer(new Player("Michelle"));

            string expected = "Michelle";
            string actual = list.players[1].name;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void testRemovePlayer()
        {
            PlayerList list = new PlayerList();
            list.addPlayer(new Player("Kevin"));
            list.addPlayer(new Player("Michelle"));

            list.removePlayer(list.players[0]);

            string expected = "Michelle";
            string actual = list.players[0].name;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void testRemoveFromEmpty()
        {
            PlayerList list = new PlayerList();
            Player player = new Player("Kevin");

            Assert.Throws<QueueEmptyException>(() => list.removePlayer(player));
        }

        [Fact]
        public void testRemoveDoesNotExist()
        {
            PlayerList list = new PlayerList();
            Player player1 = new Player("Kevin");
            Player player2 = new Player("Michelle");
            Player player3 = new Player("Evan");

            list.addPlayer(player1);
            list.addPlayer(player2);

            Assert.Throws<NotInQueueException>(() => list.removePlayer(player3));
        }

        [Fact]
        public void testNextPlayer()
        {
            PlayerList list = new PlayerList();
            Player player1 = new Player("Kevin");
            Player player2 = new Player("Michelle");
            list.addPlayer(player1);
            list.addPlayer(player2);

            list.nextPlayer();

            string expected1 = "Michelle";
            string expected2 = "Kevin";

            string actual1 = list.players[0].name;
            string actual2 = list.players[1].name;

            Assert.Equal(expected1, actual1);
            Assert.Equal(expected2, actual2);
        }

        [Fact]
        public void testNextPlayerOnePlayer()
        {
            PlayerList list = new PlayerList();
            Player player = new Player("Kevin");
            list.addPlayer(player);

            list.nextPlayer();

            string expected = "Kevin";

            string actual = list.players[0].name;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void testNextPlayerEmpty()
        {
            PlayerList list = new PlayerList();

            Assert.Throws<QueueEmptyException>(() => list.nextPlayer());
        }

    }
}