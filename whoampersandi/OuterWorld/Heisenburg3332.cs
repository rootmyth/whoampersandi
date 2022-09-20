using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whoampersandi.Interfaces;
using whoampersandi.User;
using whoampersandi.Entities;
using whoampersandi.State;
using whoampersandi.WorldNavigation;
using whoampersandi.Events.Repository;
using whoampersandi.InnerWorld;

namespace whoampersandi.OuterWorld
{
    internal class Heisenburg3332 : IArea
    {
        public string RegionName { get; } = "HEISENBURG";
        public bool IsOuterWorld { get; } = true;
        public bool HasEvents { get; set; } = true;
        public (int X, int Y) MapLocationInWorld { get; } = ( 33, 32 );
        public Dictionary<string, int> PlayerLocation { get; set; } = new();
        public List<Dictionary<IEntity, (int X, int Y)>>? Entities { get; set; } = new()
        {
            new()
            {
                { new Pig(), (20, 9) },
                { new Pig(), (35, 12) },
                { new Pig(), (37, 16) },
                { new GoodSamaritan(), (25, 20)}
            }
        };
        public List<Dictionary<IObject, (int X, int Y)>>? Objects { get; set; } = new()
        {
            new()
            {

            },
        };
        public List<Transpoint> Transpoints { get; } = new()
        {

        };
        public List<List<string>> MapMatrix => new()
        {
            MapLine01,
            MapLine02,
            MapLine03,
            MapLine04,
            MapLine05,
            MapLine06,
            MapLine07,
            MapLine08,
            MapLine09,
            MapLine10,
            MapLine11,
            MapLine12,
            MapLine13,
            MapLine14,
            MapLine15,
            MapLine16,
            MapLine17,
            MapLine18,
            MapLine19,
            MapLine20,
            MapLine21,
            MapLine22,
            MapLine23,
            MapLine24,
            MapLine25,
            MapLine26,
            MapLine27,
            MapLine28,
            MapLine29,
            MapLine30,
            MapLine31,
            MapLine32
        };
        public List<List<string>> Map { get { return MapMatrix; } set { Map = MapMatrix; } }

