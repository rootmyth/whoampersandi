using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whoampersandi.User;
using whoampersandi.Visuals;
using whoampersandi.OuterWorld;
using whoampersandi.InnerWorld;
using whoampersandi.Interfaces;
using whoampersandi.WorldNavigation;
using whoampersandi.State;
using whoampersandi.Events;
using whoampersandi.Menus;

namespace whoampersandi
{
    public class Game
    {
        private static Player User = new();
        private OuterWorldMap OuterWorld = new();
        private InnerWorldMap InnerWorld = new();
        private Renderer Display = new();
        private PlayerInteraction Interaction = new();
        private PlayerMovement Movement = new();
        private Dialogue Text = new();
        private EventState EState = new();
        private InformationState InfoState = new();
        private MainMenu Menu = new();


        private bool _userIsPlayingGame = true;

        private IArea areaToDisplay { get; set; }
        public void Start()
        {
            Console.SetWindowSize(64, 45);
            Console.SetBufferSize(64, 45);
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.White;

            while (_userIsPlayingGame)
            {
                
                Console.SetCursorPosition(0, 0);

                if (EState.newGame)
                {
                    //areaToDisplay = InnerWorld.Map.FirstOrDefault(area => area.MapLocationInWorld == (32, 32));
                    areaToDisplay = OuterWorld.Map.FirstOrDefault(area => area.MapLocationInWorld == (33, 32));
                    areaToDisplay.PlayerLocation = new() { { "X", 25}, { "Y", 21} };
                }

                if (areaToDisplay.HasEvents)
                {
                    areaToDisplay.GetAreaEvents(areaToDisplay, User, areaToDisplay.GetEntitiesForState(EState), areaToDisplay.GetObjectsForState(EState), OuterWorld, InnerWorld, EState);
                }
                Display.RenderLevelBar(User, areaToDisplay);
                Display.RenderWorldViewer(User, areaToDisplay.GetEntitiesForState(EState), areaToDisplay.GetObjectsForState(EState), areaToDisplay);
                Display.RenderStatusBar(User);
                Display.RenderDialogueBox();

                Console.SetCursorPosition(0, 44);
                ConsoleKeyInfo userInput = Console.ReadKey(true);
                Update(areaToDisplay, OuterWorld, InnerWorld, userInput);

            }
        }

        public void Update(IArea currentArea, OuterWorldMap outerWorld, InnerWorldMap innerWorld, ConsoleKeyInfo userInput)
        {
            string input = userInput.Key.ToString();

            if (input == "W" || input == "D" || input == "S" || input == "A")
            {
                if (Movement.IsMovingToNewOuterArea(currentArea, userInput))
                {
                    areaToDisplay = Movement.MovePlayerToNewOuterArea(currentArea, outerWorld, userInput);
                }
                else if (Movement.IsMovingThroughTranspoint(currentArea, userInput))
                {
                    areaToDisplay = Movement.MovePlayerThroughTranspoint(currentArea, outerWorld, innerWorld);
                }
                else
                {
                    areaToDisplay.PlayerLocation = Movement.MovePlayerWithinArea(currentArea, EState, userInput);
                }
            }
            else if (input == "Spacebar")
            {
                if (Interaction.CheckEntityProxy(currentArea, EState))
                {
                    IEntity entity = Interaction.ReturnEntity(currentArea, EState);
                    Display.RenderDialogueBox(Text.CreateDialogueBoxText(entity.EngaugeInDialouge(EState), 60, 5, User));
                }
                else if (Interaction.CheckObjectProxy(currentArea, EState))
                {
                    IObject obj = Interaction.ReturnObject(currentArea, EState);
                    obj.InteractWithObject(User, InfoState);
                }
            }
            else if (input == "E")
            {
                Display.RenderMenuFrame();
                bool usingMenu = true;
                while (usingMenu)
                {
                    
                    Menu.DisplayMainMenu(User);
                    Console.SetCursorPosition(0, 44);
                    ConsoleKeyInfo menuInput = Console.ReadKey(true);
                    
                    if (!Menu.UpdateMenu(menuInput))
                    {
                        usingMenu = false;
                    }
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }
    }
}
