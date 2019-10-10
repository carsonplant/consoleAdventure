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
      Room two = new Room("two", "First room inside, one door to the South, one door to the East, the tomb seems naturally well lit but there's a torch, may be useful later.");
      Room three = new Room("three", "It appears to be a dead end, but there seems to be a fragile looking artifact hanging off the back wall; one door to the West back to room 2");
      Room four = new Room("four", "Another dead end, this room may be filled with snakes.; one door to the West back to room 5");
      Room five = new Room("five", "Interesting, four doors one to the North, South, East, and West...decisions decisions");
      Room six = new Room("six", "The first completely dark room, a key is hidden until the torch is used to illuminate, one door to the East back to room 5");
      Room seven = new Room("seven", "Locked door...something good must be behind(needs key from room 6), inside is the mummy's sarcoughagus (WIN)");


      one.AddExit("east", two);
      two.AddExit("west", one);

      two.AddExit("east", three);
      three.AddExit("west", two);

      two.AddExit("south", five);
      five.AddExit("north", two);

      five.AddExit("east", four);
      four.AddExit("west", five);

      five.AddExit("south", seven);
      seven.AddExit("north", five);

      five.AddExit("west", six);
      six.AddExit("east", five);

      CurrentRoom = one;
    }


    public Game()
    {
      CurrentPlayer = new Player();
      Setup();
    }
  }
}