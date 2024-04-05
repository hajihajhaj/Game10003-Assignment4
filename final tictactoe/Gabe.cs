using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
﻿using System;
using Raylib_cs;
using System.Net;

namespace final_tictactoe
{
    public static class Gabe
    {
        public static void PlayAudio(string url)

        {
            // pick a song // has to be mp3 on the web
            string localFilePath = "";
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(url, localFilePath);

            }

            Raylib.InitWindow(800, 450, "Gameaudio");

            Music music = Raylib.LoadMusicStream(url);

            Raylib.PlayMusicStream(music);

            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.White);
                Raylib.EndDrawing();

                Raylib.UpdateMusicStream(music);
                Raylib.PlayMusicStream(music);

                if (Raylib.IsKeyPressed(KeyboardKey.A))
                {
                    if (Raylib.IsMusicStreamPlaying(music))
                        Raylib.PauseMusicStream(music);
                    else
                        Raylib.ResumeMusicStream(music);
                }

                if (Raylib.IsKeyPressed(KeyboardKey.Escape))
                {
                    Raylib.StopMusicStream(music);
                }
            }

            Raylib.StopMusicStream(music);
            Raylib.UnloadMusicStream(music);
            Raylib.CloseWindow();
        }
    }
}