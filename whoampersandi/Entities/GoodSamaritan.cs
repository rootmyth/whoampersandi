using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whoampersandi.Interfaces;
using whoampersandi.State;

namespace whoampersandi.Entities
{
    public class GoodSamaritan : IEntity
    {
        public string Appearance { get; } = "?";
        public int NumberOfInteractions { get; set; } = 0;
        public static string Name { get; set; } = "GOOD SAMARITAN";
        public Dictionary<int, string> EntityDialogue { get; } = new()
        {
            { 1, $"{Name}: You really ought to get yourself cleaned up, I'm assuming that's your house over there?" },
            { 2, $"{Name}: Hey, I remember you! Your name is *, right?" }
        };

        public string EngaugeInDialouge(GameState state)
        {
            string dialogue = "";
            if (state.newGame)
            {
                dialogue = EntityDialogue.FirstOrDefault(text => text.Key.Equals(1)).Value;
            }
            else if (state.firstInteractionAtHome)
            {
                dialogue = EntityDialogue.FirstOrDefault(text => text.Key.Equals(2)).Value;
            }
            return dialogue;
        }
    }
}
