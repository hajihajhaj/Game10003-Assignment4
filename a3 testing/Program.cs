using Raylib_cs;
using System;
using System.Numerics;

namespace a3_testing
{
    internal class Program
    {
        enum GameState
        {
            Playing,
            GameOver
        }

        static string title = "dino game";

        static void Main(string[] args)
        {
            //game info
            const int screenWidth = 800;
            const int screenHeight = 400;
            const int characterSize = 20;
            const float jumpVelocity = -10;
            const int numberOfEnemies = 4;

            Raylib.InitWindow(screenWidth, screenHeight, title);
            Raylib.SetTargetFPS(60);

            Vector2 jump = new Vector2(200 / 2 - characterSize / 2, screenHeight - characterSize);
            Vector2 rectangleSize = new Vector2(characterSize, characterSize);

            Vector2[] enemies = new Vector2[numberOfEnemies];
            for (int i = 0; i < numberOfEnemies; i++)
            {
                enemies[i] = new Vector2(screenWidth + i * 200, screenHeight - characterSize);
            }

            float verticalVelocity = 0;
            float speed = 5f;
            int score = 0;
            int highScore = Visuals.LoadHighScore();
            bool inMenu = true;
            GameState gameState = GameState.Playing;

            //game loop
            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.White);

                switch (gameState)
                {
                    case GameState.Playing:
                    score++;

                    //update high score if player surpasses it
                    if (score > highScore)
                    {
                        highScore = score;
                        Visuals.SaveHighScore(highScore);
                    }

                    speed += 0.0015f;

                    // Controlling the jump mechanic
                    Movement.HandleInput(ref jump, screenHeight, characterSize, ref verticalVelocity, jumpVelocity);

                    // Controlling enemy movement for multiple enemies
                    Movement.GenerateEnemies(ref enemies, screenWidth, characterSize, ref speed);

                    foreach (var enemy in enemies)
                    {
                        if (Movement.CheckCollision(jump, rectangleSize, enemy, rectangleSize))
                        {
                            gameState = GameState.GameOver;
                            break;
                        }
                    }
                    //drawing the game
                        Visuals.DrawGame(jump, enemies, rectangleSize, characterSize, score, highScore, screenWidth, screenHeight);
                        break;

                    case GameState.GameOver:

                        Visuals.DrawGameOver(screenWidth, screenHeight, score, highScore);
                    if (Raylib.IsKeyPressed(KeyboardKey.Space))
                    {
                        //reseting the game when the player gets hit
                        gameState = GameState.Playing;
                        jump = new Vector2(200 / 2 - characterSize / 2, screenHeight - characterSize);
                        for (int i = 0; i < enemies.Length; i++)
                        {
                            enemies[i] = new Vector2(screenWidth + i * 200, screenHeight - characterSize);
                        }
                        verticalVelocity = 0;
                        speed = 5f;
                        score = 0;
                        inMenu = false;
                    }
                    else if (Raylib.IsKeyPressed(KeyboardKey.Two))
                    {
                        Raylib.CloseWindow();
                    }
                        break;
                }

                //starting menu
                while (inMenu)
                    {
                        Visuals.DrawMenu(screenWidth, screenHeight);
                        inMenu = Visuals.HandleMenuInput();
                    }
                }

                Raylib.CloseWindow();
            }
        }
    }