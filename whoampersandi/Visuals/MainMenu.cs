using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whoampersandi.User;

namespace whoampersandi.Visuals
{
    public class MainMenu
    {
        private int MainMenuIndex { get; set; } = 0;
        private Dialogue Text = new();
        private Renderer Display = new();

        public void DisplayMenu(Player player)
        {
            List<string> options = new() { $"{player.Name}", "Equipment", "Items", "Save", "Exit" };
            string optionLine;

            Console.SetCursorPosition(11, 8);
            Console.WriteLine("MAIN MENU");
            for (int i = 0; i < options.Count; i++)
            {
                string selectedOption = options[i];
                string selector;
                if (i == MainMenuIndex && MainMenuIndex == 4)
                {
                    selector = $"< {i + 1}.";
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else if (i == MainMenuIndex)
                {
                    selector = $"> {i + 1}.";
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else
                {
                    selector = $"{i + 1}.";
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                optionLine = $"{selector} {selectedOption}";

                Console.SetCursorPosition(11, i + 11);
                Console.WriteLine(optionLine);
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            if (MainMenuIndex == 0)
            {
                Display.RenderInformationBox(Text.CreateDialogueBoxText("The player menu gives information on your stats, allows you to spend experience points to increase them, and give information on how they affect battle.  You can also view details on techniques you know, and select which ones you want to use against opponents.", 60, 5));
            }
            else if (MainMenuIndex == 1)
            {
                Display.RenderInformationBox(Text.CreateDialogueBoxText("The equipment menu allows you to equip and unequip things like weapons and shields for combat.  You can also get more information on each piece of equipment's stats like damage and condition.", 60, 5));
            }
            else if (MainMenuIndex == 2)
            {
                Display.RenderInformationBox(Text.CreateDialogueBoxText("The item menu allows you to equip and unequip items for combat.  You can also get more information on what each item does.", 60, 5));
            }
            else if (MainMenuIndex == 3)
            {
                Display.RenderInformationBox(Text.CreateDialogueBoxText("Save your game.", 60, 5));
            }
            else if (MainMenuIndex == 4)
            {
                Display.RenderInformationBox(Text.CreateDialogueBoxText("Exit the main menu.", 60, 5));
            }
        }
        public bool UpdateMenu(ConsoleKeyInfo menuInput)
        {
            bool usingMenu = true;
            string[] menuNumbers = { "D1", "D2", "D3", "D4", "D5", "NumPad1", "NumPad2", "NumPad3", "NumPad4", "NumPad5", "E" };
            string input = menuInput.Key.ToString();

            if (input == "W" && MainMenuIndex > 0)
            {
                MainMenuIndex--;
            }
            else if (input == "S" && MainMenuIndex < 4)
            {
                MainMenuIndex++;
            }
            else if (input == "Enter" || menuNumbers.Contains(input))
            {
                if (MainMenuIndex == 0 || input == "D1" || input == "NumPad1")
                {
                    usingMenu = false;
                }
                else if (MainMenuIndex == 1 || input == "D2" || input == "NumPad2")
                {
                    usingMenu = false;
                }
                else if (MainMenuIndex == 2 || input == "D3" || input == "NumPad3")
                {
                    usingMenu = false;
                }
                else if (MainMenuIndex == 3 || input == "D4" || input == "NumPad4")
                {
                    usingMenu = false;
                }
                else if (MainMenuIndex == 4 || input == "D5" || input == "NumPad5" || input == "E")
                {
                    usingMenu = false;
                }
            }
            return usingMenu;
        }
    }
}
