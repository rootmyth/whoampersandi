using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whoampersandi.User;
using whoampersandi.OuterWorld;
using whoampersandi.InnerWorld;
using whoampersandi.State;


namespace whoampersandi.Interfaces
{
    public interface IEvent
    {
        string EventName { get; }
        void EventSequence(IArea area, Player player, Dictionary<IEntity, (int, int)> entities, Dictionary<IObject, (int, int)> objects, OuterWorldMap outerWorld, InnerWorldMap innerWorld,  EventState state);
    }
}
