using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwaitStopwatchDemo
{
    public class Tasks
    {
        public async Task OneSecondTask()
        {
            await Task.Delay(1000);
            return;
        }

        public async Task FourSecondTask()
        {
            await Task.Delay(4000);
            return;
        }

        public async Task TwoSecondTask()
        {
            await Task.Delay(2000);
            return;
        }

        public async Task ThreeSecondTask()
        {
            await Task.Delay(3000);
            return;
        }
    }
}
