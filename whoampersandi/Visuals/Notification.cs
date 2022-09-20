using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whoampersandi.Visuals
{
    internal class Notification
    {

        public void RenderNotification(List<List<string>> notification)
        {
            int notificationHeight = notification[0].Count;
            int notificationWidth = notification[0][0].Length;
            string blankLine = "";

            for (int i = 0; i < notificationWidth; i++)
            {
                blankLine += " ";
            }

            for (int i = notification[0].Count; i > 0; i--)
            {
                if (notification[0][i - 1] == blankLine)
                {
                    notificationHeight = notificationHeight - 1;
                }
            }

            int cursorYPosition = 13 - Convert.ToInt32(Math.Floor(Convert.ToDouble(notificationHeight)) / 2);

            for (int i = 0; i < notification.Count; i++)
            {
                Console.SetCursorPosition(11, cursorYPosition);
                Console.WriteLine(@"                                          ");
                Console.SetCursorPosition(11, cursorYPosition + 1);
                Console.WriteLine(@"   O__________________________________O   ");
                Console.SetCursorPosition(11, cursorYPosition + 2);
                Console.WriteLine(@"  {|==================================|}  ");
                Console.SetCursorPosition(11, cursorYPosition + 3);
                Console.WriteLine(@"  {|                                  |}  ");
                for (int j = 0; j < notificationHeight; j++)
                {
                    Console.SetCursorPosition(11, cursorYPosition + 4 + j);
                    Console.WriteLine(@"  {| " + $"{notification[i][j]}" + @" |}  ");
                }
                Console.SetCursorPosition(11, cursorYPosition + 4 + notificationHeight);
                Console.WriteLine(@"  {|                                  |}  ");
                Console.SetCursorPosition(11, cursorYPosition + 5 + notificationHeight);
                Console.WriteLine(@"  {|==================================|}  ");
                Console.SetCursorPosition(11, cursorYPosition + 6 + notificationHeight);
                Console.WriteLine(@"  {|__________________________________|}  ");
                Console.SetCursorPosition(11, cursorYPosition + 7 + notificationHeight);
                Console.WriteLine(@"   O    PRESS SPACEBAR TO CONTINUE    O   ");
                Console.SetCursorPosition(11, cursorYPosition + 8 + notificationHeight);
                Console.WriteLine(@"                                          ");
                Console.SetCursorPosition(0, 44);

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
    }
}
