using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whoampersandi.Interfaces;
using whoampersandi.State;

namespace whoampersandi.Entities
{
    internal class Pig : IEntity
    {
        public string Appearance { get; } = "?";
        public static string Name { get; set; } = "A PIG";
        public int NumberOfInteractions { get; set; } = 0;
        public Dictionary<int, string> EntityDialogue { get; } = new()
        {
            { 1, $"{Name}: oink" },
            { 2, $"{Name}: Oink...oink...oink........oink" },
            { 3, $"{Name}: OINK!!!" }
        };
        public string EngaugeInDialouge(GameState state)
        {
            Random rnd = new Random();
            int index = rnd.Next(EntityDialogue.Count);
            string dialouge = EntityDialogue.FirstOrDefault(text => text.Key.Equals(index + 1)).Value;
            NumberOfInteractions++;
            return dialouge;
        }
    }
}
