using System.Security.AccessControl;
using System.Numerics;
using System;
using System.Timers;
using Raylib_cs;

namespace Snek
{
    public class Snake
    {
        public int xPos;
        public int yPos; //Ormens position
        public int score = 0; //Antal mat man har ätit
        public string currentDirection = "right"; //berättar vart ormen är påväg. Används för att kunna få ormen att fortsätta röra sig åt det hållet
        public int scale = 25; //Ser till att jag kan ha ett rutnät på 25*25. Skalar upp så att ormens movement rör sig enligt rutnätet
        private Rectangle snakeHead; //Skapar ett ormhuvud
        private Timer ticUpdate = new Timer(); //Kolla upp hur man använder

        KeyboardKey upKey;
        KeyboardKey downKey;
        KeyboardKey leftKey;
        KeyboardKey rightKey; //alla movementbuttons som kommer behövas

        public Snake(int xStart, int yStart, KeyboardKey up, KeyboardKey down, KeyboardKey left, KeyboardKey right)
        {
            xPos = xStart;
            yPos = yStart; //ger ormen en startposition
            upKey = up;
            downKey = down;
            leftKey = left;
            rightKey = right; //ger knapparna till ormens movement
            snakeHead = new Rectangle(xPos*scale, yPos*scale, 25, 25); //definierar ormhuvudets startposition och storlek
        }

        public void Draw()
        {
            Raylib.DrawRectangleRec(snakeHead, Color.YELLOW); //ritar ut ormhuvudet
        }

        public void Update() 
        {
            if(Raylib.IsKeyPressed(upKey))
            {
                snakeHead.y -= 1*scale; //FIXA
                currentDirection = "up"; //visar att ormen är just nu påväg uppåt

                if(snakeHead.y <= 0 * scale)
                {
                    snakeHead.y = 0*scale; //Gör så att ormen inte kan röra sig utanför windown. Kommer bli utbytt mot death ifall det finns tid
                }
            }
            if(Raylib.IsKeyPressed(leftKey))
            {
                snakeHead.x -= 1*scale;//FIXA
                currentDirection = "left"; //visar att ormen är just nu påväg åt vänster

                if(snakeHead.x <= 0 * scale)
                {
                    snakeHead.x = 0*scale; //Gör så att ormen inte kan röra sig utanför windown. Kommer bli utbytt mot death ifall det finns tid
                }
            }
            if(Raylib.IsKeyPressed(downKey))
            {
                snakeHead.y += 1*scale;//FIXA
                currentDirection = "down"; //visar att ormen är just nu påväg nedåt

                if(snakeHead.y >= 24*scale)
                {
                    snakeHead.y = 24*scale; //Gör så att ormen inte kan röra sig utanför windown. Kommer bli utbytt mot death ifall det finns tid
                }
            }
            if(Raylib.IsKeyPressed(rightKey))
            {
                snakeHead.x += 1*scale;//FIXA
                currentDirection = "right"; //visar att ormen är just nu påväg åt höger

                if(snakeHead.x >= 24 * scale)
                {
                    snakeHead.x = 24 * scale; //Gör så att ormen inte kan röra sig utanför windown. Kommer bli utbytt mot death ifall det finns tid
                }
            }
        }
    }
}
