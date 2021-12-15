using System;
using System.Collections.Generic;

namespace piknik_hra
{
    class Program
    {

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
            lahkyKluc = "N,A,E,Ž,H,K,A";

            //naplnenie druhe
            stredny.Add("tak");
            stredny.Add("kasa");
            stredny.Add("taska");
            stredny.Add("satka");
            stredny.Add("saty");
            strednyKluc = "T,A,K,Š,Y";

            //naplnenie tretirho      //matej musi upravit
            tazky.Add("rad");
            tazky.Add("cop");
            tazky.Add("pod");
            tazky.Add("para");
            tazky.Add("opar");
            tazky.Add("poradca");
            tazkyKluc = "R,D,C,A";


            List<string> uhadnuteCisla = new List<string>();    //list na uhadnute slova
            int pocetZlych = 0;
            int pocetSpravnehoPokusu;


            while (true)
            {
                Console.WriteLine("vyber si obtaiznost (L/S/T)");
                string vyber = Console.ReadLine();
                while (vyber == string.Empty)  //cekuje ci je prazdny input
                {
                    Console.WriteLine("nic si nezadal");
                    vyber = Console.ReadLine();
                }

                if (vyber == "L")
                {
                    pocetSpravnehoPokusu = -1;
                    Console.WriteLine("vybral si si lahku obtiaznost");
                    Console.WriteLine("Pismena z ktorych skladas: " + lahkyKluc + "\n");
                    while (true)
                    {
                        Console.Write("tvoja odpoved: ");
                        string input = Console.ReadLine();
                        while (input == string.Empty) //cekuje ci je prazdny input
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
                                if(pocetSpravnehoPokusu < 4)
                                   Console.WriteLine("spravne, pokracuj");

                                if (ocekuvacVyslednehoPolaSoSpravnym(lahky, uhadnuteCisla) == true)
                                {                                    
                                    Console.WriteLine("splnil si ulohu! \n");
                                    vymazanieTestovaciehoListu(uhadnuteCisla);
                                    break;
                                }
                            }
                            else
                                Console.WriteLine("toto slovo si uz zadal!");

                        }

                        else
                        {
                            Console.WriteLine("slovo sa nenachadza");
                            pocetZlych++;

                            if (pocetZlych >= 3)
                            {
                                Console.WriteLine("prehral si:(");
                                vymazanieTestovaciehoListu(uhadnuteCisla);
                                break;
                            }
                        }

                    }

                }


                //toto je stredna obtiaznost
                if (vyber == "S")
                {
                    pocetSpravnehoPokusu = -1;
                    Console.WriteLine("vybral si si strednu obtiaznost");
                    Console.WriteLine("Pismena z ktorych skladas: " + strednyKluc + "\n");
                    while (true)
                    {
                        Console.Write("tvoja odpoved: ");
                        string input = Console.ReadLine();
                        while (input == string.Empty)   //cekuje ci je prazdny input
                        {
                            Console.WriteLine("nic si nezadal");
                            input = Console.ReadLine();
                        }

                        if (ocekuvac(input, stredny) == true)
                        {
                            if (ocekuvacUzUhadnutych(input, uhadnuteCisla) == false)
                            {
                                pocetSpravnehoPokusu++;
                                uhadnuteCisla.Insert(pocetSpravnehoPokusu, input);
                                if(pocetSpravnehoPokusu < 4)
                                Console.WriteLine("spravne, pokracuj");

                                if (ocekuvacVyslednehoPolaSoSpravnym(stredny, uhadnuteCisla) == true)
                                {
                                    Console.WriteLine("splnil si ulohu! \n");
                                    vymazanieTestovaciehoListu(uhadnuteCisla);
                                    break;
                                }
                            }
                            else
                                Console.WriteLine("toto slovo si uz zadal!");
                        
                        }

                        else
                        {
                            Console.WriteLine("slovo sa nenachadza");
                            pocetZlych++;

                            if (pocetZlych >= 3)
                            {
                                Console.WriteLine("prehral si:(");
                                vymazanieTestovaciehoListu(uhadnuteCisla);
                                break;
                            }
                        }

                    }
                }

                else if (vyber == "M")
                {
                    Console.WriteLine("");
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

        //vymazanie listu po skonceni
        static void vymazanieTestovaciehoListu(List<string> list)
        {
            for (int i = 0; i <= 4; i++)
            {
                list.RemoveAt(0);
            }
        }
    }





}

