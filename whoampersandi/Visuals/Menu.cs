using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whoampersandi.Visuals
{
    internal class Menu
    {
        public Menu(string prompt, List<string> options)
        {
            Prompt = prompt;
            Options = options;
            SelectedIndex = 0;
        }

        public string Prompt;
        public List<string> Options = new();
        public int SelectedIndex;

        public void DisplayOptions()
        {
            Console.SetCursorPosition(0, 38);
            Console.WriteLine(Prompt);

            string optionLine;

            for (int i = 0; i < Options.Count; i++)
            {
                string selectedOption = Options[i];
                string selector;
                if (i == SelectedIndex)
                {
                    selector = $">{i}.";
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    selector = $" {i}.";
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                optionLine = $"| {selector} {selectedOption}";
                int remainingSpace = 64 - optionLine.Length;
                for (int j = 0; j < remainingSpace - 1; j++)
                {
                    optionLine += " ";
                }
                optionLine += "|";
                Console.WriteLine(optionLine);
            }
        }
    }
}
