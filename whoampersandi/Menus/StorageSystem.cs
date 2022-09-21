using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whoampersandi.Interfaces;
using whoampersandi.State;
using whoampersandi.User;
using whoampersandi.Visuals;

namespace whoampersandi.Menus
{
    internal class StorageSystem
    {
        public bool UsingStorage { get; set; } = true;
        public int SystemIndex { get; set; } = 0;
        public (string title, int X, int Y) MenuTitle { get; set; }
        public void ViewInventoryForStorage(List<MenuUnit> menus, IObject storage, InformationState infoState, Player player)
        {
            Renderer Display = new();
            Dialogue Text = new();
            Notification Notify = new();

            while (UsingStorage)
            {
// Display all the things
                if (SystemIndex == -1)
                {
                    UsingStorage = false;
                    break;
                }

                MenuUnit activeMenu = menus[SystemIndex];
                activeMenu.IsActive = true;

                if (menus[0].Index > 0)
                {
                    Display.RenderInformationBox(Text.CreateDialogueBoxText(player.Items[menus[0].Index - 1].Details, 60, 5));
                }
                else
                {
                    Display.RenderDialogueBox();
                }

                Console.SetCursorPosition(MenuTitle.X, MenuTitle.Y);
                Console.WriteLine(MenuTitle.title);

                for (int i = 0; i <= SystemIndex; i++)
                {
// Make a variable location for the submenu's Y coordinate, I
// want the submenu to appear next to the selected item but if
// the last or second to last item is selected then the sub-
// menu would bleed past the desired height and into the menu
// frame.
                    if (i == 1)
                    {
                        if (menus[0].Index > menus[0].Size.height - 2)
                        {
                            menus[1].OptionsLocation = (menus[1].OptionsLocation.X, menus[1].OptionsLocation.Y + menus[0].Size.height - 2);
                        }
                        else 
                        {
                            menus[1].OptionsLocation = (menus[1].OptionsLocation.X, menus[0].OptionsLocation.Y + menus[0].Index);
                        }
                    }
                    menus[i].DisplayMenu();
                }

//Take in an input from user
                Console.SetCursorPosition(0, 44);
                string input = Console.ReadKey(true).Key.ToString();

//Change stuff
                if (input == "W" && activeMenu.Index > 0)
                {
                    activeMenu.Index--;
                }
                else if (input == "S" && activeMenu.Index < activeMenu.Options.Count - 1)
                {
                    activeMenu.Index++;
                }
                else if (input == "Enter" && activeMenu.Index == 0)
                {
                    SystemIndex--;
                }
                else if (input == "Enter" && activeMenu.SystemIndex == 0)
                {
                    SystemIndex++;
                }
                else if (input == "Enter" && activeMenu.SystemIndex == 1 && activeMenu.Index == 1)
                {
                    int itemIndex = menus[0].Index - 1;
                    Notify.RenderNotification(Text.CreateDialogueBoxText($"You put the {player.Items[itemIndex].Description.ToLower()} in the {storage.Description.ToLower()}.", 32, 8));
                    storage.ItemsInStorage.Add(player.Items[itemIndex]);
                    player.Items.RemoveAt(itemIndex);
                    menus[0].Options.RemoveAt(itemIndex + 1);
                    SystemIndex--;
                    menus[0].Index--;
                }
                else if (input == "Enter" && activeMenu.SystemIndex == 1 && activeMenu.Index == 2)
                {
                    IItem playerItem = player.Items[menus[0].Index - 1];
                    bool infoValue = infoState.ItemInfo.FirstOrDefault(item => item.itemName == playerItem.Description).currentState;
                    string moreInfo = playerItem.MoreInfo.FirstOrDefault(info => info.Key == infoValue).Value;
                    Notify.RenderNotification(Text.CreateDialogueBoxText(moreInfo, 32, 8));
                }
            }
        }

        public void ViewStorageContents(List<MenuUnit> menus, IObject storage, InformationState infoState, Player player)
        {
            Renderer Display = new();
            Dialogue Text = new();
            Notification Notify = new();

            while (UsingStorage)
            {
                // Display all the things
                if (SystemIndex == -1)
                {
                    UsingStorage = false;
                    break;
                }

                MenuUnit activeMenu = menus[SystemIndex];
                activeMenu.IsActive = true;

                if (menus[0].Index > 0)
                {
                    Display.RenderInformationBox(Text.CreateDialogueBoxText(storage.ItemsInStorage[menus[0].Index - 1].Details, 60, 5));
                }
                else
                {
                    Display.RenderDialogueBox();
                }

                Console.SetCursorPosition(MenuTitle.X, MenuTitle.Y);
                Console.WriteLine(MenuTitle.title);

                for (int i = 0; i <= SystemIndex; i++)
                {
                    // Make a variable location for the submenu's Y coordinate, I
                    // want the submenu to appear next to the selected item but if
                    // the last or second to last item is selected then the sub-
                    // menu would bleed past the desired height and into the menu
                    // frame.
                    if (i == 1)
                    {
                        if (menus[0].Index > menus[0].Size.height - 2)
                        {
                            menus[1].OptionsLocation = (menus[1].OptionsLocation.X, menus[1].OptionsLocation.Y + menus[0].Size.height - 2);
                        }
                        else
                        {
                            menus[1].OptionsLocation = (menus[1].OptionsLocation.X, menus[0].OptionsLocation.Y + menus[0].Index);
                        }
                    }
                    menus[i].DisplayMenu();
                }

                //Take in an input from user
                Console.SetCursorPosition(0, 44);
                string input = Console.ReadKey(true).Key.ToString();

                //Change stuff
                if (input == "W" && activeMenu.Index > 0)
                {
                    activeMenu.Index--;
                }
                else if (input == "S" && activeMenu.Index < activeMenu.Options.Count - 1)
                {
                    activeMenu.Index++;
                }
                else if (input == "Enter" && activeMenu.Index == 0)
                {
                    SystemIndex--;
                }
                else if (input == "Enter" && activeMenu.SystemIndex == 0)
                {
                    SystemIndex++;
                }
                else if (input == "Enter" && activeMenu.SystemIndex == 1 && activeMenu.Index == 1)
                {
                    int itemIndex = menus[0].Index - 1;
                    Notify.RenderNotification(Text.CreateDialogueBoxText($"You added the {storage.ItemsInStorage[itemIndex].Description} to your inventory.", 32, 8));
                    player.Items.Add(storage.ItemsInStorage[itemIndex]);
                    storage.ItemsInStorage.RemoveAt(itemIndex);
                    menus[0].Options.RemoveAt(itemIndex + 1);
                    SystemIndex--;
                    menus[0].Index--;
                }
                else if (input == "Enter" && activeMenu.SystemIndex == 1 && activeMenu.Index == 2)
                {
                    IItem storageItem = storage.ItemsInStorage[menus[0].Index - 1];
                    bool infoValue = infoState.ItemInfo.FirstOrDefault(item => item.itemName == storageItem.Description).currentState;
                    string moreInfo = storageItem.MoreInfo.FirstOrDefault(info => info.Key == infoValue).Value;
                    Notify.RenderNotification(Text.CreateDialogueBoxText(moreInfo, 32, 8));
                }
            }
        }
    }
}
