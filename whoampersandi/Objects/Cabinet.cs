using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whoampersandi.Interfaces;
using whoampersandi.State;
using whoampersandi.User;
using whoampersandi.Visuals;
using whoampersandi.Menus;

namespace whoampersandi.Objects
{
    public class Cabinet : IObject
    {
        public Cabinet()
        {
            ItemsInStorage = new();
        }
        public Cabinet(List<IItem> items)
        {
            ItemsInStorage = items;
        }
        public string Description { get; } = "Cabinet";
        public bool IsStorage { get; } = true;
        public int StorageCapacity { get; } = 16;
        public List<IItem> ItemsInStorage { get; set; }
        public (int X, int Y) InteractionBoxSize { get; } = (3, 3);
        public int State { get; set; } = 1;
        public Dictionary<int, List<List<string>>> StateVariants { get { return RenderingList; } set { StateVariants = RenderingList; } }
        public Dictionary<int, List<List<string>>> RenderingList => new()
        {
            { 1, DefaultRendering }
        };
        public List<(string text, List<string> options)> Prompts { get; } = new()
        {
            { ("Looks like this cabinet is empty.", new List<string> { "Store Item" }) },
            { ( "This cabinet is completely full", new List<string> { "Inspect Contents" }) },
            { ( "It appears this cabinet contains some items.", new List<string> { "Store Item", "Inspect Contents"}) }
        };
        public List<List<string>> DefaultRendering => new() { ObjectLine01, ObjectLine02, ObjectLine03 };
        public List<string> ObjectLine01 { get; } = new List<string>() { "=", "=", "="};
        public List<string> ObjectLine02 { get; } = new List<string>() { "[", "|", "]" };
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
            ObjectMenu promptMenu = new();
            (string prompt, List<string> options) menu = new();
            
            if (ItemsInStorage.Count == 0) { menu = Prompts[0]; }
            else if (ItemsInStorage.Count == 16) { menu = Prompts[1]; }
            else { menu = Prompts[2]; }


            int interactionMenuSelection = promptMenu.UseObjectMenu(menu.prompt, menu.options);
            if (interactionMenuSelection == 1)
            {
                Renderer frame = new();

                // Set up first Menu Unit - Options, OptionsLocation, Size, SystemIndex
                MenuUnit itemList = new();
                foreach (IItem item in player.Items)
                {
                    itemList.Options.Add(item.Description);
                }
                itemList.OptionsLocation = (13, 11);
                itemList.Size = (38, 16);
                itemList.SystemIndex = 0;

                // Set up second Menu Unit - Options, OptionsLocation, Size, SystemIndex
                MenuUnit itemSubMenu = new();
                itemSubMenu.Options.AddRange(new List<string> { "Stow Item", "More Info" });
                itemSubMenu.OptionsLocation = (37, 11);
                itemSubMenu.Size = (10, 16);
                itemSubMenu.SystemIndex = 1;

                StorageSystem cabinetSystem = new();

                frame.RenderMenuFrame();
                cabinetSystem.ViewInventoryForStorage(new List<MenuUnit> { itemList, itemSubMenu }, this, infoState, player);
            }
            if (interactionMenuSelection == 2)
            {
                CabinetMenuFrame frame = new();

                // Set up first Menu Unit - Options, OptionsLocation, Size, SystemIndex
                MenuUnit itemList = new();
                foreach (IItem item in ItemsInStorage)
                {
                    itemList.Options.Add(item.Description);
                }
                itemList.OptionsLocation = (13, 11);
                itemList.Size = (38, 16);
                itemList.SystemIndex = 0;

                // Set up second Menu Unit - Options, OptionsLocation, Size, SystemIndex
                MenuUnit itemSubMenu = new();
                itemSubMenu.Options.AddRange(new List<string> { "Take", "More Info" });
                itemSubMenu.OptionsLocation = (37, 11);
                itemSubMenu.Size = (10, 16);
                itemSubMenu.SystemIndex = 1;

                StorageSystem cabinetSystem = new();

                frame.RenderCabinetFrame();
                cabinetSystem.ViewStorageContents(new List<MenuUnit> { itemList, itemSubMenu }, this, infoState, player);
            }
        }
    }
}
