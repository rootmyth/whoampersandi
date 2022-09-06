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
        public void RenderWorldViewer(Player player, Dictionary<IEntity, (int, int)> entities, IArea area)
        {
            Console.SetCursorPosition(0, 3);
            area.RenderMap(player, entities);
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
            Console.SetCursorPosition(0, 38);
            Console.WriteLine(@"|                                                              |
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
                Console.SetCursorPosition(0, 38);
                Console.WriteLine($@"| {dialogue[i][0]} |
| {dialogue[i][1]} |
| {dialogue[i][2]} |
| {dialogue[i][3]} |
| {dialogue[i][4]} |
================================================================");
                bool spacebar = false;
                while (!spacebar)
                {
                    ConsoleKeyInfo input = Console.ReadKey();
                    if (input.Key.ToString() == "Spacebar")
                    {
                        spacebar = true;
                    }
                }
            }
        }
        public void RenderMenu()
        {
        
        }
    }
}
