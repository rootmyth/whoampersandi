using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whoampersandi.State;
using whoampersandi.Interfaces;

namespace whoampersandi.Entities
{
    public class FishermanKoceilah : IEntity
    {
        public string Appearance { get; } = "?";
        public int NumberOfInteractions { get; set; } = 0;
        public static string Name { get; set; } = "Fisherman Koceilah";
        public Dictionary<int, string> EntityDialogue { get; } = new()
        {
            { 1, $"{Name}: Hey ~! I'm testing the waters from this bridge, though so far I haven't much luck fishing. Sometimes it's just about patience though, ya know? Say ~ you don't look so good. Are you doing okay? Get into a rowdy scuffle with one of your hogs again or did something else happen? Well, come see me at the store when I'm through here and I'll see what I have for you.  Maybe that will cheer you up eh?" },
            { 2, $"{Name}: Just a little longer now, I can feel it!" }
        };

        public string EngaugeInDialouge(GameState state)
        {
            KeyValuePair<int, string> dialogue = new();

            if (NumberOfInteractions == 0)
            {
                dialogue = EntityDialogue.FirstOrDefault(text => text.Key == 1);
            }
            else if (NumberOfInteractions > 0)
            {
                dialogue = EntityDialogue.FirstOrDefault(text => text.Key == 2);
            }

            NumberOfInteractions++;

            return dialogue.Value;
        }
    }
}
