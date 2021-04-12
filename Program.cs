using System;

namespace Tic_Tac_Toe_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] board = new string[3, 3];
            int x_coord = 0, y_coord = 0;
            string marker = " ";
            bool gameWin = false;
            int win = 0;
            int count = 0;

            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int column = 0; column < board.GetLength(1); column++)
                {
                    board[row, column] = " ";
                }
            }

            placeMarker(board, marker, x_coord, y_coord);
        }
        static string Prompt(string text)
        {
            Console.Write(text + " ");
            return Console.ReadLine();
        }
        static int PromptInt(string text)
        {
            Console.Write(text + " ");
            return int.Parse(Console.ReadLine());
        }
        static void drawBoard(string[,] board)
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[0, 0], board[0, 1], board[0, 2]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[1, 0], board[1, 1], board[2, 1]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[2, 0], board[2, 1], board[2, 2]);
            Console.WriteLine("     |     |      ");
        }
        static void placeMarker(string[,] board, string marker, int x_coord, int y_coord)
        {
            //X_Coord is Player 1
            //Y_Coord is Player 2
            //Marker is either 'X' or 'O'

            int count = 0; //# of turns that can be made
            int win = 0; //Tracker to see if player 1 or 2 won.
            bool gameWin = false;



            while (count < 9 && gameWin == false)
            {
                drawBoard(board);
                do
                {
                    marker = "X";
                    x_coord = PromptInt("Enter the row number you want to place the X: \t");
                    y_coord = PromptInt("Enter the column number of where you want to place the X: \t");
                    if (board[x_coord, y_coord] != " ")
                    {
                        Console.WriteLine("This spot has been taken already.");
                    }
                } while (board[x_coord, y_coord] != " ");

                //Updating Board
                board[x_coord, y_coord] = marker;
                count++;

                drawBoard(board);
                Console.WriteLine("\n");
                win = winCheck(board);

                //Checking if Player 1 or 2 won
                if (win == 1)
                {
                    Console.WriteLine("Player 1 won.");
                    gameWin = true;
                }
                else if (win == 2)
                {
                    Console.WriteLine("Player 2 won.");
                    gameWin = true;
                }

                if (count < 9 && gameWin == false)
                {
                    do
                    {
                        marker = "O";
                        x_coord = PromptInt("Enter the row number you want to place O: \t");
                        y_coord = PromptInt("Enter the column number you want to place O: \t");
                        if (board[x_coord, y_coord] != " ")
                        {
                            Console.WriteLine("This spot has been taken already.");
                        }
                    } while (board[x_coord, y_coord] != " ");
                }
                //Updating board
                board[x_coord, y_coord] = marker;

                win = winCheck(board);

                //Check if Player 1 or 2 won
                if (gameWin == false)
                {
                    if (win == 1)
                    {
                        Console.WriteLine("Player 1 won.");
                        gameWin = true;
                    }
                    else if (win == 2)
                    {
                        Console.WriteLine("Player 2 won.");
                        gameWin = true;
                    }
                }
            }//End of While loop
            Console.WriteLine("\n");
            count++;

            if (win == 0)
            {
                Console.WriteLine("It is a tie.");
            }
        }
        static int winCheck(string[,] board)
        {
            //Player 1 Possible Wins
            if (board[0, 0] == "X" && board[0, 1] == "X" && board[0, 2] == "X") return 1;
            if (board[1, 0] == "X" && board[1, 1] == "X" && board[1, 2] == "X") return 1;
            if (board[2, 0] == "X" && board[2, 1] == "X" && board[2, 2] == "X") return 1;
            if (board[0, 0] == "X" && board[1, 1] == "X" && board[2, 2] == "X") return 1;
            if (board[0, 2] == "X" && board[1, 1] == "X" && board[2, 0] == "X") return 1;
            if (board[0, 0] == "X" && board[1, 0] == "X" && board[2, 0] == "X") return 1;
            if (board[0, 1] == "X" && board[1, 1] == "X" && board[2, 1] == "X") return 1;
            if (board[0, 2] == "X" && board[1, 2] == "X" && board[2, 2] == "X") return 1;

            //Player 2 Possible Wins
            if (board[0, 0] == "O" && board[0, 1] == "O" && board[0, 2] == "O") return 2;
            if (board[1, 0] == "O" && board[1, 1] == "O" && board[1, 2] == "O") return 2;
            if (board[2, 0] == "O" && board[2, 1] == "O" && board[2, 2] == "O") return 2;
            if (board[0, 0] == "O" && board[1, 1] == "O" && board[2, 2] == "O") return 2;
            if (board[0, 2] == "O" && board[1, 1] == "O" && board[2, 0] == "O") return 2;
            if (board[0, 0] == "O" && board[1, 0] == "O" && board[2, 0] == "O") return 2;
            if (board[0, 1] == "O" && board[1, 1] == "O" && board[2, 1] == "O") return 2;
            if (board[0, 2] == "O" && board[1, 2] == "O" && board[2, 2] == "O") return 2;


            else return 0;
        }
    }
}
