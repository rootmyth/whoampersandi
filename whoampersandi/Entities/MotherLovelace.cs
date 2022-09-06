using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whoampersandi.Interfaces;
using whoampersandi.State;

namespace whoampersandi.Entities
{
    internal class MotherLovelace : IEntity
    {
        public string Appearance { get; } = "?";
        public int NumberOfInteractions { get; set; } = 0;
        public static string Name { get; set; } = "Mother Lovelace";
        public Dictionary<int, string> EntityDialogue { get; } = new()
        {
            { 1, $"{Name}: Did a pig do this?  You've had plenty of tussles with our swine over the years but never have I seen you so battered and bruised.  This was the work of something else.  Were you attacked by a pack of coyotes?  You really can't recall what took place?  When I think about it, the other day a group of people were slowly walking past the pig pen and staring at the gate.  I didn't say anything and I don't think they even knew that I was standing there but in retrospect I bet they were casing the livestock.  Last week the same thing happened to a chicken farmer in BOGOSORTON, and he sustained some pretty serious injuries.  Oh ~ I'm so glad you're okay though, nothing is broken right?  Why don't you use the washtub and tend to your injuries? I believe there's some Epsom salt in the storage shed around back.  Why don't you grab a bucket, collect some water and make yourself a nice bath?" },
            { 2, $"{Name}: There should be Epsom salt and a bucket to collect water in the shed, go take a look!" }
        };

        public string EngaugeInDialouge(GameState state)
        {
            KeyValuePair<int, string> dialogue = new();
            if (state.firstEpsomBath && NumberOfInteractions == 0)
            {
                dialogue = EntityDialogue.FirstOrDefault(text => text.Key == 1);
                NumberOfInteractions++;
            }
            else if (state.firstEpsomBath && NumberOfInteractions > 0)
            {
                dialogue = EntityDialogue.FirstOrDefault(text => text.Key == 2);
                NumberOfInteractions++;
            }
            return dialogue.Value;
        }
    }
}
