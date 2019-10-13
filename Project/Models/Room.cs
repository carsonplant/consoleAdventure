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
      string template = $"Room: {Name} \nExits:\n";
      foreach (var exit in Exits)
      {
        template += "\t" + exit.Key + " - " + exit.Value.Name + Environment.NewLine;
      }
      return template;
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