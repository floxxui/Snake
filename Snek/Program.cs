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
                gameOver //olika game states. Gör så att man kan förflytta sig mellan dem 
            }
        static void Main(string[] args)
        {
            //Saker att fixa:
                //kommentarer
                //Fixa ormens movement gråter asså mannen walla
                //En random som genererar en matbit till en random ruta
                //ormen blir längre ifall man äter en matbit
                //genererar en ny matbit ifall förra är uppäten
                //lägger till ett block efter ormen om man äter en matbit
                //Game over om man krockar i väggen
                //Game over ifall man krockar med sig själv

            //Fixat:
                //Get snake to move
                //En spelplan där ex antal pixlar motsvarar en ruta
                //En snake
                //start, game och game over screen som kan byta mellan varandra
                //Poängsystem


            Raylib.InitWindow(625, 625, "Snake Window"); //Skapar snake window som är 625 * 625 
            Raylib.SetTargetFPS(60); //gör så att applikationen försöker runna i 60 FPS

            Snake s = new Snake(3, 5, KeyboardKey.KEY_W, KeyboardKey.KEY_S, KeyboardKey.KEY_A, KeyboardKey.KEY_D); //Skapar en snake med definierade värden
            Food f = new Food(); //skapar en matbit. Detta kan ändras snart

            GameScreens screen = GameScreens.start; //sätter första gamestate till start screenen


            while (!Raylib.WindowShouldClose())
            {
                //Logik

                switch (screen){
                    case GameScreens.start:
                        if(Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
                        {
                            screen = GameScreens.game; //Ifall man klickar på enter ändras applikationens gamestate till game
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
                    Raylib.DrawText("Press Enter to start the game", 65, 50, 30, Color.WHITE);
                    break;
                
                case GameScreens.game:
                    Raylib.ClearBackground(Color.DARKBLUE);
                    s.Draw();
                    break;
                    
                case GameScreens.gameOver:
                    Raylib.ClearBackground(Color.BLACK);
                    Raylib.DrawText("You lost!", 250, 110, 30, Color.WHITE);
                    Raylib.DrawText("Your score is " + s.score, 200, 160, 30, Color.WHITE);
                    Raylib.DrawText("Press ENTER to try again", 100, 210, 30, Color.WHITE);
                    break;
                }

                Raylib.EndDrawing();
            }
        }
    }
}
