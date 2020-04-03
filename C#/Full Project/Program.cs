using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighscoreSys
{
    class Program
    {
        static void Main(string[] args)
        {
            Handle h = new Handle("http://localhost");
            h.AddValue(1500);
            h.UpdateValues();
            h.ToConsole();
            Console.Read();
            
        }
    }
}
