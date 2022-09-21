using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whoampersandi.Interfaces;
using whoampersandi.OuterWorld;
using whoampersandi.State;
using whoampersandi.InnerWorld;

namespace whoampersandi.WorldNavigation
{
    internal class PlayerMovement
    {
        public Dictionary<string, bool> CheckValidLandMoves(IArea area, EventState state)
        {
            Dictionary<string, bool> validMoves = new Dictionary<string, bool>()
            {
                { "Up", false },
                { "Right", false },
                { "Down", false },
                { "Left", false }
            };

            List<string> validStrings = new() { " ", "*", ",", "." };

            int playerRow = area.PlayerLocation["Y"];
            int playerCol = area.PlayerLocation["X"];

            Dictionary<IEntity, (int X, int Y)> entities = area.GetEntitiesForState(state);
            Dictionary<IObject, (int X, int Y)> objects = area.GetObjectsForState(state);

            List<(int X, int Y)> objectCoordinatesList = new();
            foreach (KeyValuePair<IObject, (int X, int Y)> obj in objects)
            {
                objectCoordinatesList.AddRange(obj.Key.CreateInteractionBox(obj.Value));
            }

            string charAbove = "";
            string charToRight = "";
            string charBelow = "";
            string charToLeft = "";

            if (playerRow != 0)
            {
                charAbove = area.Map[playerRow - 1][playerCol];
            }
            if (playerCol != 63)
            {
                charToRight = area.Map[playerRow][playerCol + 1];
            }
            if (playerRow != 31)
            {
                charBelow = area.Map[playerRow + 1][playerCol];
            }
            if (playerCol != 0)
            {
                charToLeft = area.Map[playerRow][playerCol - 1];
            }

            if (validStrings.Contains(charAbove) && !entities.ContainsValue((playerCol, playerRow - 1)) && !objectCoordinatesList.Contains((playerCol, playerRow - 1)))
            {
                validMoves["Up"] = true;
            }
            if (validStrings.Contains(charToRight) && !entities.ContainsValue((playerCol + 1, playerRow)) && !objectCoordinatesList.Contains((playerCol + 1, playerRow)))
            {
                validMoves["Right"] = true;
            }
            if (validStrings.Contains(charBelow) && !entities.ContainsValue((playerCol, playerRow + 1)) && !objectCoordinatesList.Contains((playerCol, playerRow + 1)))
            {
                validMoves["Down"] = true;
            }
            if (validStrings.Contains(charToLeft) && !entities.ContainsValue((playerCol - 1, playerRow)) && !objectCoordinatesList.Contains((playerCol - 1, playerRow)))
            {
                validMoves["Left"] = true;
            }
            return validMoves;

        }

        public bool IsMovingToNewOuterArea(IArea area, ConsoleKeyInfo userInput)
        {
            string input = userInput.Key.ToString();

            int playerX = area.PlayerLocation["X"];
            int playerY = area.PlayerLocation["Y"];

            bool newOuterArea = false;
            if (input == "W" && playerY == 0)
            {
                newOuterArea = true;
            }
            else if (input == "D" && playerX == 63)
            {
                newOuterArea = true;
            }
            else if (input == "S" && playerY == 31)
            {
                newOuterArea = true;
            }
            else if (input == "A" && playerX == 0)
            {
                newOuterArea = true;
            }
            return newOuterArea;
        }

        public bool IsMovingThroughTranspoint(IArea area, ConsoleKeyInfo userInput)
        {
            string input = userInput.Key.ToString();

            bool isMovingThroughTranspoint = false;
            foreach (Transpoint tp in area.Transpoints)
            {
                if (tp.InitializationPoint["X"] == area.PlayerLocation["X"] && tp.InitializationPoint["Y"] == area.PlayerLocation["Y"] && tp.InitializationKey == input)
                {
                    isMovingThroughTranspoint = true;
                }
            }
            return isMovingThroughTranspoint;
        }

