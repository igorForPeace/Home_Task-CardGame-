using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1_Home_Task_CardGame_
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.PlayGame();
        }
    }
}


//////////////////
///TESTS
//Card card = new Card("10", (char)4, 10);
//card.ShowCard();

//Game game = new Game();
//game.ShowAllCards();
//game.Shuffle();
//game.ShowAllCards();
//game.GiveCards();
//Console.WriteLine();
//game.ShowPlayersCard();

//game.PlayGame();
//Console.WriteLine();
//game.ShowPlayersCard();
//game.PlayGame();
//Console.WriteLine();
//game.ShowPlayersCard();

//Game game = new Game();
//game.ShowAllCards();
//game.GiveCards();
//Console.WriteLine();
//game.ShowPlayersCard();
//game.PlayGame();
//game.ShowPlayersCard();
//game.PlayGame();
//game.ShowPlayersCard();  
