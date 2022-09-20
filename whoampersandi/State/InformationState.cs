using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whoampersandi.State
{
    public class InformationState
    {
        public List<(string itemName, bool currentState)> ItemInfo { get; set; } = new()
        {
            ("Bucket", false)
        };
    }
}
