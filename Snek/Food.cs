using System;
using Raylib_cs;

namespace Snek
{
    public class Food
    {
        public int xPos;
        public int yPos; //x och y position på matbitarna
        public int scale = 20; //scalear upp så att snakens movement anpassas till window.
        private Random generator = new Random();
        private Rectangle foodPiece; //Används för att rita ut maten

        public Food()
        {
            xPos = generator.Next(1, 25);
            yPos = generator.Next(1, 25); //random genererar en x och y position
            foodPiece = new Rectangle(xPos*scale, yPos*scale, 25, 25); //definierar matbiten position och storlek
        }

    }
}
