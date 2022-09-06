using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whoampersandi.Events.Repository;
using whoampersandi.Interfaces;

namespace whoampersandi.Events
{
    public class EventList
    {
        public List<IEvent> Events { get { return List; } set { Events = List; } }
        public List<IEvent> List => new() { NewGame };

        private NewGame NewGame = new();
    }
}
