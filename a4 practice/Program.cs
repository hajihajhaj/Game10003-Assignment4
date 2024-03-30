﻿using Raylib_cs;
using System;
using System.IO;
using System.Net;
using System.Numerics;

class Program
{
    static void Main()
    {
        const int screenWidth = 600;
        const int screenHeight = 600;

        Raylib.InitWindow(screenWidth, screenHeight, "Tic Tac Toe");
        Raylib.SetTargetFPS(60);

        string saveDirectory = "C:/Users/hajar/downloads/tictactoe";

        // Download images from URLs and save them locally
        string strawberryImagePath = DownloadImage("https://i.postimg.cc/PJBX7rTZ/strawberry.png", saveDirectory);
        string blueberryImagePath = DownloadImage("https://i.postimg.cc/ncDcD7G1/blueberry.png", saveDirectory);
        string waffleImagePath = DownloadImage("https://i.postimg.cc/x878S3yX/waffle.png", saveDirectory);

        // Load images
        Texture2D strawberryTexture = Raylib.LoadTexture(strawberryImagePath);
        Texture2D blueberryTexture = Raylib.LoadTexture(blueberryImagePath);
        Texture2D waffleTexture = Raylib.LoadTexture(waffleImagePath);

        float characterSize = 0.15f;
        float boardGameSize = 0.45f;

        // Position of images
        Vector2[] strawberryPositions = new Vector2[]
        {
            new Vector2(-30, 20),
            new Vector2(-30, 200),
            new Vector2(-30, 380),
            new Vector2(150, 20),
            new Vector2(150, 200),
            new Vector2(150, 380),
            new Vector2(330, 20),
            new Vector2(330, 200),
            new Vector2(330, 380),
        };

        Vector2[] blueberryPositions = new Vector2[]
        {
            new Vector2(-20, 20),
            new Vector2(-20, 200),
            new Vector2(-20, 380),
            new Vector2(160, 20),
            new Vector2(160, 200),
            new Vector2(160, 380),
            new Vector2(340, 20),
            new Vector2(340, 200),
            new Vector2(340, 380),
        };

        Vector2 wafflePosition = new Vector2(-135, -5);

        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.RayWhite);

            // Draw images 
            Raylib.DrawTextureEx(waffleTexture, wafflePosition, 0.0f, boardGameSize, Color.White);

            foreach (Vector2 position in strawberryPositions)
            {
                Raylib.DrawTextureEx(strawberryTexture, position, 0.0f, characterSize, Color.White);
            }

            foreach (Vector2 position in blueberryPositions)
            {
                Raylib.DrawTextureEx(blueberryTexture, position, 0.0f, characterSize, Color.White);
            }

            Raylib.EndDrawing();
        }

        // Unload textures
        Raylib.UnloadTexture(strawberryTexture);
        Raylib.UnloadTexture(blueberryTexture);
        Raylib.UnloadTexture(waffleTexture);

        Raylib.CloseWindow();
    }

    static string DownloadImage(string url, string saveDirectory)
    {
        string fileName = Path.GetFileName(new Uri(url).AbsolutePath);
        string imagePath = Path.Combine(saveDirectory, fileName);

        return imagePath;
    }
}