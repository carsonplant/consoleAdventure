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
      Console.WriteLine("Welcome to the labyrinth...");
      Console.WriteLine(Environment.NewLine);
      Console.WriteLine("Continue your exploration in search of the mummy's tomb");
      Console.ReadLine();
      {
        Console.Clear();



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
          Console.WriteLine("Please choose from you valid directions: 'East', 'West', 'North', 'South' ");
          Thread.Sleep(3000);
          break;
      }
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
      // Item item = SecureItem(itemName, _game.CurrentRoom.Items);
      // if (item != null)
      // {
      //   Console.Clear();
      //   _game.CurrentRoom.Items.Remove(item);
      //   _game.CurrentPlayer.AddItem(item);
      //   Console.WriteLine($"You picked up {itemName}");
      //   Thread.Sleep(1750);
      // }
      // else
      // {
      //   Console.Clear();
      //   Console.WriteLine(_game.CurrentRoom.Items.Count > 0 ? $"What are you playing at {itemName} isn't there anymore" : "There isn't anything to take.");
      //   Thread.Sleep(1750);
      // }
    }

    // private Item SecureItem(string input, List<Item> items)
    // {
    //   return items.Find(i => { return i.Name.ToLower() == input; });
    // }


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