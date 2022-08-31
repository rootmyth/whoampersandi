using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whoampersandi.Interfaces;
using whoampersandi.User;
using whoampersandi.Visuals;
using whoampersandi.GameWorld;
using whoampersandi.State;

namespace whoampersandi.Events
{
    internal class NewGame : IEvent
    {
        private Renderer Display = new();
        private Dialogue Text = new();
        public void EventProgression(Player player, Dictionary<IEntity, (int, int)> entities, OuterWorldMap outerworld, GameState state)
        {
            
            Display.RenderWorldViewer();
            
            Display.RenderDialogueBox(Text.CreateDialogueBoxText("GOOD SAMARITAN: Hello?"));
            
            Display.RenderDialogueBox(Text.CreateDialogueBoxText("Hey!"));
            
            Display.RenderDialogueBox(Text.CreateDialogueBoxText("Are you okay?"));
            
            Display.RenderDialogueBox();

            IArea H3332 = outerworld.Map.FirstOrDefault(map => map.MapLocationInWorld == (33, 32));
            H3332.PlayerLocation = new() { { "X", 32 }, { "Y", 16 } };
            Display.RenderLevelBar(player, H3332);
            Display.RenderWorldViewer(player, entities, H3332);
            Display.RenderStatusBar(player);
            Display.RenderDialogueBox();
            Console.ReadKey();

            Display.RenderDialogueBox(Text.CreateDialogueBoxText("You look pretty beat up, what happened?"));

            Display.RenderDialogueBox(Text.CreateDialogueBoxText("Not totally sure, huh?  Well I can tell you that I was crossing the bridge on the other side of this pen and I heard people shouting and a pig squealing.  Either one of these pigs got the best of you, or some other ill-intentioned character was about."));

            string[] validCharacters = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            string playerName = "";
            bool enteredPlayerName = false;
            while (!enteredPlayerName)
            {
                Display.RenderDialogueBox();
                Console.SetCursorPosition(2, 38);
                Console.WriteLine("What's your name, anyway?");
                Console.SetCursorPosition(2, 40);
                Console.Write(playerName);

                Console.SetCursorPosition(2, 40);
                string input = Console.ReadKey().Key.ToString();
                if (playerName.Length < 17 && validCharacters.Contains(input))
                {
                    playerName += input;
                }
                else if (playerName.Length > 0 && input == "Backspace")
                {
                    playerName.Remove(playerName.Length - 1, 1);
                }
                else if (playerName.Length > 0 && input == "Enter")
                {
                    player.Name = playerName;
                    enteredPlayerName = true;
                }
            }

            Display.RenderDialogueBox(Text.CreateDialogueBoxText("Well *, sorry to find you in such circumstances", player));

        }
    }
}
