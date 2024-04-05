using Raylib_cs;
using System;
using System.ComponentModel.Design;
using System.Drawing;
using System.Numerics;
using Color = Raylib_cs.Color;
using final_tictactoe;

class Program
{
    static void Main(string[] args)
    {
        const int screenWidth = 600;
        const int screenHeight = 600;

        Raylib.InitWindow(screenWidth, screenHeight, "Tic Tac Toe");
        Raylib.SetTargetFPS(60);

        string saveDirectory = "C:/Users/hajar/downloads/tictactoe";

        // Download images from urls 
        string waffleImagePath = DownloadImage("https://i.postimg.cc/x878S3yX/waffle.png", saveDirectory);
        string strawberryImagePath = DownloadImage("https://i.postimg.cc/PJBX7rTZ/strawberry.png", saveDirectory);
        string blueberryImagePath = DownloadImage("https://i.postimg.cc/ncDcD7G1/blueberry.png", saveDirectory);

        Texture2D waffleTexture = Raylib.LoadTexture(waffleImagePath);
        Texture2D strawberryTexture = Raylib.LoadTexture(strawberryImagePath);
        Texture2D blueberryTexture = Raylib.LoadTexture(blueberryImagePath);

        const int boardSize = 3;
        char[,] board = new char[boardSize, boardSize];
        bool playerTurn = true;
        bool gameOver = false;

        for (int row = 0; row < boardSize; row++)
        {
            for (int column = 0; column < boardSize; column++)
            {
                board[row, column] = ' ';
            }
        }

        while (!Raylib.WindowShouldClose())
        {

            // Player's turn
            if (playerTurn && !gameOver)
            {
                if (Raylib.IsKeyPressed(KeyboardKey.Kp7))
                {
                    PlaceStrawberry(board, 0, 0);
                    playerTurn = false;
                }
                else if (Raylib.IsKeyPressed(KeyboardKey.Kp8))
                {
                    PlaceStrawberry(board, 0, 1);
                    playerTurn = false;
                }
                else if (Raylib.IsKeyPressed(KeyboardKey.Kp9))
                {
                    PlaceStrawberry(board, 0, 2);
                    playerTurn = false;
                }
                else if (Raylib.IsKeyPressed(KeyboardKey.Kp4))
                {
                    PlaceStrawberry(board, 1, 0);
                    playerTurn = false;
                }
                else if (Raylib.IsKeyPressed(KeyboardKey.Kp5))
                {
                    PlaceStrawberry(board, 1, 1);
                    playerTurn = false;
                }
                else if (Raylib.IsKeyPressed(KeyboardKey.Kp6))
                {
                    PlaceStrawberry(board, 1, 2);
                    playerTurn = false;
                }
                else if (Raylib.IsKeyPressed(KeyboardKey.Kp1))
                {
                    PlaceStrawberry(board, 2, 0);
                    playerTurn = false;
                }
                else if (Raylib.IsKeyPressed(KeyboardKey.Kp2))
                {
                    PlaceStrawberry(board, 2, 1);
                    playerTurn = false;
                }
                else if (Raylib.IsKeyPressed(KeyboardKey.Kp3))
                {
                    PlaceStrawberry(board, 2, 2);
                    playerTurn = false;
                }
            }
            // AI's turn
            else if (!playerTurn && !gameOver)
            {
                int[] aiMove = GetAIMove(board);
                if (aiMove != null)
                {
                    int row = aiMove[0];
                    int column = aiMove[1];
                    board[row, column] = 'O';
                    playerTurn = true;
                }
            }

            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.RayWhite);

            // Draw the game board
            Raylib.DrawTextureEx(waffleTexture, new Vector2(-135, -5), 0.0f, 0.45f, Color.White);

            // Draw the strawberries and blueberries on the board
            for (int row = 0; row < boardSize; row++)
            {
                for (int column = 0; column < boardSize; column++)
                {
                    float cellX = column * (screenWidth / boardSize) + -30;
                    float cellY = row * (screenHeight / boardSize) + -30;

                    if (board[row, column] == 'X')
                    {
                        Raylib.DrawTextureEx(strawberryTexture, new Vector2(cellX, cellY), 0f, 0.15f, Color.White);
                    }
                    else if (board[row, column] == 'O')
                    {
                        Raylib.DrawTextureEx(blueberryTexture, new Vector2(cellX, cellY), 0f, 0.15f, Color.White);
                    }
                }
            }

            // Check if game is over
            if (!gameOver)
            {
                char winner = CheckWinner(board);
                if (winner != ' ')
                {
                    gameOver = true;
                    Karn.ShowEndScreen($"{winner} wins!");
                }
            }

            Raylib.EndDrawing();
        }

        Raylib.UnloadTexture(waffleTexture);
        Raylib.UnloadTexture(strawberryTexture);
        Raylib.UnloadTexture(blueberryTexture);

        Raylib.CloseWindow();
    }

    static void PlaceStrawberry(char[,] board, int row, int column)
    {
        if (board[row, column] == ' ')
        {
            board[row, column] = 'X';
        }
    }

    static int[] GetAIMove(char[,] board)
    {
        Random rand = new Random();

        // Check if game is over
        for (int row = 0; row < board.GetLength(0); row++)
        {
            for (int column = 0; column < board.GetLength(1); column++)
            {
                if (board[row, column] == ' ')
                {
                    return new int[] { row, column };
                }
            }
        }

        return null;
    }

    // Check if anyone won
    static char CheckWinner(char[,] board)
    {
        for (int row = 0; row < board.GetLength(0); row++)
        {
            if (board[row, 0] != ' ' && board[row, 0] == board[row, 1] && board[row, 1] == board[row, 2])
            {
                return board[row, 0];
            }
        }

        for (int column = 0; column < board.GetLength(1); column++)
        {
            if (board[0, column] != ' ' && board[0, column] == board[1, column] && board[1, column] == board[2, column])
            {
                return board[0, column];
            }
        }

        if (board[0, 0] != ' ' && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
        {
            return board[0, 0];
        }

        if (board[0, 2] != ' ' && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
        {
            return board[0, 2];
        }

        return ' ';
    }

    static string DownloadImage(string url, string saveDirectory)
    {
        string fileName = Path.GetFileName(new Uri(url).AbsolutePath);
        string imagePath = Path.Combine(saveDirectory, fileName);

        return imagePath;
    }
}