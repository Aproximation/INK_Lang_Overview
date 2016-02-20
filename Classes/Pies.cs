using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Pies : Zwierze
    {
        public readonly string furColor;
        public Pies(string Name, string furColor) : base(Name, Typ.ssaki){
            this.furColor = furColor;
        }

        public override string Sound()
        {
            return "hau hau";
        }
    }
}
