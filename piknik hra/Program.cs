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







            int[] cisla = { 1, 2, 3, 4, 5 };
            int[] uhadnuteCisla = new int[5];
            int pocetZlych = 0;
            int pocetSpravnehoPokusu = -1;

            while (true)
            {
                int input = int.Parse(Console.ReadLine());

                if (ocekuvac(input, cisla) == true)
                {
                    if (ocekuvacUzUhadnutych(input, uhadnuteCisla) == false)
                    {
                        pocetSpravnehoPokusu++;
                        uhadnuteCisla[pocetSpravnehoPokusu] = input;
                        Console.WriteLine("spravne, pokracuj");

                        if (ocekuvacVyslednehoPolaSoSpravnym(cisla, uhadnuteCisla) == true)
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
                    Console.WriteLine("cislo sa nenachadza");
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
        static bool ocekuvac(int input, int[] cisla)
        {
            bool jjnn = false;

            for (int i = 0; i < cisla.Length; i++)
            {
                if (input == cisla[i])
                {
                    jjnn = true;
                }
            }
            return jjnn;

        }

        //testuje ci hrac nezadal spravne slovo dva krat
        static bool ocekuvacUzUhadnutych(int input, int[] uhadnuteCisla)
        {
            bool jjnn = false;

            for (int i = 0; i < uhadnuteCisla.Length; i++)
            {
                if (input == uhadnuteCisla[i])
                {
                    jjnn = true;
                }
            }
            return jjnn;
        }


        //testuje ci su uhadnute vsetky slova
        static bool ocekuvacVyslednehoPolaSoSpravnym(int[] cisla, int[] uhadnuteCisla)
        {
            int pocetSpravnych = 0;
            for (int i = 0; i < cisla.Length; i++)
            {
                for (int j = 0; j < uhadnuteCisla.Length; j++)
                {
                    if (cisla[i] == uhadnuteCisla[j])
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

