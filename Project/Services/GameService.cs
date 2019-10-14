using System;
using System.Collections.Generic;
using System.Threading;
using ConsoleAdventure.Project.Controllers;
using ConsoleAdventure.Project.Interfaces;
using ConsoleAdventure.Project.Models;

namespace ConsoleAdventure.Project
{
  public class GameService : IGameService
  {
    private IGame _game { get; set; }

    public List<string> Messages { get; set; }
    public GameService()
    {
      _game = new Game();
      Messages = new List<string>();
    }

    public void StartGame()
    {
      _game.Setup();
      Console.Clear();
      Console.WriteLine("Hello Investigator, I hope you've slept well we have arrived at Station Hope. I have been attempting to contact the station since we've been in hailing range.\nI've received no response and my sensors aren't picking up any signs of life. As an Investigator I know " +
                        "You've been tasked with solving mysteries,\nbut I strongly advise waiting for the fleet to arrive before proceeding. However as the ship's computer I have to follow your orders what is your command?");
      Console.WriteLine(Environment.NewLine);
      Console.WriteLine("You have a choice either be a gutless Investigator who is a pathetic scaredy cat and (w)ait for the fleet that was sent out two weeks after you left to investigate," +
                        "\nor be a awesome heroic Investigator who does his/her job even in the face of the unknown and (d)ock to the space station and investigate \n" +
                        "What would you like to do (w)ait or (d)ock?");
      Console.ReadLine();
      {
        Console.Clear();

        /*Console.Clear();
        Console.WriteLine("As you shine the light around the room you see a create at the far end of the room! It has red eyes\nand mandibles very similar to those of an ant" +
                          "as you stare in dumb shock it hisses and starts to run at you!");
        Console.WriteLine("");
        Console.WriteLine("You have one chance what are you going to do?");
        continue;*/

        Console.WriteLine($"{_game.CurrentRoom.Description}");
        Console.WriteLine(Environment.NewLine);
        Console.WriteLine("Alright Investigator what's your next move?");
        _game.GetUserInput();


      }
    }

    public string GetGameDetails()
    {
      return _game.CurrentRoom.Description;
    }
    public void Go(string direction)
    {
      switch (direction)
      {
        case "east":
          _game.CurrentRoom = (Room)_game.CurrentRoom.Go(Direction.east);
          break;
        case "west":
          _game.CurrentRoom = (Room)_game.CurrentRoom.Go(Direction.west);
          break;
        case "north":
          _game.CurrentRoom = (Room)_game.CurrentRoom.Go(Direction.north);
          break;
        case "south":
          _game.CurrentRoom = (Room)_game.CurrentRoom.Go(Direction.south);
          break;

        default:
          Console.Clear();
          Console.WriteLine("Please choose from you valid directions: 'Forward', 'Right', 'Left', 'Back' ");
          Thread.Sleep(3000);
          break;
      }
      // string from = _game.CurrentRoom.Name;
      // _game.CurrentRoom = _game.CurrentRoom.Go(direction);
      // string to = _game.CurrentRoom.Name;
      // Messages.Add($"Traveled from {from} to {to}");
    }
    public void Help()
    {
      Console.Clear();
      Console.WriteLine(@"
      Go + Direction(east, west, north or south)
      Take + {item name} i.e. take torch
      Use + {itemname}
      Look -Looks around the room for items
      Inventory - View your items
      Quit - Leave game
      Reset - Resets game to the start
      ");
    }

    public void Inventory()
    {
      Console.Clear();
      Console.WriteLine($"{_game.CurrentRoom.Description}");
      Console.WriteLine(Environment.NewLine);
      _game.CurrentPlayer.ShowInventory();
      Console.WriteLine(Environment.NewLine);
      _game.GetUserInput();
    }

    public void Look()
    {
      Console.Clear();
      Console.WriteLine($"{_game.CurrentRoom.Description}");
      Console.WriteLine(Environment.NewLine);
      _game.CurrentRoom.PrintRoomItems();
      Console.WriteLine(Environment.NewLine);
      Console.WriteLine("What is your next move Investigator?");
      _game.GetUserInput();
    }

    public void Quit()
    {
      Console.Clear();
      Console.WriteLine("You're really gonna quit on the adventure?");
    }
    ///<summary>
    ///Restarts the game 
    ///</summary>
    public void Reset()
    {
      Console.Clear();
      StartGame();
    }

    public void Setup()
    {
      throw new System.NotImplementedException();
    }
    ///<summary>When taking an item be sure the item is in the current room before adding it to the player inventory, Also don't forget to remove the item from the room it was picked up in</summary>
    public void TakeItem(string itemName)
    {
      throw new System.NotImplementedException();
    }
    ///<summary>
    ///No need to Pass a room since Items can only be used in the CurrentRoom
    ///Make sure you validate the item is in the room or player inventory before
    ///being able to use the item
    ///</summary>
    public void UseItem(string itemName)
    {
      throw new System.NotImplementedException();
    }
  }
}