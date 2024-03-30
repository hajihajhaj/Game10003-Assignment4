using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace a3_testing
{
    internal class Visuals
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

        public static void DrawEndScreen(int screenWidth, int screenHeight, int score, int highscore)
        {
            Raylib.DrawText("GAME OVER", screenWidth / 2 - 100, screenHeight / 2 - 50, 40, Color.Red);
            Raylib.DrawText("Press space to restart", screenWidth / 2 - 100, screenHeight / 2 - 15, 20, Color.Black);
            Raylib.DrawText($"Score: {score}   High Score: {highscore}", screenWidth / 2 - 120, screenHeight / 2 + 50, 20, Color.Black);
            Raylib.DrawText("Press 2. to exit", screenWidth / 2 - 50, screenHeight / 2 - -5, 20, Color.Black);
        }
        public static void DrawGame(Vector2 playerPosition, Vector2[] enemies, Vector2 rectangleSize, int characterSize, int score, int highScore, int screenWidth, int screenHeight)
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.White);
            Raylib.DrawRectangle((int)playerPosition.X, (int)playerPosition.Y, characterSize, characterSize, Color.Red);

            foreach (var enemy in enemies)
            {
                Raylib.DrawRectangle((int)enemy.X, (int)enemy.Y, (int)rectangleSize.X, (int)rectangleSize.Y, Color.Black);  
            }

            Raylib.DrawText($"Score: {score}", 10, 10, 20, Color.Black);
            Raylib.DrawText($"High Score: {highScore}", 10, 30, 20, Color.Black);

            Raylib.EndDrawing();
        }

        public static void DrawGameOver(int screenWidth, int screenHeight, int score, int highScore)
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.White);
            Raylib.DrawText("GAME OVER", screenWidth / 2 - 100, screenHeight / 2 - 50, 40, Color.Red);
            Raylib.DrawText($"Score: {score}   High Score: {highScore}", screenWidth / 2 - 120, screenHeight / 2 + 20, 20, Color.Black);
            Raylib.DrawText("Press space to restart", screenWidth / 2 - 115, screenHeight / 2 + 50, 20, Color.Black);
            Raylib.DrawText("Press 2 to leave", screenWidth / 2 - 90, screenHeight / 2 + 80, 20, Color.Black);
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