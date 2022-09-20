using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whoampersandi.Menus
{
    public class MenuUnit
    {
        //OptionsLocation, Size, SystemIndex, IsSubmenu
        public (int X, int Y) OptionsLocation { get; set; } = (0, 0);
        public (int width, int height) Size { get; set; } = (0, 0);
        public int Index { get; set; } = 0;
        public int SystemIndex { get; set; } = -1;
        public bool NumberedOptions { get; set; } = false;
        public bool IsActive { get; set; } = false;
        public List<string> Options { get; set; } = new() { "Back" };
        public void DisplayMenu()
        {
            string optionLine;
            for (int i = 0; i < Options.Count; i++)
            {
                string selectedOption = Options[i];
                string selector;
                if (i == Index && Index == 0)
                {
                    selector = NumberedOptions ? $"< {i}." : "< ";
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else if (i == Index)
                {
                    selector = NumberedOptions ? $"> {i}." : "> ";
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else
                {
                    selector = NumberedOptions ? $"  {i}." : "  ";
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                optionLine = $"{selector} {selectedOption}";
                string optionLineWithSpaces = optionLine;
                for (int j = 0; j < Size.width - optionLine.Length; j++)
                {
                    optionLineWithSpaces += " ";
                }
                if (!IsActive)
                {
                    for (int j = 0; j < Size.height - Options.Count; j++)
                    {
                        string blankLine = "";
                        for (int k = 0; k < Size.width; k++)
                        {
                            blankLine += " ";
                        }
                        optionLineWithSpaces = blankLine;
                    }
                }
                Console.SetCursorPosition(OptionsLocation.X, i + OptionsLocation.Y);
                Console.WriteLine(optionLineWithSpaces);
                if (i == Options.Count - 1)
                {
                    for (int j = 0; j < Size.height - Options.Count; j++)
                    {
                        string blankLine = "";
                        for (int k = 0; k < Size.width; k++)
                        {
                            blankLine += " ";
                        }
                        Console.SetCursorPosition(OptionsLocation.X, 1 + i + j + OptionsLocation.Y);
                        Console.WriteLine(blankLine);
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }
        public void UpdateMenu(ConsoleKeyInfo menuInput)
        {
            string[] menuNumbers = { "D0", "NumPad0" };
            if (NumberedOptions)
            {
                for (int i = 0; i < Options.Count; i++)
                {
                    menuNumbers.Append($"D{1 + i}");
                    menuNumbers.Append($"NumPad{1 + i}");
                }
            }
            string input = menuInput.Key.ToString();

            if (input == "W" && Index > 0)
            {
                Index--;
            }
            else if (input == "S" && Index < Options.Count - 1)
            {
                Index++;
            }
            else if (input == "Enter" || menuNumbers.Contains(input))
            {
                if (Index == 0 || input == "D0" || input == "NumPad0")
                {
                    //IsViewing = false;
                    //IsActive = false;
                }
                else
                {
                    //HasChosenOption = true;
                    //IsActive = false;
                }
            }
        }
    }
}
