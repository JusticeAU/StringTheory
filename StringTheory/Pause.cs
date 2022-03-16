using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace StringTheory
{
    public class Pause : Event
    {
        private int time;
        private int currentTime;
        private bool skippable = false;
        private bool skip = false;
        public Pause(int ms, bool skippable = false)
        {
            this.time = ms;
            this.skippable = skippable;
        }

        public override void Run()
        {
            while (!skip && (currentTime < time))
            {

                if(Console.KeyAvailable && skippable)
                {
                    // Get input when in buffer
                    ConsoleKeyInfo cki = Console.ReadKey(true);
                    switch (cki.Key)
                    {
                        case ConsoleKey.Enter:
                            skip = true;
                            break;
                        case ConsoleKey.Spacebar:
                            skip = true;
                            break;
                    }
                }    

                Thread.Sleep(25);
                currentTime += 25;
            }
        }
    }
}
