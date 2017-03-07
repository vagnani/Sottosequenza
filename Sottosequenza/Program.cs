using System;
using System.Collections.Generic;
using System.Linq;

namespace sottosequanza
{
    class main
    {
        static List<int> list=new List<int>();
        static List<List<int>> all=new List<List<int>>();

        static void Main()
        {
            bool crescente = true;
            Console.WriteLine("Risoluzione massima sottosequanza");
            Console.Write("crescente o decrescente?");
            if (Console.ReadLine()[0] == 'd')
                crescente = false;
            Console.WriteLine();

            do
            {
                Console.Write("inserisci valore (! ferma) -->");
                string t = Console.ReadLine();
                if (t != "!")
                    list.Add(Convert.ToInt32(t));
                else
                    break;
            } while (true);

            //trova tutte le sottosequenze
            if (!crescente)
                list.Reverse();
            for (int i = 0; i < list.Count - 1; i++)
            {
                all.Add(new List<int>() { list[i] });
                AllCrescenti(i, all.Count() - 1);
            }


            //filtra
            List<List<int>> sequence = new List<List<int>>();
            int countmax = 0;
            foreach(var item in all)
            {
                if (item.Count > countmax)
                { sequence = new List<List<int>>() { item }; countmax = item.Count; }
                else if (item.Count() == countmax)
                    sequence.Add(item);
            }

            //stampa
            Console.WriteLine();
            foreach(var item in sequence)
            {
                item.Reverse();
                foreach(var value in item)
                {
                    Console.Write(value + " - ");
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }

        private static void AllCrescenti(int indcurrelem, int indcurrlist)
        {
            List<int> ind_higher = new List<int>();
            List<int> currlist = new List<int>(all[indcurrlist]);

            for(int i=indcurrelem+1;i<list.Count();i++)
            {
                if (list[i] > list[indcurrelem])
                    ind_higher.Add(i);
            }

            if (ind_higher.Count() > 0)
            {
                foreach (var item in ind_higher)
                {
                    List<int> tlist = new List<int>(currlist);
                    tlist.Add(list[item]);
                    all.Add(tlist);
                    AllCrescenti(item, all.Count() - 1);
                }
            }
        }        
    }
}