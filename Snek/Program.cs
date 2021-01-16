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
                gameOver //olika gamestates. Gör det möjligt att förflytta sig mellan dem 
            }
        static void Main(string[] args)
        {
            //Saker att fixa:
                //kommentarer             
                //lägger till ett block efter ormen om man äter en matbit
                //fixa svansens position
                //Game over ifall man krockar med sig själv

            //Fixat:                               
                //En spelplan där ex antal pixlar motsvarar en ruta
                //En snake
                //Get snake to move
                //Fixa ormens movement gråter asså mannen walla                
                //En random som genererar en matbit till en random ruta
                //genererar en ny matbit ifall förra är uppäten
                //Poängsystem
                //Game over om man krockar i väggen
                //Möjligheten att befinna sig längst ut utan att dö
                //start, game och game over screen som kan byta mellan varandra

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
                        s.Update(); //Beräknar vilken tid ormen ska byta position och vart den ska förflytta sig 
                        if (s.xPos == f.xPos && s.yPos == f.yPos) //checkar ifall snakeHead och foodPiece delar position
                        {
                            f.Update(); //Ger foodPiece en ny position
                            s.score++; //Lägger till ett poäng. Ny klass? Till svans?
                        }
                        if (s.isDead == true)
                        {
                            screen = GameScreens.gameOver;
                        }
                        break;
                    
                    case GameScreens.gameOver:
                        if(Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
                        {
                            s.isDead = false;
                            s.score = 0;
                            screen = GameScreens.game; //Ifall man klickar på enter ändras applikationens gamestate till game
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
                    Raylib.ClearBackground(Color.BLACK);
                    Raylib.DrawRectangle(25, 25, 575, 575, Color.DARKBLUE);
                    // Raylib.DrawText("x = " + f.xPos + ", y = " + f.yPos, 10, 40, 30, Color.WHITE);
                    // Raylib.DrawText("x = " + s.xPos + ", y = " + s.yPos, 10, 70, 30, Color.WHITE); //för debugging
                    Raylib.DrawText(Convert.ToString(s.score), 6, 6, 30, Color.WHITE);
                    f.Draw();
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
