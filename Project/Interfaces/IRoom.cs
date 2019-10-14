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

    string GetTemplate();

  }
}
