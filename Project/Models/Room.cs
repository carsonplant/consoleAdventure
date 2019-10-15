using System;
using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
  public class Room : IRoom
  {
    public string Direction { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<IItem> Items { get; set; }
    public Dictionary<Direction, IRoom> Exits { get; set; }

    private Dictionary<IItem, KeyValuePair<Direction, IRoom>> lockedRooms { get; set; }

    public void AddItem(IItem item)
    {
      Items.Add(item);
    }
    //FIXME this will need to be setup in your game setup
    public void AddExit(Direction direction, IRoom room)
    {
      Exits.Add(direction, room);
    }

    public void AddLockedExit(Direction direction, IRoom room, IItem unlocksWith)
    {
      lockedRooms.Add(unlocksWith, new KeyValuePair<Direction, IRoom>(direction, room));
    }

    public IRoom Go(Direction direction)
    {
      if (Exits.ContainsKey(direction))
      {
        return Exits[direction];
      }
      return this;
    }


    public string GetTemplate()
    {
      string template = $"\nThe room contains:";

      foreach (Item item in Items)
      {
        template += $" \n{item.Name}: {item.Description}";
      }

      template += "\n\nExits:  \n";
      foreach (var exit in Exits)
      {
        template += " " + exit.Key;
      }
      return template;
    }
    //FIXME  Finish writing this out
    public void Use(IItem item)
    {
      //if lockedExits contains the item as a key
      // exits.add(lockedExits[item])
      //lockedExits.remove(item)
    }

    public Room(string name, string description)
    {
      Name = name;
      Description = description;
      Items = new List<IItem>();
      Exits = new Dictionary<Direction, IRoom>();
      lockedRooms = new Dictionary<IItem, KeyValuePair<Direction, IRoom>>();
    }

  }
  public enum Direction
  {
    east,
    west,
    north,
    south
  }
}