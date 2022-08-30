using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whoampersandi.Visuals
{
    internal class LevelBar
    {
        public string DisplayLevel(int level)
        {
            string displayLevel;
            if (level >= 0 && level <= 9)
            {
                displayLevel = "00" + $"{level}";
            }
            else if (level >= 10 && level <= 99)
            {
                displayLevel = "0" + $"{level}";
            }
            else
            {
                displayLevel = $"{level}";
            }
            return displayLevel;
        }
        public string DisplayExperience(int experience)
        {
            string displayExperience;
            if (experience >= 0 && experience <= 9)
            {
                displayExperience = "000000" + $"{experience}";
            }
            else if (experience >= 10 && experience <= 99)
            {
                displayExperience = "00000" + $"{experience}";
            }
            else if (experience >= 100 && experience <= 999)
            {
                displayExperience = "0000" + $"{experience}";
            }
            else if (experience >= 1000 && experience <= 9999)
            {
                displayExperience = "000" + $"{experience}";
            }
            else if (experience >= 10000 && experience <= 99999)
            {
                displayExperience = "00" + $"{experience}";
            }
            else if (experience >= 100000 && experience <= 999999)
            {
                displayExperience = "0" + $"{experience}";
            }
            else
            {
                displayExperience = $"{experience}";
            }
            return displayExperience;
        }
        public string DisplayMoney(int money)
        {
            string displayMoney;
            if (money >= 0 && money <= 9)
            {
                displayMoney = "00000000" + $"{money}";
            }
            else if (money >= 10 && money <= 99)
            {
                displayMoney = "0000000" + $"{money}";
            }
            else if (money >= 100 && money <= 999)
            {
                displayMoney = "000000" + $"{money}";
            }
            else if (money >= 1000 && money <= 9999)
            {
                displayMoney = "00000" + $"{money}";
            }
            else if (money >= 10000 && money <= 99999)
            {
                displayMoney = "0000" + $"{money}";
            }
            else if (money >= 100000 && money <= 999999)
            {
                displayMoney = "000" + $"{money}";
            }
            else if (money >= 1000000 && money <= 9999999)
            {
                displayMoney = "00" + $"{money}";
            }
            else if (money >= 10000000 && money <= 99999999)
            {
                displayMoney = "0" + $"{money}";
            }
            else
            {
                displayMoney = $"{money}";
            }
            string moneyWithCommas = "$" + displayMoney.Insert(6, ",").Insert(3, ",");
            return moneyWithCommas;
        }
        public string DisplayArea(string areaName)
        {
            string displayArea = areaName;
            for (int i = 0; i < 19 - areaName.Length; i++)
            {
                displayArea += " ";
            }
            return displayArea;
        }
    }
}
