using System.Collections.Generic;
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
        //public List<Rectangle> snakeLength = new List<Rectangle>(); //Ritar ut en ny ruta varje gång man har ätit en matbit [UNDER CONSTRUCTION]
        private float maxFrame = 0.30f; //Hur många frames som ska passera innan spelet uppdaterar position
        private float currentFrame = 0.30f; //Vilken frame den är på för tillfället
        public string currentDirection = "right"; //berättar vart ormen är påväg. Används för att kunna få ormen att fortsätta röra sig åt det hållet
        public int scale = 25; //Ser till att jag kan ha ett rutnät på 25*25. Skalar upp så att ormens movement rör sig enligt rutnätet
        public bool isAlive = true; //Beräknar om man lever eller inte
        private bool pickedDirection = false; //gör så att man endast kan välja riktning innan positionen uppdateras
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
            // if (score >= 0)
            // {
            //     foreach (var i in snakeLength)
            //     {
            //         Raylib.DrawRectangleRec(snakeLength[], Color.WHITE);
            //     }
            // } 
        }

        public void Update() 
        {
            //Spelarinput

            if (pickedDirection == false) //Man kan byta riktning så länge man inte gjort det innan senaste positionsupdate
            {
                if(Raylib.IsKeyPressed(upKey))
                {
                    if (currentDirection == "left" || currentDirection == "right")
                    {
                        currentDirection = "up"; //ändrar ormens direction uppåt om den tidigare åkt åt vänster eller höger
                        pickedDirection = true; //Gör att man inte kan byta direction igen
                    }
                }
                else if(Raylib.IsKeyPressed(leftKey))
                {
                    if (currentDirection == "up" || currentDirection == "down")
                    {
                        currentDirection = "left"; //ändrar ormens direction åt vänster om den tidigare åkt uppåt eller nedåt
                        pickedDirection = true; //Gör att man inte kan byta direction igen
                    }
                }
                else if(Raylib.IsKeyPressed(downKey))
                {
                    if (currentDirection == "left" || currentDirection == "right")
                    {
                        currentDirection = "down"; //ändrar ormens direction nedåt om den tidigare åkt åt vänster eller höger
                        pickedDirection = true; //Gör att man inte kan byta direction igen
                    }
                }
                else if(Raylib.IsKeyPressed(rightKey))
                {
                    if(currentDirection == "up" || currentDirection == "down")
                    {
                        currentDirection = "right"; //ändrar ormens direction åt höger om den tidigare åkt uppåt eller nedåt
                        pickedDirection = true; //Gör att man inte kan byta direction igen
                    }
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
                    pickedDirection = false; //Gör det möjligt att ändra direction igen

                    if(snakeHead.y <= 0 * scale)
                    {
                        isAlive = false; //om man åker in i kanten dör man
                        snakeHead.x = 3*scale;
                        snakeHead.y = 5*scale; //Ändrar tillbaka snakens position till start position
                    }
                }
                else if (currentDirection == "left")
                {
                    snakeHead.x -= 1*scale; //Tar bort 25 från x-värdet, vilket får snaken att flytta 1 steg åt vänster
                    xPos = (int) snakeHead.x; //Tvingar floaten att convertera till en int för att xPos ska kunna kopiera värdet
                    pickedDirection = false; //Gör det möjligt att ändra direction igen

                    if(snakeHead.x <= 0 * scale)
                    {
                        isAlive = false; //om man åker in i kanten dör man
                        snakeHead.x = 3*scale;
                        snakeHead.y = 5*scale; //Ändrar tillbaka snakens position till start position
                    }
                }
                else if (currentDirection == "down")
                {
                    snakeHead.y += 1 * scale; //Lägger till 25 på y-värdet, vilket får snaken att flytta 1 steg nedåt
                    yPos = (int) snakeHead.y; //Tvingar floaten att convertera till en int för att xPos ska kunna kopiera värdet
                    pickedDirection = false; //Gör det möjligt att ändra direction igen

                    if(snakeHead.y >= 24 * scale)
                    {
                        isAlive = false; //om man åker in i kanten dör man
                        snakeHead.x = 3*scale;
                        snakeHead.y = 5*scale; //Ändrar tillbaka snakens position till start position             
                    }
                }
                else if (currentDirection == "right")
                {
                    snakeHead.x += 1 * scale; //Lägger till 25 på x-värdet, vilket får snaken att flytta 1 steg åt höger
                    xPos = (int) snakeHead.x; //Tvingar floaten att convertera till en int för att xPos ska kunna kopiera värdet
                    pickedDirection = false; //Gör det möjligt att ändra direction igen

                    if(snakeHead.x >= 24 * scale)
                    {
                        isAlive = false; //om man åker in i kanten dör man
                        snakeHead.x = 3*scale;
                        snakeHead.y = 5*scale; //Ändrar tillbaka snakens position till start position
                    }
                }
                currentFrame = maxFrame; //gör det möjligt för if-statementen att köras igen efter att värdet nått 0
                //Hur man får positionen att bytas 3/10 sekund hämtade jag från C#-referens materialet
            }
        }

        // public void ExtendSnake()
        // {
        //     snakeLength.Add(new Rectangle(xPos*scale, yPos*scale, 25, 25));
        // }
    }
}
