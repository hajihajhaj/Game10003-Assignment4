using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace a3_testing
{
    internal class Player
    {
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
    }
}
