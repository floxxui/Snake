using System.Reflection.Metadata.Ecma335;
using System;
using Raylib_cs;

namespace Snek
{
    public class Food
    {
        public int xPos;
        public int yPos; //x och y position på matbitarna
        public int scale = 25; //scalear upp så att snakens movement anpassas till window.
        private Random generator = new Random();
        private Rectangle foodPiece; //Används för att rita ut maten

        public Food()
        {
            xPos = generator.Next(1, 24) * scale;
            yPos = generator.Next(1, 24) * scale; //random genererar en x och y position
            foodPiece = new Rectangle(xPos, yPos, 25, 25); //definierar matbiten position och storlek
        }

        public void Draw()
        {
            Raylib.DrawRectangleRec(foodPiece, Color.RED); //Ritar ut matbiten
        }

        public void Update()
        {
            foodPiece.x = generator.Next(1, 24) * scale;
            foodPiece.y = generator.Next(1, 24) * scale; //genererar en ny position
            xPos = (int) foodPiece.x;
            yPos = (int) foodPiece.y; //Tvingar float värdet att konvertera till en int så att nya värdet kan jämföras med snakens position
        }
    }
}
