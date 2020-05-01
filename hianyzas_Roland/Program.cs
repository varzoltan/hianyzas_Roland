using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace hianyzas_Roland
{
    class Program
    {
        struct Adat
        {
            public int honap;
            public int nap;
            public string nev;
            public string hianyzas;
        }
        static void Main(string[] args)
        {
            Adat[] adatok = new Adat[600];
            StreamReader olvas = new StreamReader(@"C:\Users\Rendszergazda\Desktop\2017-oktober\naplo.txt");
            int n = 0;
            while (!olvas.EndOfStream)
            {
                string sor1 = olvas.ReadLine();
                string[] db1 = sor1.Split();
                while (!olvas.EndOfStream && olvas.Peek() != '#')//Javítottam!
                {
                    string sor2 = olvas.ReadLine();
                    string[] db2 = sor2.Split();
                    adatok[n].honap = int.Parse(db1[1]);
                    adatok[n].nap = int.Parse(db1[2]);
                    adatok[n].nev = db2[0]+" "+db2[1];
                    adatok[n].hianyzas = db2[2];
                    n++;
                }
            }
            olvas.Close();

            Console.ReadKey();
        }
    }
}
