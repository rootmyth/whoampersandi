using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whoampersandi.User;

namespace whoampersandi.Visuals
{
    public class StatusBar

    {
        public string DisplayMeter(double stat, double maxStat)
        {
            double meterPercentage = stat / maxStat;
            string meter = "";
            if (meterPercentage >= 0 && meterPercentage <= 0.1)
            {
                meter = "#         ";
            }
            else if (meterPercentage > 0.1 && meterPercentage <= 0.2)
            {
                meter = "##        ";
            }
            else if (meterPercentage > 0.2 && meterPercentage <= 0.3)
            {
                meter = "###       ";
            }
            else if (meterPercentage > 0.3 && meterPercentage <= 0.4)
            {
                meter = "####      ";
            }
            else if (meterPercentage > 0.4 && meterPercentage <= 0.5)
            {
                meter = "#####     ";
            }
            else if (meterPercentage > 0.5 && meterPercentage <= 0.6)
            {
                meter = "######    ";
            }
            else if (meterPercentage > 0.6 && meterPercentage <= 0.7)
            {
                meter = "#######   ";
            }
            else if (meterPercentage > 0.7 && meterPercentage <= 0.8)
            {
                meter = "########  ";
            }
            else if (meterPercentage > 0.8 && meterPercentage <= 0.9)
            {
                meter = "######### ";
            }
            else if (meterPercentage > 0.9 && meterPercentage <= 1)
            {
                meter = "##########";
            }


            return meter;
        }
    }
}
