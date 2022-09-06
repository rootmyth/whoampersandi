using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whoampersandi.State
{
    public class GameState
    {
        public bool dummyStateChange { get; set; } = false;
        public bool newGame { get; set; } = true;
        public bool firstInteractionAtHome { get; set; } = true;
        public bool firstEpsomBath { get; set; } = true;
    }
}
