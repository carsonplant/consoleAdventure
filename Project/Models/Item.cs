using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
  public class Item : IItem
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public string TargetDirection { get; set; }
    public IRoom TargetRoom { get; set; }
    public IRoom ValidRoom { get; set; }

    public Item(string name, string description, string targetDirection, IRoom targetRoom, IRoom validRoom)
    {
      Name = name;
      Description = description;
      TargetDirection = targetDirection;
      TargetRoom = targetRoom;
      ValidRoom = validRoom;

    }
  }
}