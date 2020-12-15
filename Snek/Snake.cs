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
        public Vector2 speedX = new Vector2(25, 0);
        public Vector2 speedY = new Vector2(0, 25);

        public Snake(int xStart, int yStart)
        {
            xPos = xStart;
            yPos = yStart;
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
