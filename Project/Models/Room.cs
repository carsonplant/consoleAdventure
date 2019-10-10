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
    public Dictionary<string, IRoom> Exits { get; set; }

    public void AddExit(string direction, IRoom room)
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

    public Room(string name, string description)
    {
      Name = name;
      Description = description;
      Items = new List<IItem>();
      Exits = new Dictionary<string, IRoom>();
    }

  }
}