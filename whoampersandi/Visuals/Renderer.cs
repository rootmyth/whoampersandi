using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whoampersandi.OuterWorld;
using whoampersandi.Interfaces;
using whoampersandi.User;


namespace whoampersandi.Visuals
{
    public class Renderer
    {
        private LevelBar LevelBar = new();
        private StatusBar StatusBar = new();
        private Notification Notify = new();
        private Dialogue Text = new();

        public void RenderLevelBar(bool whiteSpace)
        {
            Console.SetCursorPosition(0, 0);
            if (whiteSpace)
            {
                Console.WriteLine(@$"                                                                
                                                                
                                                                ");
            }
            else
            {
                Console.WriteLine(@$"================================================================
|                                                              |
\==============================================================/");
            }
        }
        public void RenderLevelBar(Player user, IArea area)
        {
            Console.SetCursorPosition(0, 0);
            string level = LevelBar.DisplayLevel(user.Level);
            string experience = LevelBar.DisplayExperience(user.Experience);
            string money = LevelBar.DisplayMoney(user.Money);
            string areaName = LevelBar.DisplayArea(area.RegionName);

            Console.SetCursorPosition(0, 0);
            Console.WriteLine(@$"================================================================
| LEVEL {level} | EXP {experience} | {money} | {areaName} |
\==============================================================/");
        }
        public void RenderWorldViewer()
        {
            Console.SetCursorPosition(0, 3);
            Console.WriteLine(@"                                                                
                                                                
                                                                
                                                                
                                                                
                                                                
                                                                
                                                                
                                                                
                                                                
                                                                
                                                                
                                                                
                                                                
                                                                
                                                                
                                                                
                                                                
                                                                
                                                                
                                                                
                                                                
                                                                
                                                                
                                                                
                                                                
                                                                
                                                                
                                                                
                                                                
                                                                
                                                                ");
        }
        public void RenderWorldViewer(Player player, Dictionary<IEntity, (int, int)> entities, Dictionary<IObject, (int, int)> objects, IArea area)
        {
            Console.SetCursorPosition(0, 3);
            area.RenderMap(player, entities, objects);
        }
        public void RenderStatusBar(bool whiteSpace)
        {
            Console.SetCursorPosition(0, 35);
            if (whiteSpace)
            {
                Console.WriteLine(@$"                                                                
                                                                
                                                                ");
            }
            else
            {
            Console.WriteLine(@$"/==============================================================\
|                                                              |
================================================================");
            }
        }
        public void RenderStatusBar(Player user)
        {
            string health = StatusBar.DisplayMeter(user.Health, user.MaxHealth);
            string magic = StatusBar.DisplayMeter(user.Magic, user.MaxMagic);
            string morale = StatusBar.DisplayMeter(user.Morale, user.MaxMorale);

            Console.SetCursorPosition(0, 35);
            Console.WriteLine(@$"/==============================================================\
| LIFE : {health} | MAGIC : {magic} | MORALE : {morale} |
================================================================");

        }
        public void RenderDialogueBox()
        {
            Console.SetCursorPosition(0, 37);
            Console.WriteLine(@"================================================================
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
================================================================");
        }
        public void RenderDialogueBox(List<List<string>> dialogue)
        {
            for (int i = 0; i < dialogue.Count; i++)
            {
                Console.SetCursorPosition(0, 37);
                Console.WriteLine($@"================================================================
| {dialogue[i][0]} |
| {dialogue[i][1]} |
| {dialogue[i][2]} |
| {dialogue[i][3]} |
| {dialogue[i][4]} |
================================================================");
                bool spacebar = false;
                while (!spacebar)
                {
                    Console.SetCursorPosition(0, 44);
                    ConsoleKeyInfo input = Console.ReadKey();
                    if (input.Key.ToString() == "Spacebar")
                    {
                        spacebar = true;
                    }
                }
            }
        }

        public void RenderDialogueOnBlankScreen(List<List<string>> dialogue)
        {
            for (int i = 0; i < dialogue.Count; i++)
            {
                Console.SetCursorPosition(2, 2);
                Console.WriteLine($@"  {dialogue[i][0]}  
  {dialogue[i][1]}  
  {dialogue[i][2]}  
  {dialogue[i][3]}  
  {dialogue[i][4]}  ");
                bool spacebar = false;
                while (!spacebar)
                {
                    ConsoleKeyInfo input = Console.ReadKey();
                    if (input.Key.ToString() == "Spacebar")
                    {
                        spacebar = true;
                    }
                    else
                    {
                        Notify.RenderNotification(Text.CreateDialogueBoxText("Use the spacebar to scroll through dialogue.", 34, 2));
                        RenderWorldViewer();
                    }
                }
            }
        }

        public void RenderInformationBox(List<List<string>> information)
        {
            for (int i = 0; i < information.Count; i++)
            {
                Console.SetCursorPosition(0, 38);
                Console.WriteLine($@"| {information[i][0]} |
| {information[i][1]} |
| {information[i][2]} |
| {information[i][3]} |
| {information[i][4]} |
================================================================");
            } 
        }

        public void RenderMenuFrame()
        {

            Console.SetCursorPosition(6, 6);
            Console.Write("                                                    ");
            Console.SetCursorPosition(6, 7);
            Console.Write(@"  /==============================================\  ");
            Console.SetCursorPosition(6, 8);
            Console.Write("  |                                              |  ");
            Console.SetCursorPosition(6, 9);
            Console.Write("  ================================================  ");
            for (int i = 0; i < 20; i++)
            {
                Console.SetCursorPosition(6, 10 + i);
                Console.Write("  |                                              |  ");
            }
            Console.SetCursorPosition(6, 30);
            Console.Write("  ================================================  ");
            Console.SetCursorPosition(6, 31);
            Console.Write("                                                    ");
        }
        public void RenderNotification()
        {

        }
    }
}
