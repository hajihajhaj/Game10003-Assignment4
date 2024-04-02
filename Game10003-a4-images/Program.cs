using Raylib_cs;
using System;
using System.IO;
using System.Net;
using System.Numerics;

namespace Game10003_a4_images;

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

        // load images
        Texture2D waffleTexture = Raylib.LoadTexture(waffleImagePath);

        float boardGameSize = 0.45f;

        // position of images
        Vector2 wafflePosition = new Vector2(-135, -5);

        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.RayWhite);
 
            // draw images
            Raylib.DrawTextureEx(waffleTexture, wafflePosition, 0.0f, boardGameSize, Color.White);

            Raylib.EndDrawing();
        }

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
