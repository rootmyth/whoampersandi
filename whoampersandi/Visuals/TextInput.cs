using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whoampersandi.Visuals
{
    public class TextInput
    {
        Renderer Display = new();
        public string UsersEnteredInput { get; set; }
        public void CreateUserStringInput(string entityName, string prompt, string instruction, int numberOfCharacters)
        {
            if (entityName != "")
            {
                prompt = $"{entityName}: {prompt}";
            }
            if (prompt.Length > 60)
            {
                prompt = prompt.Substring(0, 60); 
            }
            if (instruction.Length > 58)
            {
                instruction = instruction.Substring(0, 58);
            }
            
            string removeInstruction = @"                                                            ";
            string[] validCharacters = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            
            //string[] numberArray = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

            string text = "";
            bool enteredInput = false;
            bool showInstruction = false;
            while (!enteredInput)
            {
                Display.RenderDialogueBox();
                Console.SetCursorPosition(2, 38);
                Console.WriteLine(prompt);
                if (showInstruction)
                {
                    Console.SetCursorPosition(2, 39);
                    Console.WriteLine($"({instruction})");
                }
                else
                {
                    Console.SetCursorPosition(2, 39);
                    Console.WriteLine(removeInstruction);
                }
                Console.SetCursorPosition(2, 40);
                Console.Write($"> {text}");

                Console.SetCursorPosition(2, 40);
                string input = Console.ReadKey(true).Key.ToString();
                if (text.Length < numberOfCharacters && text.Length > 0 && validCharacters.Contains(input))
                {
                    showInstruction = false;
                    text += input.ToLower();
                }
                else if (text.Length == 0 && validCharacters.Contains(input))
                {
                    showInstruction = false;
                    text += input.ToUpper();
                }
                else if (text.Length > 0 && input == "Backspace")
                {
                    showInstruction = false;
                    text = text.Remove(text.Length - 1, 1);
                }
                else if (text.Length > 0 && input == "Enter")
                {
                    enteredInput = true;
                    UsersEnteredInput = text;
                }
                else
                {
                    showInstruction = true;
                }
            }
        }
    }
}
