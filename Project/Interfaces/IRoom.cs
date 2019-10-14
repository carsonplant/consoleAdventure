using System;
using System.Collections.Generic;
using ConsoleAdventure.Project.Models;

namespace ConsoleAdventure.Project.Interfaces
{
  public interface IRoom
  {
    string Direction { get; set; }
    string Name { get; set; }
    string Description { get; set; }
    List<IItem> Items { get; set; }
    Dictionary<Direction, IRoom> Exits { get; }

    IRoom Go(Direction direction);

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

    string GetTemplate();

  }
}
