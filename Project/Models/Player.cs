using System;
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

    public void AddItem(Item item)
    {
      Inventory.Add(item);
    }

    public void ShowInventory()
    {
      if (Inventory.Count > 0)
      {
        Console.WriteLine("You currently have these items in your inventory:");
        Inventory.ForEach(item =>
        {
          Console.WriteLine(item.Name);

        });
      }
      else
      {
        Console.WriteLine("You don't have anything in your inventory.");
      }
    }

    public Player()
    {
    }
  }
}