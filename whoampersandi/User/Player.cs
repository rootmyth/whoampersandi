using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whoampersandi.Interfaces;

namespace whoampersandi.User
{
    public class Player
    {
        public string Appearance { get; } = "&";
        public string Name { get; set; } = "";
        public int Level { get; set; } = 1;
        public int LevelPoints { get; set; } = 0;
        public int Experience { get; set; } = 0;
        public int Money { get; set; } = 100;
        public double Health { get; set; } = 10;
        public double Magic { get; set; } = 10;
        public double Morale { get; set; } = 7;
        public double MaxHealth { get; set; } = 10;
        public double MaxMagic { get; set; } = 10;
        public double MaxMorale { get; set; } = 10;
        public double Strength { get; set; } = 1;
        public double Defence { get; set; } = 1;
        public double Agility { get; set; } = 1;
        public double Wit { get; set; } = 1;
        public double Acuity { get; set; } = 1;
        public double Accuracy { get; set; } = 1;
        public List<IItem> Items { get; set; } = new();
    }
}
