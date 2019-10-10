using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
  public class Room : IRoom
  {
    public string Direction { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Item> Items { get; set; }
    public Dictionary<string, IRoom> Exits { get; set; }

    public void AddExit(IRoom room)
    {
      Exits.Add(room.Direction, room);
    }
    public IRoom Go(string direction)
    {
      if (Exits.ContainsKey(direction))
      {
        return Exits[direction];
      }
      return this;
    }

    public string GetTemplate()
    {
      throw new System.NotImplementedException();
    }

    public Room(string direction, string name, string description, List<Item> items, Dictionary<string, IRoom> exits)
    {
      Direction = direction;
      Name = name;
      Description = description;
      Items = items;
      Exits = exits;
    }

  }
}