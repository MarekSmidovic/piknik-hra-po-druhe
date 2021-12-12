using System;
using System.Collections.Generic;

namespace piknik_hra
{
    class Program
    {


        /*tu MATEJ naplni vsetky tri listy (lahky, stredny, tazky) slovami
         * kluce budu static a budu sa volat nasledovne
         * (k listu lahky bude kluc lahkyKluc)
         * 
         * ten kluc moze byt v poriadku ako string a nie ako pole charov kedze mi ho v programe
         * vobec nevyuzijeme a ani nepotrebujeme, sluzi len pre toho co to hra
         * aby vedel z coho ma skladat
         */
        static List<string> lahky = new List<string>();

        static string lahkyKluc = String.Empty;



        static List<string> stredny = new List<string>();

        static string strednyKluc = String.Empty;



        static List<string> tazky = new List<string>();

        static string tazkyKluc = String.Empty;




        static void Main(string[] args)
        {
            //naplnenie prveho listu

            

            lahky.Add("na");
            lahky.Add("nez");
            lahky.Add("neha");
            lahky.Add("zena");
            lahky.Add("anezka");
            
            List<string> uhadnuteCisla = new List<string>();
            int pocetZlych = 0;
            int pocetSpravnehoPokusu = -1;

            while (true)
            {
                string input = Console.ReadLine();

                if (ocekuvac(input, lahky) == true)
                {
                    if (ocekuvacUzUhadnutych(input, uhadnuteCisla) == false)
                    {
                        pocetSpravnehoPokusu++;
                        uhadnuteCisla.Insert(pocetSpravnehoPokusu, input);
                        Console.WriteLine("spravne, pokracuj");

                        if (ocekuvacVyslednehoPolaSoSpravnym(lahky, uhadnuteCisla) == true)
                        {
                            Console.WriteLine("splnil si ulohu!");
                            break;
                        }


                    }
                    else
                    {
                        Console.WriteLine("toto slovo si uz zadal!");
                    }
                }

                else
                {
                    Console.WriteLine("slovo sa nenachadza");
                    pocetZlych++;

                    if (pocetZlych >= 3)
                    {
                        Console.WriteLine("prehral si:(");
                        break;
                    }
                }

            }

        }

        //testuje input s listom
        static bool ocekuvac(string input, List<string> lahky)
        {
            bool jjnn = false;

            for (int i = 0; i < lahky.Count; i++)
            {
                if (input == lahky[i])
                {
                    jjnn = true;
                }
            }
            return jjnn;

        }
        

        //testuje ci hrac nezadal spravne slovo dva krat
        static bool ocekuvacUzUhadnutych(string input, List<string> uhadnuteCisla)
        {
            bool jjnn = false;

            for (int i = 0; i < uhadnuteCisla.Count; i++)
            {
                if (input == uhadnuteCisla[i])
                {
                    jjnn = true;
                }
            }
            return jjnn;
        }


        //testuje ci su uhadnute vsetky slova
        static bool ocekuvacVyslednehoPolaSoSpravnym(List<string> lahky, List<string> uhadnuteCisla)
        {
            int pocetSpravnych = 0;
            for (int i = 0; i < lahky.Count; i++)
            {
                for (int j = 0; j < uhadnuteCisla.Count; j++)
                {
                    if (lahky[i] == uhadnuteCisla[j])
                        pocetSpravnych++;
                }
            }

            if (pocetSpravnych == 5)
                return true;
            else
                return false;
        }

    }





}

