using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whoampersandi.State;

namespace whoampersandi.Interfaces
{
    public interface IEntity
    {
        string Appearance { get; }
        static string Name { get; set; }
        int NumberOfInteractions { get; set; }
        Dictionary<int, string> EntityDialogue { get; }
        string EngaugeInDialouge(GameState state);
    }
}
