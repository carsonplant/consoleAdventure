using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
  public class Player : IPlayer
  {
    public string Name { get; set; }
    public List<Item> Inventory { get; set; }

    public string GetTemplate()
    {
      throw new System.NotImplementedException();
    }


    public Player(string name, List<Item> inventory)
    {
      Name = name;
      Inventory = inventory;
    }

    public Player()
    {
    }
  }
}