        public IArea MovePlayerToNewOuterArea(IArea area, OuterWorldMap outerWorld, ConsoleKeyInfo userInput)
        {
            Dictionary<string, int> currentPosition = area.PlayerLocation;
            (int X, int Y) locationInWorld = area.MapLocationInWorld;
            string input = userInput.Key.ToString();

            (int X, int Y) newCoordinates = (0, 0);
            IArea? newArea = null;

            switch (input)
            {
                case "W":
                    newCoordinates = (locationInWorld.X, locationInWorld.Y - 1);
                    newArea = outerWorld.OuterWorld.FirstOrDefault(area => area.MapLocationInWorld == newCoordinates);
                    newArea.PlayerLocation["X"] = currentPosition["X"];
                    newArea.PlayerLocation["Y"] = 31;
                    break;

                case "D":
                    newCoordinates = (locationInWorld.X + 1, locationInWorld.Y);
                    newArea = outerWorld.OuterWorld.FirstOrDefault(area => area.MapLocationInWorld == newCoordinates);
                    newArea.PlayerLocation["X"] = 0;
                    newArea.PlayerLocation["Y"] = currentPosition["Y"];
                    break;

                case "S":
                    newCoordinates = (locationInWorld.X, locationInWorld.Y + 1);
                    newArea = outerWorld.OuterWorld.FirstOrDefault(area => area.MapLocationInWorld == newCoordinates);
                    newArea.PlayerLocation["X"] = currentPosition["X"];
                    newArea.PlayerLocation["Y"] = 0;
                    break;

                case "A":
                    newCoordinates = (locationInWorld.X - 1, locationInWorld.Y);
                    newArea = outerWorld.OuterWorld.FirstOrDefault(area => area.MapLocationInWorld == newCoordinates);
                    newArea.PlayerLocation["X"] = 63;
                    newArea.PlayerLocation["Y"] = currentPosition["Y"];
                    break;

                default:
                    break;
            };
            return newArea;
        }
        public IArea MovePlayerThroughTranspoint(IArea area, OuterWorldMap outerWorld, InnerWorldMap innerWorld)
        {
            IArea? newArea = null;
            foreach (Transpoint tp in area.Transpoints)
            {
                if (tp.InitializationPoint["X"] == area.PlayerLocation["X"] && tp.InitializationPoint["Y"] == area.PlayerLocation["Y"])
                {
                    if (tp.TransToOuterWorld == true)
                    {
                        newArea = outerWorld.Map.FirstOrDefault(a => a.MapLocationInWorld == tp.LocationInWorld);
                        newArea.PlayerLocation = tp.playerSpawnLocation;
                    }
                    else
                    {
                        newArea = innerWorld.Map.FirstOrDefault(a => a.MapLocationInWorld == tp.LocationInWorld);
                        newArea.PlayerLocation = tp.playerSpawnLocation;
                    }
                }
            }
            return newArea;
        }

        public Dictionary<string, int> MovePlayerWithinArea(IArea area, EventState state, ConsoleKeyInfo userInput)
        {
            string input = userInput.Key.ToString();

            Dictionary<string, bool> validMoves = CheckValidLandMoves(area, state);
            Dictionary<string, int> currentPosition = area.PlayerLocation;

            Dictionary<string, int> newPosition = currentPosition;

            if (input == "W" && validMoves["Up"])
            {
                newPosition["Y"] = newPosition["Y"] - 1;
            }
            else if (input == "D" && validMoves["Right"])
            {
                newPosition["X"] = newPosition["X"] + 1;
            }
            else if (input == "S" && validMoves["Down"])
            {
                newPosition["Y"] = newPosition["Y"] + 1;
            }
            else if (input == "A" && validMoves["Left"])
            {
                newPosition["X"] = newPosition["X"] - 1;
            }

            return newPosition;
        }
    }
}
