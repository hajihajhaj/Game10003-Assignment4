using Raylib_cs;
using System;
using System.ComponentModel.Design;
using System.Drawing;
using System.Numerics;
using Color = Raylib_cs.Color;

class Program
{
    static void Main()
    {
        const int screenWidth = 600;
        const int screenHeight = 600;

        Raylib.InitWindow(screenWidth, screenHeight, "Tic Tac Toe");
        Raylib.SetTargetFPS(60);

        string saveDirectory = "C:/Users/hajar/downloads/tictactoe";

        // download images from urls 
        string waffleImagePath = DownloadImage("https://i.postimg.cc/x878S3yX/waffle.png", saveDirectory);
        string strawberryImagePath = DownloadImage("https://i.postimg.cc/PJBX7rTZ/strawberry.png", saveDirectory);
        string blueberryImagePath = DownloadImage("https://i.postimg.cc/ncDcD7G1/blueberry.png", saveDirectory);


        // Load textures for the game
        Texture2D waffleTexture = Raylib.LoadTexture(waffleImagePath);
        Texture2D strawberryTexture = Raylib.LoadTexture(strawberryImagePath);
        Texture2D blueberryTexture = Raylib.LoadTexture(blueberryImagePath);

        // Set board size
        const int boardSize = 3;
        char[,] board = new char[boardSize, boardSize];
        bool playerTurn = true;
        bool gameOver = false;

        // Initialize the game board
        for (int i = 0; i < boardSize; i++)
        {
            for (int j = 0; j < boardSize; j++)
            {
                board[i, j] = ' ';
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
                    int col = aiMove[1];
                    board[row, col] = 'O'; // Place blueberry at AI's move
                    playerTurn = true;
                }
            }

            // Draw the game
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.RayWhite);

            // Draw the game board
            Raylib.DrawTextureEx(waffleTexture, new Vector2(-135, -5), 0.0f, 0.45f, Color.White);

            // Draw the strawberries and blueberries on the board
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    float cellX = j * (screenWidth / boardSize) + -30; // Adjusted X position
                    float cellY = i * (screenHeight / boardSize) + -30; // Adjusted Y position

                    if (board[i, j] == 'X')
                    {
                        Raylib.DrawTextureEx(strawberryTexture, new Vector2(cellX, cellY), 0f, 0.15f, Color.White); // Reduced character size
                    }
                    else if (board[i, j] == 'O')
                    {
                        Raylib.DrawTextureEx(blueberryTexture, new Vector2(cellX, cellY), 0f, 0.15f, Color.White); // Reduced character size
                    }
                }
            }

            // Check for game over conditions
            if (!gameOver)
            {
                char winner = CheckWinner(board);
                if (winner != ' ')
                {
                    gameOver = true;
                }
                else if (IsBoardFull(board))
                {
                    gameOver = true;
                }
            }

            Raylib.EndDrawing();
        }


        // Unload textures and close Raylib window
        Raylib.UnloadTexture(waffleTexture);
        Raylib.UnloadTexture(strawberryTexture);
        Raylib.UnloadTexture(blueberryTexture);

        Raylib.CloseWindow();
    }

    static void PlaceStrawberry(char[,] board, int row, int col)
    {
        // Place a strawberry on the board if the cell is empty
        if (board[row, col] == ' ')
        {
            board[row, col] = 'X';
        }
    }

    static int[] GetAIMove(char[,] board)
    {
        Random rand = new Random();

        // Check for available moves and return a random move
        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                if (board[i, j] == ' ')
                {
                    return new int[] { i, j };
                }
            }
        }

        return null;
    }

    static char CheckWinner(char[,] board)
    {
        // Check rows
        for (int i = 0; i < board.GetLength(0); i++)
        {
            if (board[i, 0] != ' ' && board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
            {
                return board[i, 0];
            }
        }

        // Check columns
        for (int j = 0; j < board.GetLength(1); j++)
        {
            if (board[0, j] != ' ' && board[0, j] == board[1, j] && board[1, j] == board[2, j])
            {
                return board[0, j];
            }
        }

        // Check diagonals
        if (board[0, 0] != ' ' && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
        {
            return board[0, 0];
        }

        if (board[0, 2] != ' ' && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
        {
            return board[0, 2];
        }

        // No winner
        return ' ';
    }


    static string DownloadImage(string url, string saveDirectory)
    {
        string fileName = Path.GetFileName(new Uri(url).AbsolutePath);
        string imagePath = Path.Combine(saveDirectory, fileName);

        return imagePath;
    }
    static bool IsBoardFull(char[,] board)
    {
        // Check if the board is full (no empty cells)
        foreach (char cell in board)
        {
            if (cell == ' ')
            {
                return false;
            }
        }
        return true;
    }
}