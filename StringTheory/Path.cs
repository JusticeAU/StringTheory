using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringTheory
{
    public class Path : Event
    {
        public int pathID;

        public Path(int id)
        {
            this.pathID = id;
        }

        public override void Run()
        {

        }
    }


}