        public List<string> MapLine01 { get; set; } = new List<string>() { " ", " ", "/", " ", " ", "\\", "_", "_", "\\", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "/", "_", "_", "\\", "/", "\\", " ", "\\", " ", " ", " ", " ", " ", " ", " ", " ", };
        public List<string> MapLine02 { get; set; } = new List<string>() { " ", " ", "/", "_", "_", "\\", "|", "|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|", "|", "/", " ", " ", "\\", "/", "\\", " ", " ", " ", " ", " ", " ", "/", };
        public List<string> MapLine03 { get; set; } = new List<string>() { " ", " ", " ", "|", "|", " ", "-", "-", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "-", "-", "/", " ", " ", "/", " ", " ", "\\", " ", " ", "/", "\\", "/", " ", };
        public List<string> MapLine04 { get; set; } = new List<string>() { " ", " ", " ", "-", "-", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "/", "_", " ", "/", " ", " ", "\\", " ", "/", " ", " ", "/", " ", };
        public List<string> MapLine05 { get; set; } = new List<string>() { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|", "/", "\\", " ", "_", "\\", " ", "/", " ", "_", "/", "\\", };
        public List<string> MapLine06 { get; set; } = new List<string>() { "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "/", " ", " ", "\\", "|", " ", " ", "/", "_", "/", " ", " ", };
        public List<string> MapLine07 { get; set; } = new List<string>() { "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "|", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "/", " ", " ", "\\", "-", " ", " ", " ", "|", "/", " ", " ", };
        public List<string> MapLine08 { get; set; } = new List<string>() { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "_", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "_", "_", "_", "_", "_", "_", "_", "|", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "/", " ", " ", "\\", " ", " ", " ", " ", "-", "/", "_", "_", };
        public List<string> MapLine09 { get; set; } = new List<string>() { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "@", "_", ")", " ", " ", " ", " ", " ", " ", " ", " ", " ", "\\", "_", "_", "_", "_", "_", "/", "|", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "/", "_", "_", "\\", " ", " ", " ", " ", " ", " ", "|", "|", };
        public List<string> MapLine10 { get; set; } = new List<string>() { " ", " ", ".", ",", ".", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|", "|", " ", " ", " ", " ", " ", " ", " ", "-", "-", };
        public List<string> MapLine11 { get; set; } = new List<string>() { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "*", " ", " ", " ", " ", " ", "_", " ", " ", " ", " ", " ", " ", " ", " ", "|", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "-", "-", " ", " ", " ", " ", " ", " ", " ", " ", " ", };
        public List<string> MapLine12 { get; set; } = new List<string>() { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "@", "_", ")", " ", " ", " ", " ", " ", " ", " ", " ", "|", " ", "|", " ", " ", " ", " ", " ", " ", "|", "|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "*", " ", " ", " ", " ", " ", " ", };
        public List<string> MapLine13 { get; set; } = new List<string>() { " ", " ", " ", " ", " ", "_", " ", " ", " ", " ", " ", " ", " ", "*", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|", "_", "|", " ", " ", " ", " ", " ", " ", "|", "|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", };
        public List<string> MapLine14 { get; set; } = new List<string>() { " ", " ", " ", " ", "@", "_", ")", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", ".", ",", ".", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|", "|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", };
        public List<string> MapLine15 { get; set; } = new List<string>() { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "_", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|", "|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", };
        public List<string> MapLine16 { get; set; } = new List<string>() { "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "@", "_", ")", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|", "|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", };
        public List<string> MapLine17 { get; set; } = new List<string>() { "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "|", "|", " ", " ", "*", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|", "|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "/", };
        public List<string> MapLine18 { get; set; } = new List<string>() { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|", "|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|", "|", " ", " ", " ", " ", " ", " ", "_", "_", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "/", " ", };
        public List<string> MapLine19 { get; set; } = new List<string>() { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|", "|", " ", " ", " ", " ", " ", " ", " ", " ", " ", ".", ",", ".", " ", " ", " ", " ", "_", " ", " ", " ", " ", "|", "|", " ", " ", " ", " ", " ", "/", "_", "_", "\\", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "/", " ", };
        public List<string> MapLine20 { get; set; } = new List<string>() { " ", " ", " ", " ", " ", " ", "*", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|", "|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "@", "_", ")", " ", " ", " ", "|", "|", " ", " ", " ", " ", " ", "+", "[", "]", "+", "L", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "/", "_", };
        public List<string> MapLine21 { get; set; } = new List<string>() { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|", "|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "*", " ", " ", " ", " ", " ", " ", " ", "|", "|", " ", " ", " ", " ", " ", "|", "_", "_", "|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|", };
        public List<string> MapLine22 { get; set; } = new List<string>() { "_", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|", "|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|", "|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "/", "\\", };
        public List<string> MapLine23 { get; set; } = new List<string>() { "~", "\\", "_", " ", " ", " ", " ", " ", ".", ",", ".", " ", " ", " ", " ", " ", " ", "|", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "/", " ", " ", };
        public List<string> MapLine24 { get; set; } = new List<string>() { "~", "~", "~", "\\", "_", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "/", "\\", "/", " ", " ", };
        public List<string> MapLine25 { get; set; } = new List<string>() { "~", "~", "~", "~", "~", "\\", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "/", " ", " ", "\\", "_", "_", };
        public List<string> MapLine26 { get; set; } = new List<string>() { "~", "~", "~", "~", "~", "~", "\\", "_", "_", "_", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "/", " ", " ", "\\", "|", "|", };
        public List<string> MapLine27 { get; set; } = new List<string>() { "~", "~", "~", "~", "~", "~", "~", "~", "~", "~", "\\", "_", "_", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", ".", ",", ".", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "/", " ", " ", "\\", "-", "-", };
        public List<string> MapLine28 { get; set; } = new List<string>() { "~", "~", "~", "~", "~", "~", "~", "~", "~", "~", "~", "~", "~", "\\", "_", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "/", "\\", "_", "_", "\\", " ", " ", };
        public List<string> MapLine29 { get; set; } = new List<string>() { "~", "~", "~", "~", "~", "~", "~", "~", "~", "~", "~", "~", "~", "~", "~", "\\", " ", " ", "*", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "*", " ", " ", " ", " ", " ", " ", " ", " ", " ", "/", " ", " ", "\\", "|", " ", " ", " ", };
        public List<string> MapLine30 { get; set; } = new List<string>() { "~", "~", "~", "~", "~", "~", "~", "~", "~", "~", "~", "~", "~", "~", "~", "/", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "*", " ", " ", " ", " ", " ", " ", " ", " ", "/", "\\", " ", " ", "/", " ", " ", "\\", "-", "/", "\\", " ", };
        public List<string> MapLine31 { get; set; } = new List<string>() { "~", "~", "~", "~", "~", "~", "~", "~", "~", "~", "~", "~", "~", "~", "~", "\\", "_", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "/", " ", " ", "\\", " ", "/", "_", "_", "\\", "/", " ", " ", "\\", };
        public List<string> MapLine32 { get; set; } = new List<string>() { "~", "~", "~", "~", "~", "~", "~", "~", "~", "~", "~", "~", "~", "~", "~", "~", "~", "\\", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "/", " ", " ", "\\", " ", " ", "|", "|", " ", "/", " ", " ", "\\", };

        public Dictionary<IEntity, (int X, int Y)> GetEntitiesForState(EventState state)
        {
            Dictionary<IEntity, (int X, int Y)>? entities = null;

            if (state.firstEpsomBath)
            {
                entities = Entities[0];
            }
            
            return entities;
        }

        public Dictionary<IObject, (int X, int Y)> GetObjectsForState(EventState state)
        {
            return Objects[0];
        }

        public void GetAreaEvents(IArea area, Player player, Dictionary<IEntity, (int, int)> entities, Dictionary<IObject, (int, int)> objects, OuterWorldMap outerworld, InnerWorldMap innerWorld, EventState state)
        {
            if (state.newGame)
            {
                NewGame e = new();
                e.EventSequence(area, player, entities, objects, outerworld, innerWorld, state);
                state.newGame = false;
            }
        }

        public void RenderMap(Player player, Dictionary<IEntity, (int, int)> entities, Dictionary<IObject, (int, int)> objects)
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
            foreach (List<string> consoleLineList in Map)
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
                    else if (PlayerLocation["X"] == column && PlayerLocation["Y"] == row)
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
