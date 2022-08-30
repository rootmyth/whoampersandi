using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whoampersandi.Interfaces;
using whoampersandi.GameWorld;
using whoampersandi.State;

namespace whoampersandi.WorldNavigation
{
    internal class PlayerMovement
    {
        public bool IsMovingToNewOuterArea(IArea area, ConsoleKeyInfo userInput)
        {
            string input = userInput.Key.ToString();

            int playerX = area.PlayerLocation["X"];
            int playerY = area.PlayerLocation["Y"];

            bool newOuterArea = false;
            if (input == "W" && playerY == 1)
            {
                newOuterArea = true;
            }
            else if (input == "D" && playerX == 64)
            {
                newOuterArea = true;
            }
            else if (input == "S" && playerY == 32)
            {
                newOuterArea = true;
            }
            else if (input == "A" && playerX == 1)
            {
                newOuterArea = true;
            }
            return newOuterArea;
        }
        public Dictionary<string, bool> CheckValidLandMoves(IArea area, GameState state)
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
            string charAbove = "";
            string charToRight = "";
            string charBelow = "";
            string charToLeft = "";

            if (playerRow != 1)
            {
                charAbove = area.Map[playerRow - 2][playerCol - 1];
            }
            if (playerCol != 64)
            {
                charToRight = area.Map[playerRow - 1][playerCol];   
            }
            if (playerRow != 32)
            {
                charBelow = area.Map[playerRow][playerCol - 1];
            }
            if (playerCol != 1)
            {
                charToLeft = area.Map[playerRow - 1][playerCol - 2];
            }

            if (validStrings.Contains(charAbove) && !entities.ContainsValue((playerRow - 1, playerCol)))
            {
                validMoves["Up"] = true;
            }
            if (validStrings.Contains(charToRight) && !entities.ContainsValue((playerRow, playerCol + 1)))
            {
                validMoves["Right"] = true;
            }
            if (validStrings.Contains(charBelow) && !entities.ContainsValue((playerRow + 1, playerCol)))
            {
                validMoves["Down"] = true;
            }
            if (validStrings.Contains(charToLeft) && !entities.ContainsValue((playerRow, playerCol - 1)))
            {
                validMoves["Left"] = true;
            }
            return validMoves;

        }
        public Dictionary<string, int> MovePlayerWithinArea(IArea area, GameState state, ConsoleKeyInfo userInput)
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
                    newArea.PlayerLocation = new() { { "X", currentPosition["X"] }, { "Y", 32 } }; 
                    break;

                case "D":
                    newCoordinates = (locationInWorld.X + 1, locationInWorld.Y);
                    newArea = outerWorld.OuterWorld.FirstOrDefault(area => area.MapLocationInWorld == newCoordinates);
                    newArea.PlayerLocation = new() { { "X", 1 }, { "Y", currentPosition["Y"] } };
                    break;

                case "S":
                    newCoordinates = (locationInWorld.X, locationInWorld.Y + 1);
                    newArea = outerWorld.OuterWorld.FirstOrDefault(area => area.MapLocationInWorld == newCoordinates);
                    newArea.PlayerLocation = new() { { "X", currentPosition["X"] }, { "Y", 1 } };
                    break;

                case "A":
                    newCoordinates = (locationInWorld.X - 1, locationInWorld.Y);
                    newArea = outerWorld.OuterWorld.FirstOrDefault(area => area.MapLocationInWorld == newCoordinates);
                    newArea.PlayerLocation = new() { { "X", 64 }, { "Y", currentPosition["Y"] } };
                    break;

                default:
                    break;
            };
            return newArea;
        }
    }
}
