namespace PlayerQueueRoney.Models
{
    //Player class to be used by PlayerList class and PlayerHeap class
    public class Player
    {
        //properties for player name and total turns playing game
        public string name;
        public int totalTurns;

        //constructor taking player name argument and setting initial turns to 0
        public Player(string name)
        {
            this.name = name;
            this.totalTurns = 0;
        }

        //default constructor setting name to null
        //other code will not allow this to be added to list, but was necessary to prevent error uof null Player
        public Player()
        {
            this.name = null;
            this.totalTurns = 0;
        }
    }
}
