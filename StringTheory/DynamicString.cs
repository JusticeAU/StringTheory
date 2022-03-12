using System;
using System.Threading;

namespace StringTheory
{
    public class DynamicString : Event
    {
        string text;
        ConsoleColor colour = ConsoleColor.White;
        int delay = 0;
        bool delayPerChar;
        bool newLine = true;
        bool clearScreen = false;

        public DynamicString(string text = "", ConsoleColor colour = ConsoleColor.White, bool newLine = true, int delay = 0, bool delayPerChar = false, bool clearScreen = false)
        {
            this.text = text;
            this.colour = colour;
            this.newLine = newLine;
            this.delay = delay;
            this.delayPerChar = delayPerChar;
            this.clearScreen = clearScreen;
        }

        public override void Run()
        {
            if (clearScreen) Console.Clear();

            if (colour != Console.ForegroundColor) Console.ForegroundColor = colour;

            if (delay > 0)
            {
                if (delayPerChar)
                {
                    foreach (char ch in text)
                    {
                        while(Console.KeyAvailable)
                        {
                            Console.ReadKey(true);
                            if (delay > 5) delay = 5;
                            else delay = 0;
                        }
                        Thread.Sleep(delay);
                        Console.Write(ch);
                    }
                }
                else
                {
                    string[] words = text.Split(' ');
                    int lastIndex = words.Length - 1;
                    for (int i = 0; i <= lastIndex; i++)
                    {
                        while (Console.KeyAvailable)
                        {
                            Console.ReadKey(true);
                            delay = 0;
                        }
                        Thread.Sleep(delay);
                        Console.Write(words[i]);
                        if (i < lastIndex)
                        {
                            Console.Write(" ");
                        }
                    }
                }
            }
            else Console.Write(text);

            if (newLine) Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
