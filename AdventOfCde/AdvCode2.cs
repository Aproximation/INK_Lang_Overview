using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCde
{
    class AdvCode2
    {
        public void Run()
        {
            int paperSum = 0;
            int wrapAndBowSum = 0;
            string input = InputData.AdvCode2;
            var splitted = input.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in splitted)
            {
                // var może być dowolnym typem. Może to być int, string, bool...kompilator sam dopasuje typ na podstawie tego co zwróci mu prawa strona równania. 
                // W tym przypadku item.Split('x'); zwraca tablice stringów - najedź myszką na Split i zobacz, że typem zwracanym przez metodę jest string[]
                var st = item.Split('x');
                int l = Convert.ToInt32(st[0]);
                int w = Convert.ToInt32(st[1]);
                int h = Convert.ToInt32(st[2]);

                //Lista, to bardzo ciekawa strukturka. Bardzo podobna do tablicy (z ang: Array), ale jest dynamiczna (rozszerzalna i zmniejszana w locie) 
                //a także posiada wiele ciekawych metod jak np Sort()
                List<int> ints = new List<int>() { l, w, h };
                ints.Sort();

                int paper = 2 * l * w + 2 * h * w + 2 * l * h + ints[0] * ints[1];

                int wrap = ints[0] + ints[0] + ints[1] + ints[1];
                int bow = l * w * h;

                paperSum += paper;
                wrapAndBowSum += wrap + bow;
            }
            Console.WriteLine(paperSum);
            Console.WriteLine(wrapAndBowSum);
            Console.ReadLine();
        }
    }
}
