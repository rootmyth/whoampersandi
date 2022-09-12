using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whoampersandi.User;
using whoampersandi.State;
using whoampersandi.WorldNavigation;
using whoampersandi.OuterWorld;
using whoampersandi.InnerWorld;

namespace whoampersandi.Interfaces
{
    public interface IArea
    {
        string RegionName { get; }
        bool IsOuterWorld { get; }
        bool HasEvents { get; set; }
        (int X, int Y) MapLocationInWorld { get; }
        Dictionary<string, int> PlayerLocation { get; set; }
        List<Dictionary<IEntity, (int X, int Y)>>? Entities { get; set; }
        List<Transpoint> Transpoints { get; }
        List<List<string>> Map { get; set; }
        List<string> MapLine01 { get; set; }
        List<string> MapLine02 { get; set; }
        List<string> MapLine03 { get; set; }
        List<string> MapLine04 { get; set; }
        List<string> MapLine05 { get; set; }
        List<string> MapLine06 { get; set; }
        List<string> MapLine07 { get; set; }
        List<string> MapLine08 { get; set; }
        List<string> MapLine09 { get; set; }
        List<string> MapLine10 { get; set; }
        List<string> MapLine11 { get; set; }
        List<string> MapLine12 { get; set; }
        List<string> MapLine13 { get; set; }
        List<string> MapLine14 { get; set; }
        List<string> MapLine15 { get; set; }
        List<string> MapLine16 { get; set; }
        List<string> MapLine17 { get; set; }
        List<string> MapLine18 { get; set; }
        List<string> MapLine19 { get; set; }
        List<string> MapLine20 { get; set; }
        List<string> MapLine21 { get; set; }
        List<string> MapLine22 { get; set; }
        List<string> MapLine23 { get; set; }
        List<string> MapLine24 { get; set; }
        List<string> MapLine25 { get; set; }
        List<string> MapLine26 { get; set; }
        List<string> MapLine27 { get; set; }
        List<string> MapLine28 { get; set; }
        List<string> MapLine29 { get; set; }
        List<string> MapLine30 { get; set; }
        List<string> MapLine31 { get; set; }
        List<string> MapLine32 { get; set; }
        Dictionary<IEntity, (int X, int Y)>? GetEntitiesForState(GameState state);
        Dictionary<IObject, (int X, int Y)> GetObjectsForState(GameState state);
        void GetAreaEvents(IArea area, Player player, Dictionary<IEntity, (int, int)> entities, Dictionary<IObject, (int, int)> objects, OuterWorldMap outerworld, InnerWorldMap innerWorld, GameState state);
        void RenderMap(Player player, Dictionary<IEntity, (int, int)> entities, Dictionary<IObject, (int, int)> objects);
    }
}
