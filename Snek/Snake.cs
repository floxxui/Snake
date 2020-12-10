using System.Numerics;
using System;
using Raylib_cs;

namespace Snek
{
    public class Snake: GameObject
    {
        Random generator = new Random();
        public int snakeLenth = 0;
        public int xPos;
        public int yPos;
        public Vector2 speedX = new Vector2(25, 0);
        public Vector2 speedY = new Vector2(0, 25);

        public Snake()
        {
            xPos = generator.Next(20);
            yPos = generator.Next(20);
        }

        public void GetRandomPos(){

        }

        public void Movement()
        {
            // switch (switch_on)
            // {
            //     case Raylib.IsKeyDown(KeyboardKey.KEY_W):
            //         posY++;
            //         break;
            //     case Raylib.IsKeyDown(KeyboardKey.KEY_A):
            //         posX--;
            //         break;
            //     case Raylib.IsKeyDown(KeyboardKey.KEY_S):
            //         posY--;
            //         break;
            //     case Raylib.IsKeyDown(KeyboardKey.KEY_D):
            //        posX++;
            //         break;
            // }

            if(Raylib.IsKeyDown(KeyboardKey.KEY_W) || Raylib.IsKeyDown(KeyboardKey.KEY_UP))
            {
                yPos++;
            }
            if(Raylib.IsKeyDown(KeyboardKey.KEY_A) || Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
            {
                xPos--;
            }
            if(Raylib.IsKeyDown(KeyboardKey.KEY_S) || Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
            {
                yPos--;
            }
            if(Raylib.IsKeyDown(KeyboardKey.KEY_D) || Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
            {
                xPos++;
            }
        }
    }
}
