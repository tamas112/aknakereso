using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1144_201003_Aknakereso
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] aknak = new char[5, 5];
            char[,] csillagok = new char[5, 5];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    csillagok[i, j] = '*';
                }
            }
            Random r = new Random();
            int db = 0;
            while (db < 5)
            {
                int s = r.Next(5);
                int o = r.Next(5);
                if (aknak[s, o] != 'A')
                {
                    aknak[s, o] = 'A';
                    db++;
                }
            }
            int vege = 0;
            while (vege == 0)
            {
                //a csillagok mátrik kiírása
                Console.Clear();
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        Console.Write(csillagok[i, j]);
                    }
                    Console.WriteLine();
                }
                //sor, oszlop bekérés
                Console.Write("Sor:");
                int sor = int.Parse(Console.ReadLine()) - 1;
                Console.Write("Oszlop:");
                int oszlop = int.Parse(Console.ReadLine()) - 1;
                // ha aknát találtunk akkor vége: vesztett
                if (aknak[sor, oszlop] == 'A') vege = 1;
                // megvizsgáljuk a szomszédait
                int aknadb = 0;
                if (sor!=0 && oszlop!=0)
                    if (aknak[sor - 1, oszlop - 1] == 'A') aknadb++;
                if (sor != 0)
                    if (aknak[sor - 1, oszlop] == 'A') aknadb++;
                if (sor != 0 && oszlop != 4)
                    if (aknak[sor - 1, oszlop + 1] == 'A') aknadb++;
                if (oszlop != 0)
                    if (aknak[sor, oszlop - 1] == 'A') aknadb++;
                if (oszlop != 4)
                    if (aknak[sor, oszlop + 1] == 'A') aknadb++;
                if (sor != 4 && oszlop != 0)
                    if (aknak[sor + 1, oszlop - 1] == 'A') aknadb++;
                if (sor != 4)
                    if (aknak[sor + 1, oszlop] == 'A') aknadb++;
                if (sor != 4 && oszlop != 4)
                    if (aknak[sor + 1, oszlop + 1] == 'A') aknadb++;
                csillagok[sor, oszlop] = Convert.ToChar(aknadb+'0');
                //megszámoljuk hány csillag van a csillagok mátrixban
                int csillagdb = 0;
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (csillagok[i,j] == '*')
                        {
                            csillagdb++;
                        } 
                    }
                }
                // ha csak 5 csillag marad akkor vége: nyert
                if (csillagdb==5)
                {
                    vege = -1;
                }
            }
            if (vege == 1)
                Console.WriteLine("VESZTETT");
            else
                Console.WriteLine("NYERT");
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (aknak[i, j] == 'A')
                        Console.Write('A');
                    else
                        Console.Write(' ');
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
