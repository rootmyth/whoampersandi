using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whoampersandi.Interfaces;
using whoampersandi.User;
using whoampersandi.Visuals;
using whoampersandi.OuterWorld;
using whoampersandi.InnerWorld;
using whoampersandi.State;
using whoampersandi.Utilities;

namespace whoampersandi.Events.Repository
{
    internal class NewGame : IEvent
    {
        private Renderer Display = new();
        private Dialogue Text = new();
        private Fader Fade = new();
        public string EventName { get; } = "NewGame";
        public void EventSequence(IArea area, Player player, Dictionary<IEntity, (int, int)> entities, OuterWorldMap outerWorld, InnerWorldMap innerWorld, GameState state)
        {
            Display.RenderLevelBar(true);
            Display.RenderWorldViewer();
            Display.RenderStatusBar(true);

            string GS = "Good Samaritan";

            bool spaceBar = false;
            while (!spaceBar)
            {
                Console.SetCursorPosition(2, 36);
                Console.WriteLine("Hello?");
                Console.SetCursorPosition(2, 38);
                Console.WriteLine("(Press Spacebar to display next dialogue text)");
                string input = Console.ReadKey().Key.ToString();
                if (input == "Spacebar")
                {
                    spaceBar = true;
                }
            }

            spaceBar = false;
            while (!spaceBar)
            {
                Console.SetCursorPosition(2, 36);
                Console.WriteLine("Helloooooo?");
                Console.SetCursorPosition(2, 38);
                Console.WriteLine("                                              ");
                string input = Console.ReadKey().Key.ToString();
                if (input == "Spacebar")
                {
                    spaceBar = true;
                }
            }

            spaceBar = false;
            while (!spaceBar)
            {
                Console.SetCursorPosition(2, 36);
                Console.WriteLine(@"HEY!                   ");
                string input = Console.ReadKey().Key.ToString();
                if (input == "Spacebar")
                {
                    spaceBar = true;
                }
            }

            spaceBar = false;
            while (!spaceBar)
            {
                Console.SetCursorPosition(2, 36);
                Console.WriteLine("Are you okay?");
                string input = Console.ReadKey().Key.ToString();
                if (input == "Spacebar")
                {
                    spaceBar = true;
                }
            }

            Fade.FadeIn(player, entities, area, 300);
            Console.ReadKey();
            

            Display.RenderDialogueBox(Text.CreateDialogueBoxText($"{GS}: You look pretty beat up, what happened?"));

            Display.RenderDialogueBox(Text.CreateDialogueBoxText($"{GS}: Not totally sure, huh?  Well I can tell you that I was crossing the bridge on the other side of this pen and I heard people shouting and a pig squealing.  Either one of these pigs got the best of you, or some other ill-intentioned character was about."));

            string[] validCharacters = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            string playerName = "";
            bool enteredPlayerName = false;
            while (!enteredPlayerName)
            {
                Display.RenderDialogueBox();
                Console.SetCursorPosition(2, 38);
                Console.WriteLine($"{GS}: What's your name, anyway?");
                Console.SetCursorPosition(2, 40);
                Console.WriteLine("(Type your name, then hit enter):");
                Console.SetCursorPosition(36, 40);
                Console.Write(playerName);

                Console.SetCursorPosition(2, 40);
                string input = Console.ReadKey().Key.ToString();
                if (playerName.Length < 17 &&  playerName.Length > 0 && validCharacters.Contains(input))
                {
                    playerName += input.ToLower();
                }
                else if (playerName.Length == 0 && validCharacters.Contains(input))
                {
                    playerName += input.ToUpper();
                }
                else if (playerName.Length > 0 && input == "Backspace")
                {
                    playerName = playerName.Remove(playerName.Length - 1, 1);
                }
                else if (playerName.Length > 0 && input == "Enter")
                {
                    player.Name = playerName;
                    enteredPlayerName = true;
                }
            }

            Display.RenderDialogueBox(Text.CreateDialogueBoxText($"{GS}: Well ~, sorry to find you in such circumstances. I am travelling from BOGOSORTON to the thriving markets around the castle in the northeast. I've collected many furs this season and I'm trying to sell off my excess to make a little money and feed my family. You've been to the castle before haven't you? In any case, I'm going to rest here for a few more minutes before I take off. You take care of yourself. I've been hearing more talk of crime and malicious deeds than ever before. If you travel alone, stay vigilant!", player));
            Display.RenderDialogueBox();
            Console.SetCursorPosition(2, 38);
            Console.WriteLine("(Press W, D, S, or A to move)");
            Console.ReadKey();

            state.newGame = false;
        }
    }
}
