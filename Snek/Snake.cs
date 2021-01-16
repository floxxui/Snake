using System.Security.AccessControl;
using System.Numerics;
using System;
using Raylib_cs;

namespace Snek
{
    public class Snake
    {
        public int xPos;
        public int yPos; //Ormens position
        public int score = 0; //Antal mat man har ätit
        private float maxFrame = 0.30f;
        private float currentFrame = 0.30f;
        public string currentDirection = "right"; //berättar vart ormen är påväg. Används för att kunna få ormen att fortsätta röra sig åt det hållet
        public int scale = 25; //Ser till att jag kan ha ett rutnät på 25*25. Skalar upp så att ormens movement rör sig enligt rutnätet
        public bool isDead = false;
        private Rectangle snakeHead; //Skapar ett ormhuvud
        private KeyboardKey upKey;
        private KeyboardKey downKey;
        private KeyboardKey leftKey;
        private KeyboardKey rightKey; //alla movementbuttons som kommer behövas

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
            //Spelarinput

            if(Raylib.IsKeyPressed(upKey))
            {
                if (currentDirection == "left" || currentDirection == "right")
                {
                    currentDirection = "up"; //ändrar ormens direction uppåt om den tidigare åkt åt vänster eller höger
                }
            }
            else if(Raylib.IsKeyPressed(leftKey))
            {
                if (currentDirection == "up" || currentDirection == "down")
                {
                    currentDirection = "left"; //ändrar ormens direction åt vänster om den tidigare åkt uppåt eller nedåt
                }
            }
            else if(Raylib.IsKeyPressed(downKey))
            {
                if (currentDirection == "left" || currentDirection == "right")
                {
                    currentDirection = "down"; //ändrar ormens direction nedåt om den tidigare åkt åt vänster eller höger
                }
            }
            else if(Raylib.IsKeyPressed(rightKey))
            {
                if(currentDirection == "up" || currentDirection == "down")
                {
                    currentDirection = "right"; //ändrar ormens direction åt höger om den tidigare åkt uppåt eller nedåt
                }
            }

            //Tidsberäkning och positionsbyte

            currentFrame -= Raylib.GetFrameTime();
            if (currentFrame < 0)
            {
                if (currentDirection == "up")
                {
                    snakeHead.y -= 1*scale; //Tar bort 25 från y-värdet, vilket får snaken att flytta 1 steg uppåt. Eftersom pixel (1, 1) är längst upp vid vänstra hörnet så kommer y-värdet att aggera tvärt emot från kordinatsystemets y-värde
                    yPos = (int) snakeHead.y; //visar att ormen är just nu påväg uppåt

                    if(snakeHead.y <= 0 * scale)
                    {
                        isDead = true;
                        snakeHead.x = 3*scale;
                        snakeHead.y = 5*scale;
                    }
                }
                else if (currentDirection == "left")
                {
                    snakeHead.x -= 1*scale; //Tar bort 25 från x-värdet, vilket får snaken att flytta 1 steg åt vänster
                    xPos = (int) snakeHead.x; //Tvingar floaten att convertera till en int för att xPos ska kunna kopiera värdet

                    if(snakeHead.x <= 0 * scale)
                    {
                        isDead = true;
                        snakeHead.x = 3*scale;
                        snakeHead.y = 5*scale;
                    }
                }
                else if (currentDirection == "down")
                {
                    snakeHead.y += 1 * scale; //Lägger till 25 på y-värdet, vilket får snaken att flytta 1 steg nedåt
                    yPos = (int) snakeHead.y; //Tvingar floaten att convertera till en int för att xPos ska kunna kopiera värdet

                    if(snakeHead.y >= 24 * scale)
                    {
                        isDead = true;
                        snakeHead.x = 3*scale;
                        snakeHead.y = 5*scale;                    
                    }
                }
                else if (currentDirection == "right")
                {
                    snakeHead.x += 1 * scale; //Lägger till 25 på x-värdet, vilket får snaken att flytta 1 steg åt höger
                    xPos = (int) snakeHead.x; //Tvingar floaten att convertera till en int för att xPos ska kunna kopiera värdet

                    if(snakeHead.x >= 24 * scale)
                    {
                        isDead = true;
                        snakeHead.x = 3*scale;
                        snakeHead.y = 5*scale;
                    }
                }
                currentFrame = maxFrame; //gör det möjligt för if-statementen att köras igen efter att värdet nått 0
                //Hur man får positionen att bytas 3/10 sekund hämtade jag från C#-referens materialet
            }
        }
    }
}
