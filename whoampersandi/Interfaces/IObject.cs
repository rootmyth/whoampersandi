using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whoampersandi.State;
using whoampersandi.User;

namespace whoampersandi.Interfaces
{
    public interface IObject
    {
        string Description { get; }
        bool IsStorage { get; }
        int StorageCapacity { get; }
        List<IItem>? ItemsInStorage { get; }
        (int X, int Y) InteractionBoxSize { get; }
        int State { get; set; }
        Dictionary<int, List<List<string>>> RenderingList { get; }
        List<List<string>> DefaultRendering { get; }
        List<List<string>> ReturnRendering();
        List<(int X, int Y)> CreateInteractionBox((int X, int Y) locationInArea);
        void InteractWithObject(Player player, InformationState infoState);
    }
}
