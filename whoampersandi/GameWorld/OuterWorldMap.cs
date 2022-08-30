using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whoampersandi.Interfaces;

namespace whoampersandi.GameWorld

{
    public class OuterWorldMap
    {
        private Heisenburg3232 H3232 = new();
        private Heisenburg3332 H3332 = new();
        public List<IArea> OuterWorld { get { return Map; } set { OuterWorld = Map; } }
        public List<IArea> Map => new() { H3232, H3332 };

        
    }
}
