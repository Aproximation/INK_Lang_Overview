using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    abstract public class Zwierze
    {
        private Typ _type;
        private int _eyesNum;
        public string Name { get; set; }
        public Typ GetAnimalType()
        {
            return _type;
        }

        public Zwierze(string Name, Typ type)
        {
            this.Name = Name;
            _type = type;
        }

        public string GetEyesNum()
        {
            string result="";
            switch (_type)
            {
                case Typ.owady:
                    result = "Wiele";
                    break;
                case Typ.płazińce:
                    result = "Brak";
                    break;
                default:
                    result = "Para";
                    break;
            }
            return result;
        }

        abstract public string Sound();
    }
}
