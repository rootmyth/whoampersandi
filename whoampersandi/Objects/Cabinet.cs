using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whoampersandi.Interfaces;
using whoampersandi.State;

namespace whoampersandi.Objects
{
    public class Cabinet : IObject
    {
        public string Description { get; } = "cabinet";

        public bool IsStorage { get; } = true;

        public int StorageCapacity { get; } = 16;

        public List<string>? ItemsInStorage { get; set; }

        public (int X, int Y) InteractionBoxSize { get; } = (3, 3);

        public int State { get; set; } = 1;

        public Dictionary<int, List<List<string>>> StateVariants { get { return RenderingList; } set { StateVariants = RenderingList; } }
        public Dictionary<int, List<List<string>>> RenderingList => new()
        {
            { 1, DefaultRendering }
        };
        public List<List<string>> DefaultRendering => new() { ObjectLine01, ObjectLine02, ObjectLine03 };
        public List<string> ObjectLine01 { get; } = new List<string>() { "=", "=", "="};
        public List<string> ObjectLine02 { get; } = new List<string>() { "[", "-", "]" };
        public List<string> ObjectLine03 { get; } = new List<string>() { "=", "=", "=" };
        public List<List<string>> ReturnRendering()
        {
            List<List<string>> rendering = new();
            if (State == 1)
            {
                rendering = StateVariants.FirstOrDefault(rendering => rendering.Key == 1).Value;
            }
            return rendering;
        }
        public List<(int X, int Y)> CreateInteractionBox((int X, int Y) locationInArea)
        {
            List<(int, int)> locationPairs = new();
            for (int i = 0; i < InteractionBoxSize.X; i++)
            {
                for (int j = 0; j < InteractionBoxSize.Y; j++)
                {
                    locationPairs.Add((locationInArea.X + i, locationInArea.Y + j));
                }
            }
            return locationPairs;
        }
    }
}
