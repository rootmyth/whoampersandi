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
        public IEntity ReturnEntity(IArea area, GameState state)
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
