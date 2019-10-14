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
      throw new System.NotImplementedException();
    }

    public void Quit()
    {
      throw new System.NotImplementedException();
    }
    ///<summary>
    ///Restarts the game 
    ///</summary>
    public void Reset()
    {
      throw new System.NotImplementedException();
    }

    public void Setup(string playerName)
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