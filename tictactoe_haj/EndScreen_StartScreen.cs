
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;

namespace KarnsProjectWork
{

    internal class EndScreen_StartScreen
    {
        static void ShowStartScreen()
        {
            Raylib.ClearBackground(Color.White);

            Raylib.DrawText("Tic Tac Toe", 50, 100, 40, Color.Black);
            Raylib.DrawText("Click anywhere to start", 30, 200, 20, Color.Black);

            Raylib.EndDrawing();

            while (!Raylib.IsMouseButtonPressed(MouseButton.Left))
            {
                // Wait for click to start the game
            }
        }

        static void ShowEndScreen(string message)
        {
            Raylib.ClearBackground(Color.White);

            Raylib.DrawText(message, 50, 150, 30, Color.Black);
            Raylib.DrawText("Click anywhere to restart", 30, 200, 20, Color.Black);

            Raylib.EndDrawing();

            while (!Raylib.IsMouseButtonPressed(MouseButton.Left))
            {
                // Wait for click to restart the game
            }

            ResetGame();
        }

        static void ResetGame()
        {
            // Reset game state
            //code for resteting the game would go here  (-karn)
        }
    }
}