using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whoampersandi.User;
using whoampersandi.Visuals;
using whoampersandi.GameWorld;
using whoampersandi.Interfaces;
using whoampersandi.WorldNavigation;
using whoampersandi.State;
using whoampersandi.Events;

namespace whoampersandi
{
    public class Game
    {
        private Player User = new();
        private OuterWorldMap OuterWorld = new();
        private Renderer Display = new();
        private PlayerInteraction Interaction = new();
        private PlayerMovement Movement = new();
        private Dialogue Text = new();
        private GameState State = new();
        private NewGame New = new();

        private bool _userIsPlayingGame = true;


        private IArea areaToDisplay { get; set; } = new Heisenburg3232();
        public void Start()
        {
            Console.SetWindowSize(64, 45);
            Console.SetBufferSize(64, 45);
            Console.CursorVisible = false;

            while (_userIsPlayingGame)
            {
                
                
                Console.SetCursorPosition(0, 0);

                Display.RenderLevelBar(User, areaToDisplay);
                Display.RenderWorldViewer(User, areaToDisplay.GetEntitiesForState(State), areaToDisplay);
                Display.RenderStatusBar(User);
                Display.RenderDialogueBox();

                ConsoleKeyInfo userInput = Console.ReadKey();
                Update(areaToDisplay, OuterWorld, userInput);

            }
        }

        public void Update(IArea currentArea, OuterWorldMap outerWorld, ConsoleKeyInfo userInput)
        {
            string input = userInput.Key.ToString();

            if (input == "W" || input == "D" || input == "S" || input == "A")
            {
                if (Movement.IsMovingToNewOuterArea(currentArea, userInput))
                {
                    areaToDisplay = Movement.MovePlayerToNewOuterArea(currentArea, outerWorld, userInput);
                }
                else
                {
                    areaToDisplay.PlayerLocation = Movement.MovePlayerWithinArea(currentArea, State, userInput);
                }
            }
            else if (input == "Spacebar")
            {
                if (Interaction.CheckEntityProxy(currentArea, State))
                {
                    IEntity entity = Interaction.ReturnEntity(currentArea, State);
                    Display.RenderDialogueBox(Text.CreateDialogueBoxText(entity.EngaugeInDialouge()));
                    New.EventProgression();
                }
            }
        }
    }
}
