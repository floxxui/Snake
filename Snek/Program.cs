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
                //lägger till ett block efter ormen om man äter en matbit
                //fixa svansens position
                //Game over ifall man krockar med sig själv

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
                        if (s.isAlive == false)
                        {
                            screen = GameScreens.gameOver; //Om man dör ändras gamestate till game over
                        }
                        break;
                    
                    case GameScreens.gameOver:
                        if(Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
                        {
                            s.isAlive = true; //Ifall man klickar på enter kommer ormen räknas som levande igen
                            s.score = 0; //Nollställer score när man har dött
                            screen = GameScreens.game; //Applikationen ändrar sitt gamestate till game
                        }
                        break;
                } 

                //Grafik

                Raylib.BeginDrawing();

                switch (screen)
                {
                case GameScreens.start:
                    Raylib.ClearBackground(Color.BLACK);
                    Raylib.DrawText("Press Enter to start the game", 65, 50, 30, Color.WHITE); //Skriver ut hur man startar spelet
                    break;
                
                case GameScreens.game:
                    Raylib.ClearBackground(Color.BLACK); //Boarder
                    Raylib.DrawRectangle(25, 25, 575, 575, Color.DARKBLUE); //Spelplan
                    // Raylib.DrawText("x = " + f.xPos + ", y = " + f.yPos, 10, 40, 30, Color.WHITE);
                    // Raylib.DrawText("x = " + s.xPos + ", y = " + s.yPos, 10, 70, 30, Color.WHITE); //för debugging
                    Raylib.DrawText(Convert.ToString(s.score), 6, 6, 30, Color.WHITE); //Skriver ut spelarens score
                    f.Draw(); //Ritar ut maten
                    s.Draw(); //Ritar ut ormen
                    break;
                    
                case GameScreens.gameOver:
                    Raylib.ClearBackground(Color.BLACK);
                    Raylib.DrawText("You lost!", 250, 110, 30, Color.WHITE);
                    Raylib.DrawText("Your score is " + s.score, 200, 160, 30, Color.WHITE);
                    Raylib.DrawText("Press ENTER to try again", 100, 210, 30, Color.WHITE); //Skriver att man har förlorat, hur mycket poäng man fick och hur man kan spela igen
                    break;
                }

                Raylib.EndDrawing();
            }
        }
    }
}
