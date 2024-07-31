using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TicTacToeGame.Exceptions;

namespace TicTacToeGame.Models
{
    internal class GameLogic
    {
        public GameLogic()
        {
            string[] grid = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            bool isPlayer1Turn = true; //setting default as player 1 turn

            int noOfTurns = 0;
            

            while (!CheckVictory() && noOfTurns < 9)
            {
                PrintGrid();
                if (isPlayer1Turn)
                    Console.WriteLine("Player 1 turn");
                else
                    Console.WriteLine("Player 2 turn");

                string choice = Console.ReadLine();

                try
                {
                    int gridIndex = ValidateChoice(choice);

                    if (isPlayer1Turn)
                        grid[gridIndex] = "X";
                    else
                        grid[gridIndex] = "O";
                    noOfTurns++;
                    isPlayer1Turn = !isPlayer1Turn;
                }
                catch(IsNullOrWhiteSpaceException inws) {
                    Console.WriteLine(inws.Message);
                }
                catch (InvalidInputFormatException iif)
                {
                    Console.WriteLine(iif.Message);
                }
                catch (FormatException ex) {
                    Console.WriteLine(ex.Message);
                }
                
            }
           


            if (CheckVictory())
                Console.WriteLine("You win!");
            else
                Console.WriteLine("Tie");


            bool CheckVictory()
            {
                bool row1 = grid[0] == grid[1] && grid[1] == grid[2];
                bool row2 = grid[3] == grid[4] && grid[4] == grid[5];
                bool row3 = grid[6] == grid[7] && grid[7] == grid[8];
                bool col1 = grid[0] == grid[3] && grid[3] == grid[6];
                bool col2 = grid[1] == grid[4] && grid[4] == grid[7];
                bool col3 = grid[2] == grid[5] && grid[5] == grid[8];
                bool mainDiagonal = grid[0] == grid[4] && grid[4] == grid[8]; //down
                bool antiDiagonal = grid[6] == grid[4] && grid[4] == grid[2];

                return row1 || row2 || row3 || col1 || col2 || col3 || mainDiagonal || antiDiagonal;
            }

            void PrintGrid()
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        Console.Write(grid[i * 3 + j] + "|");
                    }
                    Console.WriteLine();
                    Console.WriteLine("______");
                }
            }

            int ValidateChoice(string choice)
            {
                if (string.IsNullOrWhiteSpace(choice))
                {
                    throw new IsNullOrWhiteSpaceException("Input cannot be empty. Please enter a number from 1 to 9.");
                }

                if(!int.TryParse(choice, out int num))
                {
                    throw new InvalidInputFormatException("Invalid input format. Please enter a number from 1 to 9.");
                }

                if(num<1 || num > 9)
                {
                    throw new FormatException("Number out of range. Please enter a number from 1 to 9.");
                }

                int gridIndex = num - 1;
                if (grid[gridIndex] == "X" || grid[gridIndex] == "O")
                    throw new FormatException("This cell is already taken. Please choose a different cell.");

                return gridIndex;
            }
            

        }
    }
}
