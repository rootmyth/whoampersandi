using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whoampersandi.Interfaces;
using whoampersandi.State;

namespace whoampersandi.Items
{
    internal class Bucket : IItem
    {
        public string Description { get; } = "Empty Bucket";
        public int StackLimit { get; } = 1;
        public bool CanBeUsedInCombat { get; } = false;
        public int Heaviness { get; set; } = 0;
        public string Details { get; } = "Buckets have a few uses, but are best for transporting water.";
        public Dictionary<bool, string> MoreInfo { get; } = new()
        {
            { false, "No additional information is available." },
            { true, "Water can be obtained from natural sources and wells with a bucket. They're also great for storing catches while fishing, allowing you to make the best use of your time." }
        };
        public List<string> CanBeUsedWith { get; } = new() { "Water" };
        public int? UseLimit { get; } = null;
        public int Uses { get; set; } = 0;
    }
}
