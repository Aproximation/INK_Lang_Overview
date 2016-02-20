using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            Pies mojPies = new Pies("Azor", "Czarny");
            string piesText = String.Format("Mój pies nazywa się {0} i jego sierść ma kolor {1}\nLiczba oczy mojego psa to: {2}\nMoj pies robi {3}",
                mojPies.Name, 
                mojPies.furColor, 
                mojPies.GetEyesNum(), 
                mojPies.Sound());

            Console.WriteLine(piesText);

            Mucha mucha = new Mucha();
            
            string muchaText = String.Format("To jest mucha. Mucha nie ma imienia{0}. \nMa {1} skrzydełka. Liczba oczu u muchy, to: {2}\nMucha robi {3}", 
                mucha.Name,
                mucha.wingsNum.ToString(),
                mucha.GetEyesNum(),
                mucha.Sound()
                );
            Console.WriteLine(muchaText);
            mucha.wingsNum = 1;
            Console.WriteLine(mucha.wingsNum.ToString());

            //======================

            List<Zwierze> mojeZwierzeta = new List<Zwierze>();
            mojeZwierzeta.Add(mojPies);
            mojeZwierzeta.Add(mucha);
            mojeZwierzeta.Add(mucha);
            mojeZwierzeta.Add(mucha);
            mojeZwierzeta.Add(mojPies);

            Console.WriteLine("W domu mam zwierzat sztuk " + mojeZwierzeta.Count);
            foreach (var item in mojeZwierzeta)
            {
                Console.WriteLine(String.Format("{0} co ma oczu {1} i robi {2}",
                    item.GetType().Name,
                    item.GetEyesNum(),
                    item.Sound()
                    ));
                if (item.GetType().Name == "Pies")
                {
                    var pies = (Pies)item;
                    Console.WriteLine(pies.furColor);
                }
                
            }


        }
    }
}
