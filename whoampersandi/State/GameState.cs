using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whoampersandi.State
{
    public class GameState
    {
        public bool newGame { get; set; } = true;
        public bool firstInteractionAtHome { get; set; } = true;
        public bool defeatedPigTheif { get; set; } = false;
    }
}
