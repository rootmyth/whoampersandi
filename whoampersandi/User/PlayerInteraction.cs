using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whoampersandi.WorldNavigation;
using whoampersandi.Interfaces;
using whoampersandi.State;

namespace whoampersandi.User
{
    public class PlayerInteraction
    {
        public bool CheckEntityProxy(IArea area, EventState state)
        {
            Dictionary<IEntity, (int X, int Y)> entities = area.GetEntitiesForState(state);
            int playerRow = area.PlayerLocation["Y"];
            int playerCol = area.PlayerLocation["X"];

            bool entityAbove = entities.ContainsValue((playerCol, playerRow - 1));
            bool entityToRight = entities.ContainsValue((playerCol + 1, playerRow));
            bool entityBelow = entities.ContainsValue((playerCol, playerRow + 1));
            bool entityToLeft = entities.ContainsValue((playerCol - 1, playerRow));

            bool entityProxy = false;

            if (entityAbove || entityToRight || entityBelow || entityToLeft)
            {
                entityProxy = true;
            }
            return entityProxy;
        }
        public bool CheckObjectProxy(IArea area, EventState state)
        {
            Dictionary<IObject, (int X, int Y)> objects = area.GetObjectsForState(state);
            List<(int X, int Y)> objectCoordinatesList = new();
            foreach (KeyValuePair<IObject, (int X, int Y)> obj in objects)
            {
                objectCoordinatesList.AddRange(obj.Key.CreateInteractionBox(obj.Value));
            }

            int playerRow = area.PlayerLocation["Y"];
            int playerCol = area.PlayerLocation["X"];

            bool objectAbove = objectCoordinatesList.Contains((playerCol, playerRow - 1));
            bool objectToRight = objectCoordinatesList.Contains((playerCol + 1, playerRow));
            bool objectBelow = objectCoordinatesList.Contains((playerCol, playerRow + 1));
            bool objectToLeft = objectCoordinatesList.Contains((playerCol - 1, playerRow));

            bool objectProxy = false;

            if (objectAbove || objectToRight || objectBelow || objectToLeft)
            {
                objectProxy = true;
            }
            return objectProxy;
        }
        public IObject ReturnObject(IArea area, EventState state)
        {
            Dictionary<IObject, (int X, int Y)> objects = area.GetObjectsForState(state);
            List<(int X, int Y)> objectCoordinatesList = new();
            foreach (KeyValuePair<IObject, (int X, int Y)> obj in objects)
            {
                objectCoordinatesList.AddRange(obj.Key.CreateInteractionBox(obj.Value));
            }

            List<(IObject areaObject, (int X, int Y) location, List<(int X, int Y)> boxCoords)> objectList = new();
            foreach (KeyValuePair<IObject, (int, int)> obj in objects)
            {
                objectList.Add((obj.Key, obj.Value, obj.Key.CreateInteractionBox(obj.Value)));
            }

            int playerRow = area.PlayerLocation["Y"];
            int playerCol = area.PlayerLocation["X"];

            bool objectAbove = objectCoordinatesList.Contains((playerCol, playerRow - 1));
            bool objectToRight = objectCoordinatesList.Contains((playerCol + 1, playerRow));
            bool objectBelow = objectCoordinatesList.Contains((playerCol, playerRow + 1));
            bool objectToLeft = objectCoordinatesList.Contains((playerCol - 1, playerRow));

            IObject? objectToReturn = null;

            if (objectAbove)
            {
                objectToReturn = objectList.FirstOrDefault(obj => obj.boxCoords.Contains((playerCol, playerRow - 1))).areaObject;
            }
            else if (objectToRight)
            {
                objectToReturn = objectList.FirstOrDefault(obj => obj.boxCoords.Contains((playerCol + 1, playerRow))).areaObject;
            }
            else if (objectBelow)
            {
                objectToReturn = objectList.FirstOrDefault(obj => obj.boxCoords.Contains((playerCol, playerRow + 1))).areaObject;
            }
            else if (objectToLeft)
            {
                objectToReturn = objectList.FirstOrDefault(obj => obj.boxCoords.Contains((playerCol - 1, playerRow))).areaObject;
            }
            return objectToReturn;
        }
        public IEntity ReturnEntity(IArea area, EventState state)
        {
            Dictionary<IEntity, (int X, int Y)> entities = area.GetEntitiesForState(state);
            int playerRow = area.PlayerLocation["Y"];
            int playerCol = area.PlayerLocation["X"];

            bool entityAbove = entities.ContainsValue((playerCol, playerRow - 1));
            bool entityToRight = entities.ContainsValue((playerCol + 1, playerRow));
            bool entityBelow = entities.ContainsValue((playerCol, playerRow + 1));
            bool entityToLeft = entities.ContainsValue((playerCol - 1, playerRow));

            IEntity? entity = null;

            if (entityAbove)
            {
                entity = entities.FirstOrDefault(entity => entity.Value == (playerCol, playerRow - 1)).Key;
            }
            else if (entityToRight)
            {
                entity = entities.FirstOrDefault(entity => entity.Value == (playerCol + 1, playerRow)).Key;
            }
            else if (entityBelow)
            {
                entity = entities.FirstOrDefault(entity => entity.Value == (playerCol, playerRow + 1)).Key;
            }
            else if (entityToLeft)
            {
                entity = entities.FirstOrDefault(entity => entity.Value == (playerCol - 1, playerRow)).Key;
            }
            return entity;
        }
    }
}
