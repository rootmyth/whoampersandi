using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whoampersandi.State
{
    public class EventState
    {
        public bool dummyEventStateChange { get; set; } = false;
        public bool newGame { get; set; } = true;
        public bool firstInteractionAtHome { get; set; } = true;
        public bool firstEpsomBath { get; set; } = true;
    }
}
