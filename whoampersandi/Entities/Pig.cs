using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whoampersandi.Interfaces;

namespace whoampersandi.Entities
{
    internal class Pig : IEntity
    {
        public string Appearance { get; } = "?";
        public static string Name { get; } = "a pig";
        public int NumberOfInteractions { get; set; } = 0;
        public Dictionary<int, string> EntityDialogue { get; } = new()
        {
            { 1, $"{Name.ToUpper()}: oink" },
            { 2, $"{Name.ToUpper()}: Oink...oink...oink........oink" },
            { 3, $"{Name.ToUpper()}: OINK!!!" }
        };
        public string EngaugeInDialouge()
        {
            Random rnd = new Random();
            int index = rnd.Next(EntityDialogue.Count);
            string dialouge = EntityDialogue.FirstOrDefault(text => text.Key.Equals(index + 1)).Value;
            NumberOfInteractions++;
            return dialouge;
        }
    }
}
