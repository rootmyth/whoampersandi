using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whoampersandi.WorldNavigation
{
    public class Transpoint
    {
        public Transpoint(int IPX, int IPY, string IK, string TF, string TT, bool TTOW, int LIWX, int LIWY, int PSLX, int PSLY)
        {
            InitializationPoint = new Dictionary<string, int>() { { "X", IPX }, { "Y", IPY } };
            InitializationKey = IK;
            TransFrom = TF;
            TransTo = TT;
            TransToOuterWorld = TTOW;
            LocationInWorld = (LIWX, LIWY);
            playerSpawnLocation = new Dictionary<string, int>() { { "X", PSLX }, { "Y", PSLY } };
        }
        public Dictionary<string, int> InitializationPoint { get; set; }
        public string InitializationKey { get; set; }
        public string TransFrom { get; set; }
        public string TransTo { get; set; }
        public bool TransToOuterWorld { get; set; }
        public (int X, int Y) LocationInWorld { get; set; }
        public Dictionary<string, int> playerSpawnLocation { get; set; }

    }
}
