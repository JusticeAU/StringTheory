using System;
using System.Threading;

namespace StringTheory
{
    public class Choose : Event
    {
        enum ChoiceType
        {
            Standard,
            SequencePath,
            SequenceFunction
        }

        private string[] options;
        private int[] choices;
        private STFunc[] funkyChoices;
        private Sequence[] paths;
        private Sequence outputSequence;
        private int outputInt;
        private ChoiceType choiceType = ChoiceType.Standard;


        public Choose(string[] options, ref int choiceVar)
        {
            this.options = options;
            choices = new int[options.Length];
            for(int i = 0; i < options.Length; i++)
            {
                choices[i] = i + 1;
            }
        }


        public Choose(string[] options, Sequence[] paths, ref Sequence sequenceRef)
        {
            this.options = options;
            this.paths = paths;
            this.outputSequence = sequenceRef;
            this.choiceType = ChoiceType.SequencePath;
        }

        public Choose(string[] options, STFunc[] funkyChoices)
        {
            this.options = options;
            this.choiceType = ChoiceType.SequenceFunction;
            this.funkyChoices = funkyChoices;
        }

        public override void Run()
        {
            // Config
            const char cursor = '>';

            // Internals
            int currentSelection = 0;
            bool confirmed = false;
            int choices = options.Length;

            // Clear input buffer
            while (Console.KeyAvailable)
                Console.ReadKey(true);

            //  Render options
            for (int i = 0; i < choices; i++)
            {
                Console.WriteLine($"\t{options[i]}");
            }
            // Render cursor
            while (!confirmed)
            {
                // Move Console Cursor back to the start of the options and insert our Cursor character.
                Console.CursorTop = Console.CursorTop - options.Length;
                for (int i = 0; i < options.Length; i++)
                {
                    // Render cursor
                    if (currentSelection == i) Console.WriteLine(cursor);
                    else Console.WriteLine(" ");
                }

                // Wait for Input to be in the buffer
                Console.CursorVisible = false;
                while (!Console.KeyAvailable)
                {
                    Thread.Sleep(16);
                }

                // Get input when in buffer
                ConsoleKeyInfo cki = Console.ReadKey(true);
                switch (cki.Key)
                {
                    case ConsoleKey.UpArrow:
                        currentSelection--;
                        break;
                    case ConsoleKey.DownArrow:
                        currentSelection++;
                        break;
                    case ConsoleKey.Enter:
                        confirmed = true;
                        break;
                    case ConsoleKey.Spacebar:
                        confirmed = true;
                        break;
                }

                // Action input
                if (confirmed)
                {
                    break;
                }
                else
                {
                    if (currentSelection == options.Length) currentSelection = 0;
                    else if (currentSelection < 0) currentSelection = options.Length - 1;
                }

            }
            switch(choiceType)
            {
                case ChoiceType.Standard:
                    outputInt = currentSelection;
                    break;
                case ChoiceType.SequencePath:
                    outputSequence.AddSequence(paths[currentSelection]);
                    break;
                case ChoiceType.SequenceFunction:
                    funkyChoices[currentSelection]();
                    break;
                default:
                    break;
            }
            
        }
    }
}
