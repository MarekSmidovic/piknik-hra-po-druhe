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

            //naplnenie druhe
            stredny.Add("tak");
            stredny.Add("kasa");
            stredny.Add("taska");
            stredny.Add("satka");
            stredny.Add("saty");

            //naplnenie tretirho
            tazky.Add("rad");
            tazky.Add("cop");
            tazky.Add("pod");
            tazky.Add("para");
            tazky.Add("opar");
            tazky.Add("poradca");


            List<string> uhadnuteCisla = new List<string>();    //list na uhadnute slova
            int pocetZlych = 0;
            int pocetSpravnehoPokusu = -1;


            while (true)
            {
                Console.WriteLine("vyber si obtaiznost (L/S/T)");
                string vyber = Console.ReadLine();
                while (vyber == string.Empty)                        //cekuje ci je prazdny input
                {
                    Console.WriteLine("nic si nezadal");
                    vyber = Console.ReadLine();
                }

                if (vyber == "L")
                {
                    while (true)
                    {

                        string input = Console.ReadLine();
                        while (input == string.Empty)                        //cekuje ci je prazdny input
                        {
                            Console.WriteLine("nic si nezadal");
                            input = Console.ReadLine();
                        }

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



                    //toto je stredna obtiaznost
                    if (vyber == "S")
                    {
                        while (true)
                        {

                            string input = Console.ReadLine();
                            while (input == string.Empty)                        //cekuje ci je prazdny input
                            {
                                Console.WriteLine("nic si nezadal");
                                input = Console.ReadLine();
                            }

                            if (ocekuvacStredny(input, stredny) == true)
                            {
                                if (ocekuvacUzUhadnutych(input, uhadnuteCisla) == false)
                                {
                                    pocetSpravnehoPokusu++;
                                    uhadnuteCisla.Insert(pocetSpravnehoPokusu, input);
                                    Console.WriteLine("spravne, pokracuj");

                                    if (ocekuvacVyslednehoPolaSoSpravnymStredny(stredny, uhadnuteCisla) == true)
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




                    else if (vyber == "M")
                    {
                        Console.WriteLine("");
                    }
                    else
                        break;
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

        //testuje input s listom STREDNA OBTIAZNOST
        static bool ocekuvacStredny(string input, List<string> stredny)
        {
            bool jjnn = false;

            for (int i = 0; i < stredny.Count; i++)
            {
                if (input == stredny[i])
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


        //testuje su uhadnute vsetky slova STREDNA OBTIAZNOST
        static bool ocekuvacVyslednehoPolaSoSpravnymStredny(List<string> stredny, List<string> uhadnuteCisla)
        {
            int pocetSpravnych = 0;
            for (int i = 0; i < stredny.Count; i++)
            {
                for (int j = 0; j < uhadnuteCisla.Count; j++)
                {
                    if (stredny[i] == uhadnuteCisla[j])
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

