using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace StringTheory
{
    public class PressContinue : Event
    {
        private string prompt;
        public PressContinue(string prompt = ">\tContinue")
        {
            this.prompt = prompt;
        }

        public override void Run()
        {
            bool confirmed = false;

            // Clear input buffer
            while (Console.KeyAvailable)
                Console.ReadKey(true);

            // Render Prompt
            Console.Write(prompt);

            while (!confirmed)
            {
                while (!Console.KeyAvailable) Thread.Sleep(16);

                // Get input when in buffer
                ConsoleKeyInfo cki = Console.ReadKey(true);
                switch (cki.Key)
                {
                    case ConsoleKey.Enter:
                        confirmed = true;
                        break;
                    case ConsoleKey.Spacebar:
                        confirmed = true;
                        break;
                }

                
            }
            Console.CursorLeft = 0;
            Console.Write("                                ");
            Console.CursorLeft = 0;
        }
    }
}
