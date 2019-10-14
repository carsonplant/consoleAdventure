using System.Collections.Generic;
using ConsoleAdventure.Project.Models;

namespace ConsoleAdventure.Project.Interfaces
{
  public interface IPlayer
  {
    string Name { get; set; }
    List<IItem> Inventory { get; set; }

    void ShowInventory();
    string GetTemplate();
  }
}
