using System;
using Raylib_cs;

namespace Snek
{
    class Program
    {
        static void Main(string[] args)
        {
            Raylib.InitWindow(500, 500, "Snake Window");

            while (!Raylib.WindowShouldClose()){
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.DARKBLUE);
                Raylib.EndDrawing();
            }
        }
    }
}
