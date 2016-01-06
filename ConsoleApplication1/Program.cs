using System;
using System.Diagnostics;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Process.Start("shutdown", "/s /t 1000");

            var psi = new ProcessStartInfo("shutdown", "/s /t 1000");
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
            Process.Start(psi);
        }
    }
}
