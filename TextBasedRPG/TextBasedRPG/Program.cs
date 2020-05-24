
using System;

namespace TextBasedRPG
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] board = new string [3, 3] {
                { " ", " ", " " },
                { " ", " ", " " },
                { " ", " ", " " }
           };

            string display = $"\n\n\t TIC TAC TOE \n\n" +
                             $"\t| {board[0, 0]} | {board[0, 1]} | {board[0,2]} |\n" +
                             $"\t-------------\n" +
                             $"\t| {board[1, 0]} | {board[1, 1]} | {board[1,2]} |\n" +
                             $"\t-------------\n" +
                             $"\t| {board[2, 0]} | {board[2, 1]} | {board[2,2]} |\n";

            Console.WriteLine(display);
        }
    }
} 