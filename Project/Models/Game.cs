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
      Room one = new Room("one", "Entrance to the tomb, one door to the East");
      Room two = new Room("two", "First room inside, one door to the South, one door to the East, the tomb seems naturally well lit but there's a torch, \n may be useful later.");
      Room three = new Room("three", "It appears to be a dead end, but there seems to be a fragile looking artifact hanging off the back wall; one door \n to the West back to room 2");
      Room four = new Room("four", "Another dead end, this room may be filled with snakes.; one door to the West back to room 5");
      Room five = new Room("five", "Interesting, four doors; one to the North, South, East, and West...decisions decisions");
      Room six = new Room("six", "The first completely dark room, a key is hidden until the torch is used to illuminate, one door to the East \n back to room 5");
      Room seven = new Room("seven", "Locked door...something good must be behind(needs key from room 6), inside is the mummy's sarcoughagus (WIN)");


      one.AddExit(Direction.east, two);
      two.AddExit(Direction.west, one);

      two.AddExit(Direction.east, three);
      three.AddExit(Direction.west, two);

      two.AddExit(Direction.south, five);
      five.AddExit(Direction.north, two);

      five.AddExit(Direction.east, four);
      four.AddExit(Direction.west, five);

      five.AddExit(Direction.south, seven);
      seven.AddExit(Direction.north, five);

      five.AddExit(Direction.west, six);
      six.AddExit(Direction.east, five);

      CurrentRoom = one;
    }

    public IRoom GetUserInput()
    {
      throw new System.NotImplementedException();
    }

    void IGame.GetUserInput()
    {
      throw new System.NotImplementedException();
    }

    public Game()
    {
      CurrentPlayer = new Player();
      Setup();
    }
  }
}