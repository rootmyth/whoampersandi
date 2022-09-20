using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whoampersandi.Interfaces;
using whoampersandi.State;
using whoampersandi.User;
using whoampersandi.OuterWorld;

namespace whoampersandi.Events
{
    public class GlobalEventPrompter
    {
        private EventList Events = new();
        public void EventInitializer(IArea area, Player player, Dictionary<IEntity, (int, int)> entities, OuterWorldMap oouterWorld, EventState state)
        {
            
            
        }
    }
}
