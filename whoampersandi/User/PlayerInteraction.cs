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
        public bool CheckEntityProxy(IArea area, GameState state)
        {
            Dictionary<IEntity, (int X, int Y)> entities = area.GetEntitiesForState(state);
            int playerRow = area.PlayerLocation["Y"];
            int playerCol = area.PlayerLocation["X"];

            bool entityAbove = entities.ContainsValue((playerRow - 1, playerCol));
            bool entityToRight = entities.ContainsValue((playerRow, playerCol + 1));
            bool entityBelow = entities.ContainsValue((playerRow + 1, playerCol));
            bool entityToLeft = entities.ContainsValue((playerRow, playerCol - 1));

            bool entityProxy = false;

            if (entityAbove || entityToRight || entityBelow || entityToLeft)
            {
                entityProxy = true;
            }
            return entityProxy;
        }
        public IEntity ReturnEntity(IArea area, GameState state)
        {
            Dictionary<IEntity, (int X, int Y)> entities = area.GetEntitiesForState(state);
            int playerRow = area.PlayerLocation["Y"];
            int playerCol = area.PlayerLocation["X"];

            bool entityAbove = entities.ContainsValue((playerRow - 1, playerCol));
            bool entityToRight = entities.ContainsValue((playerRow, playerCol + 1));
            bool entityBelow = entities.ContainsValue((playerRow + 1, playerCol));
            bool entityToLeft = entities.ContainsValue((playerRow, playerCol - 1));

            IEntity? entity = null;

            if (entityAbove)
            {
                entity = entities.FirstOrDefault(entity => entity.Value == (playerRow - 1, playerCol)).Key;
            }
            else if (entityToRight)
            {
                entity = entities.FirstOrDefault(entity => entity.Value == (playerRow, playerCol + 1)).Key;
            }
            else if (entityBelow)
            {
                entity = entities.FirstOrDefault(entity => entity.Value == (playerRow + 1, playerCol)).Key;
            }
            else if (entityToLeft)
            {
                entity = entities.FirstOrDefault(entity => entity.Value == (playerRow, playerCol - 1)).Key;
            }
            return entity;
        }
    }
}
