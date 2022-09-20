using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whoampersandi.Interfaces;
using whoampersandi.Menus;
using whoampersandi.State;
using whoampersandi.User;

namespace whoampersandi.Objects
{
    internal class Water : IObject
    {
        public string Description { get; } = "Water";

        public bool IsStorage { get; } = false;

        public int StorageCapacity { get; } = 0;

        public List<IItem>? ItemsInStorage { get; set; } = null;

        public (int X, int Y) InteractionBoxSize { get; } = (1, 1);

        public int State { get; set; } = 1;

        public Dictionary<int, List<List<string>>> StateVariants { get { return RenderingList; } set { StateVariants = RenderingList; } }
        public Dictionary<int, List<List<string>>> RenderingList => new()
        {
            { 1, DefaultRendering }
        };
        public List<List<string>> DefaultRendering => new() { ObjectLine01 };
        public List<string> ObjectLine01 { get; } = new List<string>() { "~" };
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
                    if (ReturnRendering()[j][i] != " ")
                    {
                        locationPairs.Add((locationInArea.X + i, locationInArea.Y + j));
                    }
                }
            }
            return locationPairs;
        }
        public void InteractWithObject(Player player, InformationState infoState)
        {
            //ObjectMenu menu = new();
            //List<string> options = new() { "Use Item" };

            //bool usingMenu = true;
            //while (usingMenu)
            //{
            //    menu.DisplayObjectMenu("The water is calm as usual.", options);
            //    Console.SetCursorPosition(0, 44);
            //    ConsoleKeyInfo menuInput = Console.ReadKey();

            //    if (!menu.UpdateMenu(menuInput).usingMenu)
            //    {
            //        usingMenu = false;
            //    }
            //}
        }
    }
}
