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
        string strawberryImagePath = DownloadImage("https://i.postimg.cc/PJBX7rTZ/strawberry.png", saveDirectory);
        string blueberryImagePath = DownloadImage("https://i.postimg.cc/ncDcD7G1/blueberry.png", saveDirectory);
        string syrupImagePath = DownloadImage("https://i.postimg.cc/bvhj252j/syrup.png", saveDirectory);
        string syrupImagePath2 = DownloadImage("https://i.postimg.cc/V6c1JFHh/syrup2.png", saveDirectory);
        string syrupImagePath3 = DownloadImage("https://i.postimg.cc/wTPd4btS/syrup3.png", saveDirectory);
        string syrupImagePath4 = DownloadImage("https://i.postimg.cc/Jn1wHfgB/syrup4.png", saveDirectory);

        // load images
        Texture2D waffleTexture = Raylib.LoadTexture(waffleImagePath);
        Texture2D strawberryTexture = Raylib.LoadTexture(strawberryImagePath);
        Texture2D blueberryTexture = Raylib.LoadTexture(blueberryImagePath);
        Texture2D syrupTexture = Raylib.LoadTexture(syrupImagePath);
        Texture2D syrupTexture2 = Raylib.LoadTexture(syrupImagePath2);
        Texture2D syrupTexture3 = Raylib.LoadTexture(syrupImagePath3);
        Texture2D syrupTexture4 = Raylib.LoadTexture(syrupImagePath4);

        float characterSize = 0.15f;
        float boardGameSize = 0.45f;
        float syrupsize = 0.5f;

        // position of images
        Vector2 wafflePosition = new Vector2(-135, -5);

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

        Vector2[] syrupPositions = new Vector2[]
        {
            new Vector2(-180, -30),
            new Vector2(0, -30),
            new Vector2(-360, -30),
        };

        Vector2[] syrupPositions2 = new Vector2[]
        {
            new Vector2(-190, -30),
            new Vector2(-190, -210),
            new Vector2(-190, 150),
        };

        Vector2[] syrupPositions3 = new Vector2[]
        {
            new Vector2(-180, -60),

        };

        Vector2[] syrupPositions4 = new Vector2[]
        {
            new Vector2(-180, -50),
        };

        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.RayWhite);
 
            // draw images
            Raylib.DrawTextureEx(waffleTexture, wafflePosition, 0.0f, boardGameSize, Color.White);

            foreach (Vector2 position in strawberryPositions)
            {
                Raylib.DrawTextureEx(strawberryTexture, position, 0.0f, characterSize, Color.White);
            }

            foreach (Vector2 position in blueberryPositions)
            {
                Raylib.DrawTextureEx(blueberryTexture, position, 0.0f, characterSize, Color.White);
            }

            foreach (Vector2 position in syrupPositions)
            {
                Raylib.DrawTextureEx(syrupTexture, position, 0.0f, syrupsize, Color.White);
            }

            foreach (Vector2 position in syrupPositions2)
            {
                Raylib.DrawTextureEx(syrupTexture2, position, 0.0f, syrupsize, Color.White);
            }

            foreach (Vector2 position in syrupPositions3)
            {
                Raylib.DrawTextureEx(syrupTexture3, position, 0.0f, syrupsize, Color.White);
            }

            foreach (Vector2 position in syrupPositions4)
            {
                Raylib.DrawTextureEx(syrupTexture4, position, 0.0f, syrupsize, Color.White);
            }

            Raylib.EndDrawing();
        }
        
        Raylib.UnloadTexture(waffleTexture);
        Raylib.UnloadTexture(strawberryTexture);
        Raylib.UnloadTexture(blueberryTexture);
        Raylib.UnloadTexture(syrupTexture);
        Raylib.UnloadTexture(syrupTexture2);
        Raylib.UnloadTexture(syrupTexture3);
        Raylib.UnloadTexture(syrupTexture4);

        Raylib.CloseWindow();
    }

    static string DownloadImage(string url, string saveDirectory)
    {
        string fileName = Path.GetFileName(new Uri(url).AbsolutePath);
        string imagePath = Path.Combine(saveDirectory, fileName);

        return imagePath;
    }
}
