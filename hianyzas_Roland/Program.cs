using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

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

            //2.feladat
            Console.WriteLine("2.feladat\nA naplóban {0} bejegyzés van.", n);

            //3.feladat
            int igazolt = 0;
            int igazolatlan = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < adatok[i].hianyzas.Length; j++)
                {
                    if (adatok[i].hianyzas[j] == 'X')
                    {
                        igazolt++;
                    }
                    if (adatok[i].hianyzas[j] == 'I')
                    {
                        igazolatlan++;
                    }

                }
            }
                Console.WriteLine("3.feladat\nAz igazolt hiányzások száma {0}, az igazolatlanoké {1} óra.",igazolt,igazolatlan);

            //5.feladat
            Console.Write("5.feladat\nA hónap sorszáma=");
            int honap = int.Parse(Console.ReadLine());
            Console.Write("A nap sorszáma=");
            int nap = int.Parse(Console.ReadLine());
            Console.WriteLine("Azon a napon {0} volt", hetnapja(honap, nap));

            //6.feladat
            Console.Write("A nap neve=");
            string napnev = Console.ReadLine();
            Console.Write("Az óra sorszáma=");
            int ora = int.Parse(Console.ReadLine());
            int hianyzas = 0;
            for (int i = 0;i<n;i++)
            {
                if (napnev == hetnapja(adatok[i].honap, adatok[i].nap))
                {
                    if(adatok[i].hianyzas[ora-1] == 'I' || adatok[i].hianyzas[ora - 1] == 'X' )
                    {
                        hianyzas++;
                    }

                }

            }

            Console.WriteLine("Ekkor összesen {0} óra hiányzás történt.",hianyzas);

            Console.ReadKey();
        }

        //4.feladat: függvény készítése
        static string hetnapja(int honap, int nap)
        {
            string[] napnev = {"vasarnap", "hetfo", "kedd", "szerda", "csutortok", "pentek", "szombat"};
            int[] napszam = {0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 335};
            int napsorszam = (napszam[honap - 1] + nap) % 7;
            string hetnapja = napnev[napsorszam];
            return hetnapja;
        }
    }
}
