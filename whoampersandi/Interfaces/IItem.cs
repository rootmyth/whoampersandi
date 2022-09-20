using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whoampersandi.Interfaces
{
    public interface IItem
    {
        string Description { get; }
        int StackLimit { get; }
        bool CanBeUsedInCombat { get; }
        int Heaviness { get; set; }
        string Details { get; }
        Dictionary<bool, string> MoreInfo { get; }
        List<string> CanBeUsedWith { get; }
        int? UseLimit { get; }
        int Uses { get; set; }
    }
}
