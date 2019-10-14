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

    public void AddItem(Item item)
    {
      Items.Add(item);
    }

    public void AddExit(Direction direction, IRoom room)
    {
      Exits.Add(direction, room);
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
      string template = $"Room: {Name} \nExits:\n";
      foreach (var exit in Exits)
      {
        template += "\t" + exit.Key + " - " + exit.Value.Name + Environment.NewLine;
      }
      return template;
    }

    public void PrintRoomItems()
    {
      if (Items.Count > 0)
      {
        Console.WriteLine("You notice this in the room:");
        Items.ForEach(item =>
        {
          Console.WriteLine($"{item.Name}: {item.Description}");
        });
      }
      else
      {
        Console.WriteLine("There is nothing else in this room.");
      }
    }

    public Room(string name, string description)
    {
      Name = name;
      Description = description;
      Items = new List<IItem>();
      Exits = new Dictionary<Direction, IRoom>();
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