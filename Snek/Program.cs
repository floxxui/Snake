using System;
using Raylib_cs;

namespace Snek
{
    class Program
    {
        static void Main(string[] args)
        {
            //Saker att fixa:
                //En snake
                //En spelplan där ex antal pixlar motsvarar en ruta
                //En random som genererar en matbit till en random ruta
                //Se till att matbiten hamnar i en ruta, (och inte på flertal rutor)
                //ormen blir längre ifall man äter en matbit
                //genererar en ny matbit ifall förra är uppäten
                //dessa följer efter ormen
                //Game over om man krockar i väggen
                //Game over ifall man krockar med sig själv
                //Om hinner: Poängsystem
            
            Window w = new Window();
            Snake s = new Snake();

        }
    }
}
