using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whoampersandi.Interfaces;

namespace whoampersandi.InnerWorld
{
    public class InnerWorldMap
    {
        private PlayersStorage3132 IW3132 = new();
        private PlayersHouse3232 IW3232 = new();
        public List<IArea> InnerWorld { get { return Map; } set { InnerWorld = Map; } }
        public List<IArea> Map => new() { IW3132, IW3232 };
    }
}
