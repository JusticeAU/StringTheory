using System;

namespace StringTheory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            int testInt = 0;

            Sequence test = new Sequence();
            test.AddEvent(new DynamicString(". . . ", clearScreen: true, delay: 500, delayPerChar: true));
            test.AddEvent(new DynamicString("Welcome . . ", delay: 45, delayPerChar: true));
            test.AddEvent(new DynamicString(delay: 500));

            Sequence test2 = new Sequence();
            test2.AddEvent(new DynamicString("We've been waiting for you", clearScreen: true, delay: 250));
            test2.AddEvent(new DynamicString(delay: 500, newLine: false));
            test2.AddEvent(new DynamicString("Have cake.", delay: 500, colour: ConsoleColor.DarkRed));
            test2.AddEvent(new Choose(new string[] { "Eat cake", "Don't eat cake" }, ref testInt));

            test.AddSequence(test2);

            test.StartSequence();
        }
    }
}
