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
    public class _BlankEvent
    {
        private Renderer Display = new();
        private Dialogue Text = new();
        public string EventName { get; } = "";
        public void EventSequence(IArea area, Player player, Dictionary<IEntity, (int, int)> entities, OuterWorldMap outerWorld, InnerWorldMap innerWorld, GameState state)
        {

        }
    }
}
