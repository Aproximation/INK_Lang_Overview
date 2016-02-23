using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCde
{
    class AdvCode1
    {
        public void Run()
        {
            int counter = 0;
            string input = InputData.AdvCode1;
            for (int i = 0; i < input.Length; i++)
            {
                char item = input[i];

                if (item == '(')
                    counter++;
                else
                    counter--;

                if (counter == -1)
                    Console.WriteLine(i + 1);
            }
            Console.WriteLine(counter);
            Console.ReadLine();
        }
    }
}
