using System;
using Raylib_cs;

namespace Snek
{
    public class GameObject
    {
        protected Random generator = new Random();

        public void RandomPos(){
        }

        public void Draw(){
            Raylib.DrawRectangle(25, 25, 25, 25, Color.RED);
        }

    }
}
