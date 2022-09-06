using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whoampersandi.User;
using whoampersandi.Interfaces;
using whoampersandi.Visuals;

namespace whoampersandi.Utilities
{
    public class Fader
    {
        private Renderer Display = new();

        public async Task FadeIn(Player player, Dictionary<IEntity, (int, int)> entities, IArea area, int milliseconds)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Display.RenderLevelBar(player, area);
            Display.RenderWorldViewer(player, entities, area);
            Display.RenderStatusBar(player);
            Display.RenderDialogueBox();
            await Task.Delay(milliseconds);

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Display.RenderLevelBar(player, area);
            Display.RenderWorldViewer(player, entities, area);
            Display.RenderStatusBar(player);
            Display.RenderDialogueBox();
            await Task.Delay(milliseconds);

            Console.ForegroundColor = ConsoleColor.Gray;
            Display.RenderLevelBar(player, area);
            Display.RenderWorldViewer(player, entities, area);
            Display.RenderStatusBar(player);
            Display.RenderDialogueBox();
            await Task.Delay(milliseconds);

            Console.ForegroundColor = ConsoleColor.White;
            Display.RenderLevelBar(player, area);
            Display.RenderWorldViewer(player, entities, area);
            Display.RenderStatusBar(player);
            Display.RenderDialogueBox();
        }

        public async Task FadeOut(Player player, Dictionary<IEntity, (int, int)> entities, IArea area, int milliseconds)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Display.RenderLevelBar(player, area);
            Display.RenderWorldViewer(player, entities, area);
            Display.RenderStatusBar(player);
            await Task.Delay(milliseconds);

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Display.RenderLevelBar(player, area);
            Display.RenderWorldViewer(player, entities, area);
            Display.RenderStatusBar(player);
            await Task.Delay(milliseconds);

            Console.ForegroundColor = ConsoleColor.Black;
            Display.RenderLevelBar(player, area);
            Display.RenderWorldViewer(player, entities, area);
            Display.RenderStatusBar(player);
            await Task.Delay(milliseconds);
        }
    }
}
