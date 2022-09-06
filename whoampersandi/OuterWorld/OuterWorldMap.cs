using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whoampersandi.Interfaces;

namespace whoampersandi.OuterWorld

{
    public class OuterWorldMap
    {
        private Heisenburg3132 H3132 = new();
        private Heisenburg3232 H3232 = new();
        private Heisenburg3332 H3332 = new();
        private Heisenburg3333 H3333 = new();
        public List<IArea> OuterWorld { get { return Map; } set { OuterWorld = Map; } }
        public List<IArea> Map => new() { H3132, H3232, H3332, H3333 };

        
    }
}
