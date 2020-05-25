
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Globalization;

namespace TextBasedRPG
{
    class Program
    {

        public static bool isPlayer1Turn = false;
        public static Hashtable player1 = new Hashtable();
        public static Hashtable player2 = new Hashtable();
        public static Hashtable playerThisTurn = new Hashtable();
        public static string[,] board = new string[3, 3] {
            { " ", " ", " " },
            { " ", " ", " " },
            { " ", " ", " " }
       };

        public static void InitPlayers()
        {
            player1.Add("Marker", "X");
            player2.Add("Marker", "O");
        }

        public static bool IsHorizontalWin()
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                Hashtable markerCounters = new Hashtable()
                {
                    {"X", 0 },
                    {"O", 0 },
                };

                for (int col = 0; col < board.GetLength(1); col++)
                {
                    string marker = board[row, col];
                    if (marker == " ")
                    {
                        continue;
                    }
                    int markerCount = (int)markerCounters[marker];
                    markerCounters[marker] = markerCount + 1;
                }

                if (markerCounters.ContainsValue(3))
                {
                    return true;
                }
            }
            return false;
        }
        public static bool IsGameOver()
        {
            if(IsHorizontalWin())
            {
                return true;
            }
            return false;
        }

        public static void clearDisplay()
        {
            string blankScreen = "";
            for (int i = 0; i < 50; i++)
            {
                blankScreen += "\n";
            }
            Console.WriteLine(blankScreen);
        }

        public static void writeDisplay()
        {
            string display = $"\t    TIC TAC TOE \n\n" +
                $"\t     A   B   C\n\n" +
                $"\t1  | {board[0, 0]} | {board[0, 1]} | {board[0, 2]} |\n" +
                $"\t   ------------\n" +
                $"\t2  | {board[1, 0]} | {board[1, 1]} | {board[1, 2]} |\n" +
                $"\t   ------------\n" +
                $"\t3  | {board[2, 0]} | {board[2, 1]} | {board[2, 2]} |\n\n";
           
            Console.WriteLine(display);
        }
    
        static void updatePlayerThisTurn()
        {
            if(isPlayer1Turn)
            {
                playerThisTurn = player1;
            }
            else 
            {
                playerThisTurn = player2;
            }
        } 

       static void updatePlayerTurn()
       {
            isPlayer1Turn = !isPlayer1Turn; 
       }

        public static bool IsValidUserInput(string userInput)
        {

            if (userInput.Length != 2)
            {
                return false;
            }

            char column = userInput[0];
            char row = userInput[1];

            if (!Char.IsLetter(column))
            {
                return false;
            }

            if (!Char.IsNumber(row))
            {
                return false;
            }

            column = char.ToUpper(column);
            if (column != 'A' && column != 'B' && column != 'C') {
                return false;
            }

            row = (char)(int.Parse(row.ToString()) - 1);
            if(row < 0 || row > 2)
            {
                return false;
            }
            
            return true;
        } 

        
        static void Main(string[] args)
        {
            InitPlayers();
            while (!IsGameOver())
            {

                isPlayer1Turn = !isPlayer1Turn;
                updatePlayerThisTurn();

                string userInput = "";
                while(!IsValidUserInput(userInput))
                {
                    clearDisplay();
                    writeDisplay();
                    Console.Write($"{playerThisTurn["Marker"]}'s Turn: ");
                    userInput = Console.ReadLine();
                }

                int col = char.ToUpper(userInput[0]) - 65;
                int row = int.Parse(userInput[1].ToString()) - 1;

                board[row, col] = (string)playerThisTurn["Marker"];
            };
            clearDisplay();
            writeDisplay();
            Console.Write($"Player {playerThisTurn["Marker"]} Wins!");
        }
    }  
 }