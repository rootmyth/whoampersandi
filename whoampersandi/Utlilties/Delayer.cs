using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whoampersandi.Utlilties
{
    public class Delayer
    {
        public async Task Delay(int mil)
        {
            await Task.Delay(mil);
        }
    }
}
