using System;
using System.Collections.Generic;
using System.Threading;
using ConsoleAdventure.Project.Interfaces;
using ConsoleAdventure.Project.Models;

namespace ConsoleAdventure.Project.Controllers
{

  public class GameController : IGameController
  {
    private GameService _gameService = new GameService();

    //NOTE Makes sure everything is called to finish Setup and Starts the Game loop
    public void Run()
    {
      _gameService.Messages.Add("Welcome to the labyrinth...");
      _gameService.Messages.Add(Environment.NewLine);
      _gameService.Messages.Add("Continue your exploration in search of the mummy's tomb");
      while (true)
      {
        Update();
        GetUserInput();
      }
    }

    private void Update()
    {
      Console.Clear();
      _gameService.Messages.Add(_gameService.GetGameDetails());
      foreach (string message in _gameService.Messages)
      {
        _gameService.Messages.Add("\t" + message);
      }
      _gameService.Messages.Clear();
    }


    //NOTE Gets the user input, calls the appropriate command, and passes on the option if needed.
    public void GetUserInput()
    {
      _gameService.Messages.Add("What would you like to do?");
      string input = Console.ReadLine().ToLower() + " ";
      string command = input.Substring(0, input.IndexOf(" "));
      string option = input.Substring(input.IndexOf(" ") + 1).Trim();
      //NOTE this will take the user input and parse it into a command and option.
      //IE: take silver key => command = "take" option = "silver key"
      switch (command)
      {
        case "q":
        case "quit":
        case "exit":
        case "close":
          Environment.Exit(0);
          break;
        case "go":
          _gameService.Go(option);
          break;
        case "take":
          _gameService.TakeItem(option);
          break;
        case "use":
          _gameService.UseItem(option);
          break;
        case "inventory":
          _gameService.Inventory();
          break;
        case "look":
          _gameService.Look();
          break;
        case "help":
          _gameService.Help();
          break;
        case "reset":
        case "r":
          _gameService.Reset();
          break;
        default:
          Console.Clear();
          _gameService.Messages.Add("I don't know what you mean, try again.");
          break;
      }
    }


    //NOTE this should print your messages for the game.
    private void Print()
    {

    }

  }
}