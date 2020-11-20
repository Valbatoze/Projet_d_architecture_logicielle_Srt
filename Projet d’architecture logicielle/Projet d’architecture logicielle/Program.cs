using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using static Projet_d_architecture_logicielle.Sub;

namespace Projet_d_architecture_logicielle
{
    class Program
    {
        public static async Task Main()
        {
            Sub srt = new Sub();
            Task t = srt.DispSub();
            await t;
        }
        //(╯°□°）╯︵ ┻━┻ 
    }
}
