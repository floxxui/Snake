using System.Numerics;
using System;
using Raylib_cs;

namespace Snek
{
    public class Snake: GameObject
    {
        public int snakeLenth = 0;

        public Vector2 speedX = new Vector2(25, 0);
        public Vector2 speedY = new Vector2(0, 25);

        public Snake()
        {

        }

        public override void Movement()
        {
            // switch (switch_on)
            // {
            //     case Raylib.IsKeyDown(KeyboardKey.KEY_W):
            //         y++;
            //         break;
            //     case Raylib.IsKeyDown(KeyboardKey.KEY_A):
            //         x--;
            //         break;
            //     case Raylib.IsKeyDown(KeyboardKey.KEY_S):
            //         y--;
            //         break;
            //     case Raylib.IsKeyDown(KeyboardKey.KEY_D):
            //         x++;
            //         break;
            // }

            if(Raylib.IsKeyDown(KeyboardKey.KEY_W) || Raylib.IsKeyDown(KeyboardKey.KEY_UP))
            {
                y++;
            }
            if(Raylib.IsKeyDown(KeyboardKey.KEY_A) || Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
            {
                x--;
            }
            if(Raylib.IsKeyDown(KeyboardKey.KEY_S) || Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
            {
                y--;
            }
            if(Raylib.IsKeyDown(KeyboardKey.KEY_D) || Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
            {
                x++;
            }
        }
    }
}
