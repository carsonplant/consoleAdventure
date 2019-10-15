using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
  public class Game : IGame
  {
    public IRoom CurrentRoom { get; set; }
    public IPlayer CurrentPlayer { get; set; }

    //NOTE Make yo rooms here...
    public void Setup()
    {
      Room one = new Room("one", "You've found the entrance to the tomb, there is one door to the East\n");
      Room two = new Room("two", "First room inside, there is one door to the South, one door to the East\n");
      Room three = new Room("three", "It appears to be a dead end, but there seems to be a fragile looking artifact hanging off the back wall;\n there is one door to the West back to room 2\n");
      Room four = new Room("four", "Another dead end, this room is filled with snakes and you can't make it out \n \n YOU LOSE--choose to quit or reset to try and find a new path to the mummy's tomb.\n");
      Room five = new Room("five", "Interesting, four doors; one to the North, South, East, and West...decisions decisions\n");
      Room six = new Room("six", "Another room filled with artifacts...use look to see if there's anything valuable, \n one door to the East back to room 5\n");
      Room seven = new Room("seven", "You've found it...CONGRATULATIONS YOU WIN \n \n choose to quit or reset to try and find a new path to the mummy's tomb.\n");

      IItem doorKey = new Item("doorKey", "Hmm...looks like a key to a door...wonder what it's doing here?", "south", seven, five);

      one.AddExit(Direction.east, two);
      two.AddExit(Direction.west, one);

      two.AddExit(Direction.east, three);
      three.AddExit(Direction.west, two);

      two.AddExit(Direction.south, five);
      five.AddExit(Direction.north, two);

      five.AddExit(Direction.east, four);
      // four.AddExit(Direction.west, five);

      five.AddLockedExit(Direction.south, seven, doorKey);
      seven.AddExit(Direction.north, five);

      five.AddExit(Direction.west, six);
      six.AddExit(Direction.east, five);

      six.AddItem(doorKey);

      CurrentRoom = one;
    }

    public Game()
    {
      Setup();
    }
  }
}