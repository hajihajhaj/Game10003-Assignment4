
using System;
using Raylib_cs;

namespace TikTakTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            const int screenWidth = 800;
            const int screenHeight = 600;
            const int boardSize = 3; // Size of the board

            Raylib.InitWindow(screenWidth, screenHeight, "TikTakTwo");

            // Initialize the board
            int[,] board = new int[boardSize, boardSize];

            int cellWidth = screenWidth / boardSize;
            int cellHeight = screenHeight / boardSize;

            bool isXTurn = true; // Indicates whether it's X's turn or O's turn

            while (!Raylib.WindowShouldClose())
            {
                
                if (Raylib.IsMouseButtonPressed(MouseButton.Left))
                {
                    int mouseX = Raylib.GetMouseX();
                    int mouseY = Raylib.GetMouseY();

                    int cellX = mouseX / cellWidth;
                    int cellY = mouseY / cellHeight;

                    if (cellX >= 0 && cellX < boardSize && cellY >= 0 && cellY < boardSize && board[cellX, cellY] == 0)
                    {
                        // Place X or O based on whose turn it is
                        board[cellX, cellY] = isXTurn ? 1 : 2;
                        isXTurn = !isXTurn;
                    }
                }

                // Draw the board
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.White);

                // Draw the board
                for (int i = 0; i < boardSize; i++)
                {
                    for (int j = 0; j < boardSize; j++)
                    {
                        int cellX = i * cellWidth;
                        int cellY = j * cellHeight;

                        // Draw the cell borders
                        Raylib.DrawRectangleLines(cellX, cellY, cellWidth, cellHeight, Color.Black);

                        // Draw the walls
                        if (i != boardSize - 1)
                            Raylib.DrawRectangle(cellX + cellWidth - 5, cellY, 10, cellHeight, Color.Black);
                        if (j != boardSize - 1)
                            Raylib.DrawRectangle(cellX, cellY + cellHeight - 5, cellWidth, 10, Color.Black);

                        // Draw the X's and O's
                        if (board[i, j] == 1)
                        {
                            Raylib.DrawLine(cellX + 10, cellY + 10, cellX + cellWidth - 10, cellY + cellHeight - 10, Color.Blue);
                            Raylib.DrawLine(cellX + cellWidth - 10, cellY + 10, cellX + 10, cellY + cellHeight - 10, Color.Blue);
                        }
                        else if (board[i, j] == 2)
                        {
                            Raylib.DrawCircle(cellX + cellWidth / 2, cellY + cellHeight / 2, cellWidth / 3, Color.Red);
                        }
                    }
                }

                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }
    }
}