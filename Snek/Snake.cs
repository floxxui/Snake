using System.Numerics;
using System;
using Raylib_cs;

namespace Snek
{
    public class Snake: GameObject
    {
        public int foodCollected = 0;
        public int xPos;
        public int yPos;
        public int scale = 20;
        private Rectangle rectangle;

        KeyboardKey upKey;
        KeyboardKey downKey;
        KeyboardKey leftKey;
        KeyboardKey rightKey;

        public Snake(int xStart, int yStart, KeyboardKey up, KeyboardKey down, KeyboardKey left, KeyboardKey right)
        {
            xPos = xStart;
            yPos = yStart;
            upKey = up;
            downKey = down;
            leftKey = left;
            rightKey = right;
            rectangle = new Rectangle(xPos*scale, yPos*scale, 25, 25);
        }

        // public void Movement()
        // {
        //     switch (switch_on)
        //     {
        //         case Raylib.IsKeyDown(KeyboardKey.KEY_W):
        //             posY++;
        //             break;
        //         case Raylib.IsKeyDown(KeyboardKey.KEY_A):
        //             posX--;
        //             break;
        //         case Raylib.IsKeyDown(KeyboardKey.KEY_S):
        //             posY--;
        //             break;
        //         case Raylib.IsKeyDown(KeyboardKey.KEY_D):
        //            posX++;
        //             break;
        //     }

        // }

        public void Draw()
        {
            Raylib.DrawRectangleRec(rectangle, Color.YELLOW);
        }

        public void Update() 
        {
            if(Raylib.IsKeyDown(KeyboardKey.KEY_W))
            {
                yPos++;
            }
            if(Raylib.IsKeyDown(KeyboardKey.KEY_A))
            {
                xPos--;
            }
            if(Raylib.IsKeyDown(KeyboardKey.KEY_S))
            {
                yPos--;
            }
            if(Raylib.IsKeyDown(KeyboardKey.KEY_D))
            {
                xPos++;
            }            
        }
    }
}
