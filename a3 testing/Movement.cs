using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace a3_testing
{
    internal class Movement
    {
        private static Random rand = new Random();
        public static void HandleInput(ref Vector2 jump, float screenHeight, int characterSize, ref float verticalVelocity, float jumpVelocity)
        {
            if (Raylib.IsKeyPressed(KeyboardKey.Space))
            {
                if (jump.Y >= screenHeight - characterSize)
                {
                    verticalVelocity = jumpVelocity;
                }
            }
            verticalVelocity += 0.6f;

            jump.Y += verticalVelocity;

            if (jump.Y >= screenHeight - characterSize)
            {
                jump.Y = screenHeight - characterSize;
                verticalVelocity = 0;
            }
        }

        public static void GenerateEnemies(ref Vector2[] enemies, int screenWidth, int characterSize, ref float speed)
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].X -= speed; 

                if (enemies[i].X < -characterSize)
                {
                    enemies[i].X = screenWidth + rand.Next(100, 300); 
                }
            }
        }

        public static bool CheckCollision(Vector2 position1, Vector2 size1, Vector2 position2, Vector2 size2)
        {
            float leftEdge1 = position1.X;
            float rightEdge1 = position1.X + size1.X;
            float topEdge1 = position1.Y;
            float bottomEdge1 = position1.Y + size1.Y;

            float leftEdge2 = position2.X;
            float rightEdge2 = position2.X + size2.X;
            float topEdge2 = position2.Y;
            float bottomEdge2 = position2.Y + size2.Y;

            bool doesOverlapLeft = leftEdge1 < rightEdge2;
            bool doesOverlapRight = rightEdge1 > leftEdge2;
            bool doesOverlapTop = topEdge1 < bottomEdge2;
            bool doesOverlapBottom = bottomEdge1 > topEdge2;

            return doesOverlapLeft && doesOverlapRight && doesOverlapTop && doesOverlapBottom;
        }
    }
}