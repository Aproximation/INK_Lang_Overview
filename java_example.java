import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
 
public class CalculateCircleAreaExample {
 
        public static void Main(string[] args){}
               
            int radius = 0;
            System.out.println("Please enter radius of a circle");
               
			BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
            radius = Integer.parseInt(br.readLine());
               
            double area = Math.PI * radius * radius;
               
            System.out.println("Area of a circle is " + area);
        }
}



//C#
using System;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            double radius = 0;
            Console.WriteLine("Please enter radius of a circle");
            radius = Convert.ToDouble(Console.ReadLine());
            double area = Math.PI * radius * radius;

            Console.WriteLine("Area of a circle is " + area);
        }
    }
}
