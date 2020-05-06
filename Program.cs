using System;

namespace Spaceman
{
  class Program
  {
    static void Main(string[] args)
    {
            Game g = new Game();
            g.Greet();

            do
            {
                g.Display();
                g.Ask();
                if (g.DidLose())
                {
                    g.Display();
                    Console.WriteLine("You lost, they took you away!");
                    break;
                }
                else if (g.DidWin())
                {
                    g.Display();
                    Console.WriteLine("You get to stay on Earth...this time!");
                    break;
                }
            } while(true);
    }
  }
}
