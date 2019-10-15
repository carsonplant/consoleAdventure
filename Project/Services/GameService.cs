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
    //FIXME Remove all console writes and do Message.add
    public List<string> Messages { get; set; }
    public GameService()
    {
      _game = new Game();
      Messages = new List<string>();
    }

    public void StartGame()
    {
      _game.Setup();

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
          Messages.Add("Please choose from you valid directions: 'East', 'West', 'North', 'South' ");
          Thread.Sleep(3000);
          break;
      }
    }
    public void Help()
    {
      Messages.Add(@"
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
      // Messages.Add($"{_game.CurrentRoom.Description}");
      Messages.Add(Environment.NewLine);
      _game.CurrentPlayer.ShowInventory();
      Messages.Add(Environment.NewLine);
    }

    public void Look()
    {
      Messages.Add(_game.CurrentRoom.GetTemplate());
    }

    public void Quit()
    {
      Console.Clear();
      Messages.Add("You're really gonna quit on the adventure?");
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
    // public void TakeItem(string itemName)
    // {
    //   IItem item = _game.CurrentRoom.Items.Find(i => { return i.Name.ToLower() == itemName; });
    //   if (item != null)
    //   {
    //     _game.CurrentPlayer.Inventory.Add(item);
    //     _game.CurrentRoom.Items.Remove(item);
    //     Messages.Add($"You picked up {itemName}");
    //     return;
    //   }
    //   else
    //   {
    //     Messages.Add(_game.CurrentRoom.Items.Count > 0 ? $"What are you playing at {itemName} isn't there anymore" : "There isn't anything to take.");
    //   }
    // }

    public void TakeItem(string itemName)
    {
      IItem target;
      for (int i = 0; i < _game.CurrentRoom.Items.Count; i++)
      {
        IItem item = _game.CurrentRoom.Items[i];

        if (item.Name.ToLower() == itemName)
        {
          target = item;
          _game.CurrentPlayer.Inventory.Add(target);
          Messages.Add("Item successfully obtained");
          _game.CurrentRoom.Items.Remove(item);
          return;
        }
      }
      Messages.Add("Invalid Action");
    }

    // private Item SecureItem(string input, List<Item> items)
    // {
    //   return ;
    // }


    ///<summary>
    ///No need to Pass a room since Items can only be used in the CurrentRoom
    ///Make sure you validate the item is in the room or player inventory before
    ///being able to use the item
    ///</summary>
    //FIXME Finish writing this one
    public void UseItem(string itemName)
    {
      //find item from player inventory (see find in takeItem)
      //if they have an item by that name
      // _game.CurrentRoom.Use(item)
      bool validLocation = false;
      //Check if key is in inventory
      _game.CurrentPlayer.Inventory.ForEach(item =>
      {
        int i = _game.CurrentPlayer.Inventory.IndexOf(item);
        IRoom room = _game.CurrentRoom;
        if (room.Exits.ContainsValue(item.TargetRoom))
        {
          Messages.Add("You already unlocked that.");
          validLocation = true;
          return;
        }
        else if (item.Name == itemName && room == item.ValidRoom)
        {
          IRoom targetRoom = item.TargetRoom;
          room.Exits.Add(Direction.south, item.TargetRoom);
          room.lockedRooms.Remove(item.TargetDirection);
          Messages.Add("Unlocked exit!");
          validLocation = true;
          return;
        }
      });
      if (!validLocation)
      {
        Messages.Add("No applicable key.");
      }
    }
  }
}