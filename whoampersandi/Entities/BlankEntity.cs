using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whoampersandi.State;
using whoampersandi.Interfaces;

namespace whoampersandi.Entities
{
    internal class BlankEntity : IEntity
    {
        public string Appearance { get; } = "";
        public int NumberOfInteractions { get; set; } = 0;
        public static string Name { get; set; } = "";
        public Dictionary<int, string> EntityDialogue { get; } = new()
        {
            { 1, $"{Name}: " },
        };

        public string EngaugeInDialouge(GameState state)
        {
            KeyValuePair<int, string> dialogue = new();

            if (true)
            {
                dialogue = EntityDialogue.FirstOrDefault(text => text.Key == 1);
            }

            NumberOfInteractions++;

            return dialogue.Value;
        }
       
    }
}
