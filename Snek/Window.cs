using System;
using Raylib_cs;

namespace Snek
{
    public class Window
    {
        public Window()
        {
            //Skapar en window

            Raylib.InitWindow(500, 500, "Snake Window");

            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.DARKBLUE);
                Raylib.EndDrawing();
            }
        }

        public GameWindow()
        {
            //Skapar ett rutnät. Rutnätet är 10x10. Detta gör att man inte kan befinna sig mellan två tiles, 
            //precis som att maten inte kan göra det heller

            
        }
    }
}
