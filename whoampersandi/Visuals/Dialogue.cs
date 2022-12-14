using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whoampersandi.User;

namespace whoampersandi.Visuals
{
    public class Dialogue
    {
        public List<List<string>> CreateDialogueBoxText(string dialogue, int width, int height)
        {
            List<List<string>> Boxes = new();
            List<string> Lines = new();
            for (int i = 0; i < height; i++)
            {
                Lines.Add("");
            }

            string[] dialogueAsArray = dialogue.Split(" ");

            int lineCharCount = 0;
            int lineIndex = 0;
            int boxesIndex = 0;
            string newLine = "";
            for (int i = 0; i < dialogueAsArray.Length; i++)
            {
                lineCharCount = lineCharCount + dialogueAsArray[i].Length;
                if (lineCharCount == width)
                {
                    newLine += dialogueAsArray[i];
                    Lines[lineIndex] = newLine;
                    lineIndex++;
                    if (Lines[height - 1] != "")
                    {
                        List<string> newBoxSet = new();
                        for (int j = 0; j < height; j++)
                        {
                            newBoxSet.Add("");
                        }
                        Boxes.Add(newBoxSet);
                        for (int j = 0; j < Lines.Count; j++)
                        {
                            Boxes[boxesIndex][j] += Lines[j];
                            Lines[j] = "";
                        }
                        lineIndex = 0;
                        boxesIndex++;
                    }
                    lineCharCount = 0;
                    newLine = "";
                }
                else if (lineCharCount > width)
                {
                    int blankSpacesToAdd = width - lineCharCount + dialogueAsArray[i].Length;
                    for (int j = 0; j < blankSpacesToAdd; j++)
                    {
                        newLine += " ";
                    }
                    Lines[lineIndex] = newLine;
                    lineIndex++;
                    if (Lines[height - 1] != "")
                    {
                        List<string> newBoxSet = new();
                        for (int j = 0; j < height; j++)
                        {
                            newBoxSet.Add("");
                        }
                        Boxes.Add(newBoxSet);
                        for (int j = 0; j < Lines.Count; j++)
                        {
                            Boxes[boxesIndex][j] += Lines[j];
                            Lines[j] = "";
                        }
                        lineIndex = 0;
                        boxesIndex++;
                    }
                    lineCharCount = 0 + dialogueAsArray[i].Length + 1;
                    newLine = dialogueAsArray[i] + " ";
                }
                else
                {
                    newLine += dialogueAsArray[i];
                    newLine += " ";
                    lineCharCount++;
                }
                if (i + 1 == dialogueAsArray.Length)
                {
                    if (lineCharCount <= width)
                    {
                        int blankSpacesToAdd = width - lineCharCount;
                        for (int j = 0; j < blankSpacesToAdd; j++)
                        {
                            newLine += " ";
                        }
                        Lines[lineIndex] = newLine;
                        lineIndex++;
                        newLine = "";
                        for (int j = 0; j < width; j++)
                        {
                            newLine += " ";
                        }
                        int blankLinesToAdd = height - lineIndex;
                        for (int j = 0; j < blankLinesToAdd; j++)
                        {
                            Lines[lineIndex] = newLine;
                            lineIndex++;
                        }
                        List<string> newBoxSet = new();
                        for (int j = 0; j < height; j++)
                        {
                            newBoxSet.Add("");
                        }
                        Boxes.Add(newBoxSet);
                        for (int j = 0; j < Lines.Count; j++)
                        {
                            Boxes[boxesIndex][j] += Lines[j];
                            Lines[j] = "";
                        }
                    }
                }
            }
            return Boxes;
        }
        public List<List<string>> CreateDialogueBoxText(string dialogue, int width, int height, Player player)
        {
            List<List<string>> Boxes = new();
            List<string> Lines = new();
            for (int i = 0; i < height; i++)
            {
                Lines.Add("");
            }

            string[] dialogueAsArray = dialogue.Split(" ");

            int lineCharCount = 0;
            int lineIndex = 0;
            int boxesIndex = 0;
            string newLine = "";
            for (int i = 0; i < dialogueAsArray.Length; i++)
            {
                if (dialogueAsArray[i].Contains('~'))
                {
                    int indexOfName = dialogueAsArray[i].IndexOf("~");
                    dialogueAsArray[i] = dialogueAsArray[i].Remove(indexOfName, 1).Insert(indexOfName, player.Name);
                    
                }
                lineCharCount = lineCharCount + dialogueAsArray[i].Length;
                if (lineCharCount == width)
                {
                    newLine += dialogueAsArray[i];
                    Lines[lineIndex] = newLine;
                    lineIndex++;
                    if (Lines[height - 1] != "")
                    {
                        List<string> newBoxSet = new();
                        for (int j = 0; j < height; j++)
                        {
                            newBoxSet.Add("");
                        }
                        Boxes.Add(newBoxSet);
                        for (int j = 0; j < Lines.Count; j++)
                        {
                            Boxes[boxesIndex][j] += Lines[j];
                            Lines[j] = "";
                        }
                        lineIndex = 0;
                        boxesIndex++;
                    }
                    lineCharCount = 0;
                    newLine = "";
                }
                else if (lineCharCount > width)
                {
                    int blankSpacesToAdd = width - lineCharCount + dialogueAsArray[i].Length;
                    for (int j = 0; j < blankSpacesToAdd; j++)
                    {
                        newLine += " ";
                    }
                    Lines[lineIndex] = newLine;
                    lineIndex++;
                    if (Lines[height - 1] != "")
                    {
                        List<string> newBoxSet = new();
                        for (int j = 0; j < height; j++)
                        {
                            newBoxSet.Add("");
                        }
                        Boxes.Add(newBoxSet);
                        for (int j = 0; j < Lines.Count; j++)
                        {
                            Boxes[boxesIndex][j] += Lines[j];
                            Lines[j] = "";
                        }
                        lineIndex = 0;
                        boxesIndex++;
                    }
                    lineCharCount = 0 + dialogueAsArray[i].Length + 1;
                    newLine = dialogueAsArray[i] + " ";
                }
                else
                {
                    newLine += dialogueAsArray[i];
                    newLine += " ";
                    lineCharCount++;
                }
                if (i + 1 == dialogueAsArray.Length)
                {
                    if (lineCharCount <= width)
                    {
                        int blankSpacesToAdd = 60 - lineCharCount;
                        for (int j = 0; j < blankSpacesToAdd; j++)
                        {
                            newLine += " ";
                        }
                        Lines[lineIndex] = newLine;
                        lineIndex++;
                        newLine = "";
                        for (int j = 0; j < width; j++)
                        {
                            newLine += " ";
                        }
                        int blankLinesToAdd = height - lineIndex;
                        for (int j = 0; j < blankLinesToAdd; j++)
                        {
                            Lines[lineIndex] = newLine;
                            lineIndex++;
                        }
                        List<string> newBoxSet = new();
                        for (int j = 0; j < height; j++)
                        {
                            newBoxSet.Add("");
                        }
                        Boxes.Add(newBoxSet);
                        for (int j = 0; j < Lines.Count; j++)
                        {
                            Boxes[boxesIndex][j] += Lines[j];
                            Lines[j] = "";
                        }
                    }
                }
            }
            return Boxes;
        }
    }
}
