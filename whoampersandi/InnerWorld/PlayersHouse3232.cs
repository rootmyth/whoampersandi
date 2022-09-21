using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whoampersandi.Interfaces;
using whoampersandi.User;
using whoampersandi.State;
using whoampersandi.Entities;
using whoampersandi.Objects;
using whoampersandi.WorldNavigation;
using whoampersandi.OuterWorld;
using whoampersandi.Events.Repository;
using whoampersandi.Items;
using whoampersandi.Visuals;

namespace whoampersandi.InnerWorld
{
    public class PlayersHouse3232 : IArea
    {
        public string RegionName { get; } = "HEISENBURG";
        public bool IsOuterWorld { get; } = false;
        public bool HasEvents { get; set; } = true;
        public (int X, int Y) MapLocationInWorld { get; } = (32, 32);
        public Dictionary<string, int> PlayerLocation { get; set; }
        public List<Dictionary<IEntity, (int X, int Y)>>? Entities { get; set; } = new()
        {
            new()
            {
                { new MotherLovelace(), (27, 14) }
            },
        };
        public List<Dictionary<IObject, (int X, int Y)>>? Objects { get; set; } = new()
        {
            new()
            {
                { new Cabinet(), (37, 17) },
                { new Cabinet(new List<IItem> { new Bucket() }), (40, 17) }
            },
        };
        public List<Transpoint> Transpoints { get; } = new()
        {
            new(35, 23, "S", "IW3232_PlayersHouse_FrontDoor", "H3232_PlayersHouse_FrontDoor", true, 32, 32, 23, 17)
        };
        public List<List<string>> MapMatrix => new()
        {
            MapLine01, MapLine02, MapLine03, MapLine04, MapLine05, MapLine06, MapLine07, MapLine08,
            MapLine09, MapLine10, MapLine11, MapLine12, MapLine13, MapLine14, MapLine15, MapLine16,
            MapLine17, MapLine18, MapLine19, MapLine20, MapLine21, MapLine22, MapLine23, MapLine24,
            MapLine25, MapLine26, MapLine27, MapLine28, MapLine29, MapLine30, MapLine31, MapLine32
        };
        public List<List<string>> Map { get { return MapMatrix; } set { Map = MapMatrix; } }

        public List<string> MapLine01 { get; set; } = new List<string>() { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", };
        public List<string> MapLine02 { get; set; } = new List<string>() { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", };
        public List<string> MapLine03 { get; set; } = new List<string>() { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", };
        public List<string> MapLine04 { get; set; } = new List<string>() { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", };
        public List<string> MapLine05 { get; set; } = new List<string>() { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", };
        public List<string> MapLine06 { get; set; } = new List<string>() { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", };
        public List<string> MapLine07 { get; set; } = new List<string>() { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", };
        public List<string> MapLine08 { get; set; } = new List<string>() { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "_", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", };
        public List<string> MapLine09 { get; set; } = new List<string>() { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "_", "_", "_", "_", "_", "_", "_", "|", "_", "|", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", };
        public List<string> MapLine10 { get; set; } = new List<string>() { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|", "|", "=", "|", "|", "_", "_", "_", "|", " ", "|", "_", "_", "_", "|", "|", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "|", "|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", };
        public List<string> MapLine11 { get; set; } = new List<string>() { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|", "|", "=", "|", "|", " ", " ", " ", "T", "_", "T", " ", " ", " ", "|", "|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|", "|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", };
        public List<string> MapLine12 { get; set; } = new List<string>() { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|", "|", "=", "|", "|", " ", " ", " ", "[", "x", "]", " ", " ", " ", "[", "]", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|", "|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", };
        public List<string> MapLine13 { get; set; } = new List<string>() { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|", "|", "=", "|", "|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "_", " ", " ", " ", " ", "_", " ", "|", "|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", };
        public List<string> MapLine14 { get; set; } = new List<string>() { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|", "|", " ", "[", "]", " ", " ", " ", " ", " ", " ", " ", " ", " ", "-", "-", " ", " ", " ", " ", "|", "-", "|", " ", " ", "|", "1", "|", "|", "|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", };
        public List<string> MapLine15 { get; set; } = new List<string>() { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|", "|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|", "|", " ", " ", " ", " ", "|", "_", "|", " ", " ", "|", "_", "|", "|", "|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", };
        public List<string> MapLine16 { get; set; } = new List<string>() { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|", "|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|", "|", " ", " ", " ", " ", "!", " ", "!", " ", " ", " ", "H", " ", "|", "|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", };
        public List<string> MapLine17 { get; set; } = new List<string>() { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|", "|", " ", " ", " ", "_", " ", " ", " ", " ", " ", " ", " ", " ", "|", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "|", "|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", };
        public List<string> MapLine18 { get; set; } = new List<string>() { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|", "|", " ", "_", "|", " ", "|", "_", " ", " ", " ", " ", " ", " ", "|", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "|", "|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", };
        public List<string> MapLine19 { get; set; } = new List<string>() { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|", "|", " ", "H", "|", "_", "|", "H", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|", "|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", };
        public List<string> MapLine20 { get; set; } = new List<string>() { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|", "|", " ", " ", "/", "_", "\\", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|", "|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", };
        public List<string> MapLine21 { get; set; } = new List<string>() { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|", "|", " ", " ", " ", "H", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|", "|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", };
        public List<string> MapLine22 { get; set; } = new List<string>() { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|", "|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|", "|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", };
        public List<string> MapLine23 { get; set; } = new List<string>() { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", " ", " ", " ", "_", "_", "_", "_", "_", "_", "_", "_", "_", "|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", };
        public List<string> MapLine24 { get; set; } = new List<string>() { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "|", "|", " ", "|", "|", "_", "_", "_", "_", "_", "_", "_", "_", "|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", };
        public List<string> MapLine25 { get; set; } = new List<string>() { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|", "_", "_", "_", "|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", };
        public List<string> MapLine26 { get; set; } = new List<string>() { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|", "_", "_", "_", "|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", };
        public List<string> MapLine27 { get; set; } = new List<string>() { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", };
        public List<string> MapLine28 { get; set; } = new List<string>() { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", };
        public List<string> MapLine29 { get; set; } = new List<string>() { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", };
        public List<string> MapLine30 { get; set; } = new List<string>() { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", };
        public List<string> MapLine31 { get; set; } = new List<string>() { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", };
        public List<string> MapLine32 { get; set; } = new List<string>() { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", };

        public MapRenderer MapRenderer { get; } = new();

        public Dictionary<IEntity, (int X, int Y)> GetEntitiesForState(EventState state)
        {
            return Entities[0];
        }

        public Dictionary<IObject, (int X, int Y)> GetObjectsForState(EventState state)
        {
            return Objects[0];
        }

        public void GetAreaEvents(IArea area, Player player, Dictionary<IEntity, (int, int)> entities, Dictionary<IObject, (int, int)> objects, OuterWorldMap outerWorld, InnerWorldMap innerWorld, EventState state)
        {
            if (state.firstInteractionAtHome)
            {
                FirstInteractionAtHome e = new();
                e.EventSequence(area, player, entities, objects, outerWorld, innerWorld, state);
                state.firstInteractionAtHome = false;
            }
        }

        public void RenderMap(Player player, Dictionary<IEntity, (int, int)> entities, Dictionary<IObject, (int, int)> objects)
        {
            MapRenderer.DisplayArea(this, player, entities, objects);
        }
    }
}
