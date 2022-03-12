using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringTheory
{
    public delegate void STFunc();
    public delegate void STFunc1(int i);

    public class Function : Event
    {
        STFunc func;

        public Function(STFunc func)
        {
            this.func = func;
        }
        public override void Run()
        {
            func();
        }
    }

}
