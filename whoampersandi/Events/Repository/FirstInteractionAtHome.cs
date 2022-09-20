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

namespace whoampersandi.Events.Repository
{
    public class FirstInteractionAtHome : IEvent
    {
        private Renderer Display = new();
        private Dialogue Text = new();
        public string EventName { get; } = "FirstInteractionAtHome";
        public void EventSequence(IArea area, Player player, Dictionary<IEntity, (int, int)> entities, Dictionary<IObject, (int, int)> objects, OuterWorldMap outerWorld, InnerWorldMap innerWorld, EventState state)
        {
            string ML = "Mother Lovelace";

            Display.RenderLevelBar(player, area);
            Display.RenderWorldViewer(player, entities, objects, area);
            Display.RenderStatusBar(player);

            Display.RenderDialogueBox(Text.CreateDialogueBoxText($"{ML}: Oh for heaven's sake ~ why are you bleeding?  Come here and let me take a look at you.", 60, 5, player));
        }
    }
}
