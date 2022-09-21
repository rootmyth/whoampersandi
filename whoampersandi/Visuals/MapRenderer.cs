using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whoampersandi.Interfaces;
using whoampersandi.User;

namespace whoampersandi.Visuals
{
    public class MapRenderer
    {
        public void DisplayArea(IArea area, Player player, Dictionary<IEntity, (int, int)> entities, Dictionary<IObject, (int, int)> objects)
        {
            List<(IObject areaObject, (int X, int Y) location, List<(int X, int Y)> boxCoords)> objectList = new();
            foreach (KeyValuePair<IObject, (int, int)> obj in objects)
            {
                objectList.Add((obj.Key, obj.Value, obj.Key.CreateInteractionBox(obj.Value)));
            }

            List<(int X, int Y)> objectCoordinatesList = new();
            foreach (KeyValuePair<IObject, (int X, int Y)> obj in objects)
            {
                objectCoordinatesList.AddRange(obj.Key.CreateInteractionBox(obj.Value));
            }

            int row = 0;
            foreach (List<string> consoleLineList in area.Map)
            {
                int column = 0;
                string consoleLineChars = "";
                foreach (string character in consoleLineList)
                {
                    if (entities.ContainsValue((column, row)))
                    {
                        consoleLineChars += entities.FirstOrDefault(entity => entity.Value == (column, row)).Key.Appearance;
                    }
                    else if (objectCoordinatesList.Contains((column, row)))
                    {
                        foreach ((IObject areaObject, (int X, int Y) location, List<(int X, int Y)> boxCoords) obj in objectList)
                        {
                            if (obj.boxCoords.Contains((column, row)))
                            {
                                consoleLineChars += obj.areaObject.ReturnRendering()[row - obj.location.Y][column - obj.location.X];
                            }
                        }
                    }
                    else if (area.PlayerLocation["X"] == column && area.PlayerLocation["Y"] == row)
                    {
                        consoleLineChars += player.Appearance;
                    }
                    else
                    {
                        consoleLineChars += character;
                    }
                    column++;
                }
                Console.WriteLine(consoleLineChars);
                row++;
            }
        }
    }
}
