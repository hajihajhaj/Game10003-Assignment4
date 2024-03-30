using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace a3_testing
{
    internal class Enemy
    {

       


        public static bool HandleMenuInput()
        {
            if (Raylib.IsKeyPressed(KeyboardKey.One))
            {
                return false;
            }
            else if (Raylib.IsKeyPressed(KeyboardKey.Two))
            {
                Raylib.CloseWindow();
                return false;
            }
            return true;
        }

        public static void DrawMenu(int screenWidth, int screenHeight)
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Black);
            Raylib.DrawText("Dinosaur T-Rex (square) Game", screenWidth / 2 - 260, screenHeight / 2 - 100, 35, Color.Red);
            Raylib.DrawText("1. Start Game", screenWidth / 2 - 100, screenHeight / 2 - 50, 20, Color.White);
            Raylib.DrawText("2. Exit", screenWidth / 2 - 100, screenHeight / 2 - 15, 20, Color.White);
            Raylib.EndDrawing();
        }

        public static void DrawGame(Vector2 jump, Vector2 rectangle1, Vector2 rectangle2, Vector2 rectangleSize1, Vector2 rectangleSize2, int characterSize, int score, int highScore, int screenWidth, int screenHeight)
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.White);
            Raylib.DrawRectangle((int)jump.X, (int)jump.Y, characterSize, characterSize, Color.Red);
            Raylib.DrawRectangle((int)rectangle1.X, (int)rectangle1.Y, (int)rectangleSize1.X, (int)rectangleSize1.Y, Color.Black);
            Raylib.DrawRectangle((int)rectangle2.X, (int)rectangle2.Y, (int)rectangleSize2.X, (int)rectangleSize2.Y, Color.Black);
            Raylib.DrawText($"Score: {score}", 10, 10, 20, Color.Black);
            Raylib.DrawText($"High Score: {highScore}", 10, 40, 20, Color.Black);
            Raylib.EndDrawing();
        }

        public static int LoadHighScore()
        {
            return 0;
        }

        public static void SaveHighScore(int highScore)
        {
        }

       
    }
}




