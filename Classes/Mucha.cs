using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Mucha : Zwierze
    {
        public int wingsNum;
        public Mucha() : base("", Typ.owady) {
            wingsNum = 2;
        }

        public override string Sound()
        {
            return "bzz bzz";
        }
    }
}
