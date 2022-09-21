using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whoampersandi.Visuals;

namespace whoampersandi.Menus
{
    internal class ObjectMenu
    {
        private Renderer Display = new();
        private int ObjectMenuIndex { get; set; } = 0;
        private List<string> Options { get; set; } = new() { "Back" };
        public void DisplayObjectMenu(string prompt, List<string> options)
        {
            Display.RenderDialogueBox();
            foreach (string option in options)
            {
                if (!Options.Contains(option))
                {
                    Options.Add(option);
                }
            }

            Console.SetCursorPosition(2, 38);
            Console.WriteLine($"{prompt}");
            string optionLine;
            for (int i = 0; i < Options.Count; i++)
            {
                string selectedOption = Options[i];
                string selector;
                if (i == ObjectMenuIndex && ObjectMenuIndex == 0)
                {
                    selector = $"< ";
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else if (i == ObjectMenuIndex)
                {
                    selector = $"> ";
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else
                {
                    selector = $"  ";
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                optionLine = $"{selector} {selectedOption}";

                Console.SetCursorPosition(6, i + 39);
                Console.WriteLine(optionLine);
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }
        public int UpdateObjectMenu(ConsoleKeyInfo menuInput)
        {
            int selection = -1;
            string[] menuNumbers = { "D0", "NumPad0" };
            for (int i = 0; i < Options.Count; i++)
            {
                menuNumbers.Append($"D{1 + i}");
                menuNumbers.Append($"NumPad{1 + i}");
            }
            string input = menuInput.Key.ToString();

            if (input == "W" && ObjectMenuIndex > 0)
            {
                ObjectMenuIndex--;
            }
            else if (input == "S" && ObjectMenuIndex < Options.Count - 1)
            {
                ObjectMenuIndex++;
            }
            else if (input == "Enter")
            {
                selection = ObjectMenuIndex;
            }
            else if (menuNumbers.Contains(input))
            {
                selection = input[input.Length - 1];
            }
            return selection;
        }
        public int UseObjectMenu(string prompt, List<string> options)
        {
            int selection = -1;
            while (selection == -1)
            {
                DisplayObjectMenu(prompt, options);
                ConsoleKeyInfo input = Console.ReadKey(true);
                selection = UpdateObjectMenu(input);
            }
            return selection;
        }
    }
}
