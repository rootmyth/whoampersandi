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
    internal class Chest : IObject
    {
        public Chest()
        {
            ItemsInStorage = new();
        }
        public Chest(List<IItem> items)
        {
            ItemsInStorage = items;
        }
        public string Description { get; } = "Chest";
        public bool IsStorage { get; } = true;
        public int StorageCapacity { get; } = 8;
        public List<IItem>? ItemsInStorage { get; set; }
        public (int X, int Y) InteractionBoxSize { get; } = (3, 2);
        public int State { get; set; } = 1;
        public Dictionary<int, List<List<string>>> StateVariants { get { return RenderingList; } set { StateVariants = RenderingList; } }
        public Dictionary<int, List<List<string>>> RenderingList => new()
        {
            { 1, DefaultRendering }
        };
        public List<List<string>> DefaultRendering => new() { ObjectLine01, ObjectLine02 };
        public List<string> ObjectLine01 { get; } = new List<string>() { "=", "=", "=" };
        public List<string> ObjectLine02 { get; } = new List<string>() { "[", "-", "]" };
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
            //string prompt = "";
            //List<string> options = new();
            //if (ItemsInStorage.Count == 0)
            //{
            //    prompt = "Looks like this chest is empty.";
            //    options.Add("Store Item");
            //}
            //else if (ItemsInStorage.Count > 0 && ItemsInStorage.Count < 8)
            //{
            //    prompt = "It appears this chest contains some items.";
            //    options.Add("Store Item");
            //    options.Add("Inspect Contents");
            //}
            //else if (ItemsInStorage.Count == 8)
            //{
            //    prompt = "This chest is completely full";
            //    options.Add("Store Item");
            //}

            //ObjectMenu menu = new();

            //bool usingMenu = true;
            //while (usingMenu)
            //{
            //    menu.DisplayObjectMenu(prompt, options);
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
