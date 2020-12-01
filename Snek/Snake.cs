using System.Numerics;
using System;
using Raylib_cs;

namespace Snek
{
    public class Snake: GameObject
    {
        public int snakeLenth = 0;

        public Vector2 speedX = new Vector2(25, 0);
        public Vector2 speedY = new Vector2(0, 25);

        public Snake()
        {

        }

        public void Movement(){
            if(Raylib.IsKeyDown(KeyboardKey.KEY_W) || Raylib.IsKeyDown(KeyboardKey.KEY_UP))
            {
                
            }
            if(Raylib.IsKeyDown(KeyboardKey.KEY_A) || Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
            {
                
            }
            if(Raylib.IsKeyDown(KeyboardKey.KEY_S) || Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
            {
                
            }
            if(Raylib.IsKeyDown(KeyboardKey.KEY_D) || Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
            {
                
            }
        }
    }
}
