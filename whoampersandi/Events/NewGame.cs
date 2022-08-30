using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whoampersandi.Interfaces;
using whoampersandi.User;
using whoampersandi.Visuals;
using whoampersandi.Utlilties;

namespace whoampersandi.Events
{
    internal class NewGame : IEvent
    {
        private Renderer Display = new();
        private Dialogue Text = new();
        public void EventProgression()
        {
            Console.SetCursorPosition(0, 3);
            Display.RenderWorldViewer();
            Console.SetCursorPosition(0, 38);
            Display.RenderDialogueBox(Text.CreateDialogueBoxText("GOOD SAMARITAIN: Hello?"));
            Console.SetCursorPosition(0, 38);
            Display.RenderDialogueBox(Text.CreateDialogueBoxText("Hey!"));
            Console.SetCursorPosition(0, 38);
            Display.RenderDialogueBox(Text.CreateDialogueBoxText("Are you okay?"));
        }
    }
}
