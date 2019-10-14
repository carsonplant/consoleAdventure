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
      while (true)
      {
        Update();
        GetUserInput();
      }
    }

    private void Update()
    {
      Console.Clear();
      Console.WriteLine(_gameService.GetGameDetails());
      Console.WriteLine("Flight Log:");
      foreach (string message in _gameService.Messages)
      {
        Console.WriteLine("\t" + message);
      }
      _gameService.Messages.Clear();
    }


    //NOTE Gets the user input, calls the appropriate command, and passes on the option if needed.
    public void GetUserInput()
    {
      Console.WriteLine("What would you like to do?");
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
          _gameService.Go(input);
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
          System.Console.WriteLine("I don't know what you mean, try again.");
          break;
      }
    }
    // {
    //   string input = Console.ReadLine().ToLower();
    //   string[] inputs = input.Split(' ');
    //   string command = inputs[0];
    //   string option = "";
    //   if (inputs.Length > 1)
    //   {
    //     option = inputs[1];
    //   }
    //   switch (command)
    //   {
    //     case "go":
    //       _gameService.Go(option);
    //       break;
    //     case "take":
    //       TakeItem(option);
    //       break;
    //     case "use":
    //       UseItem(option);
    //       break;
    //     case "inventory":
    //       Inventory();
    //       break;
    //     case "look":
    //       Look();
    //       break;
    //     case "help":
    //       Help();
    //       break;
    //     case "quit":
    //     case "q":
    //       Quit();
    //       break;
    //     case "reset":
    //     case "r":
    //       Reset();
    //       break;
    //     default:
    //       Console.Clear();
    //       System.Console.WriteLine("I'm a computer and I can guess what you are typing, but how bout you try again.");
    //       Thread.Sleep(1500);
    //       break;
    //   }
    // }

    //NOTE this should print your messages for the game.
    private void Print()
    {

    }

  }
}