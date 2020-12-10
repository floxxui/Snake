using System;
using Raylib_cs;

namespace Snek
{
    public class GameObject
    {
        protected Random generator = new Random();
        public int scale = 20;
        public int x;
        public int y;

        public virtual void RandomPos()
        {
            x = generator.Next(20);
            y = generator.Next(20);
        }

        public virtual void Draw()
        {
            Raylib.DrawRectangle(x*scale, y*scale, 25, 25, Color.RED);
        }

        public virtual void DrawAll()
        {

        }

    }
}
