using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whoampersandi.User;
using whoampersandi.GameWorld;
using whoampersandi.State;


namespace whoampersandi.Interfaces
{
    internal interface IEvent
    {
        void EventProgression(Player player, Dictionary<IEntity, (int, int)> entities, OuterWorldMap outerworld, GameState state);
    }
}
