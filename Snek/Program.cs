using System.ComponentModel;
using System;
using Raylib_cs;

namespace Snek
{
    class Program
    {
        enum GameScreens {
                start,
                game,
                gameOver
            }
        static void Main(string[] args)
        {
            //Saker att fixa:
                //Get snake to move
                //En random som genererar en matbit till en random ruta
                //ormen blir längre ifall man äter en matbit
                //genererar en ny matbit ifall förra är uppäten
                //lägger till ett block efter ormen om man äter en matbit
                //Game over om man krockar i väggen
                //Game over ifall man krockar med sig själv

            //Fixat:
                //En spelplan där ex antal pixlar motsvarar en ruta
                //En snake
                //start, game och game over screen som kan byta mellan varandra
                //Poängsystem


            Raylib.InitWindow(500, 500, "Snake Window");
            Raylib.SetTargetFPS(1);

            //Window w = new Window();
            Snake s = new Snake(3, 5);
            Food f = new Food();

            GameScreens screen = GameScreens.start;


            while (!Raylib.WindowShouldClose())
            {
                //Logik

                switch (screen){
                    case GameScreens.start:
                        if(Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
                        {
                            screen = GameScreens.game;
                        }
                        break;
                
                    case GameScreens.game:
                        s.Update();
                        break;
                    
                    case GameScreens.gameOver:
                        if(Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
                        {
                            screen = GameScreens.game;
                        }
                        break;
                }


                //Grafik

                Raylib.BeginDrawing();

                switch (screen)
                {
                case GameScreens.start:
                    Raylib.ClearBackground(Color.BLACK);
                    Raylib.DrawText("Press Enter to start the game", 10, 50, 30, Color.WHITE);
                    break;
                
                case GameScreens.game:
                    Raylib.ClearBackground(Color.DARKBLUE);
                    s.Draw();
                    break;
                    
                case GameScreens.gameOver:
                    Raylib.ClearBackground(Color.BLACK);
                    Raylib.DrawText("You lost!", 10, 10, 30, Color.WHITE);
                    Raylib.DrawText("Your score is " + s.foodCollected, 10, 60, 30, Color.WHITE);
                    Raylib.DrawText("Press ENTER to try again", 10, 110, 30, Color.WHITE);
                    break;
                }

                Raylib.EndDrawing();
            }
        }
    }
}
