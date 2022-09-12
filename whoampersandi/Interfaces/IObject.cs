using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whoampersandi.Interfaces
{
    public interface IObject
    {
        string Description { get; }
        bool IsStorage { get; }
        int StorageCapacity { get; }
        List<string>? ItemsInStorage { get; }
        (int X, int Y) InteractionBoxSize { get; }
        int State { get; set; }
        Dictionary<int, List<List<string>>> RenderingList { get; }
        List<List<string>> DefaultRendering { get; }
        void RenderObject(int X, int Y);
        List<(int X, int Y)> CreateInteractionBox((int X, int Y) locationInArea);
    }
}
