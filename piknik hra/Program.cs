using System;
using System.Collections.Generic;

namespace ConsoleApp12
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
            lahky.Add("než");
            lahky.Add("neha");
            lahky.Add("žena");
            lahky.Add("anežka");
            lahkyKluc = "N,A,E,Ž,H,K,A";

            //naplnenie druhe
            stredny.Add("tak");
            stredny.Add("kaša");
            stredny.Add("taška");
            stredny.Add("šatka");
            stredny.Add("šaty");
            strednyKluc = "T,K,A,Y,Š";

            //naplnenie tretirho      //matej musi upravit
            tazky.Add("rad");
            tazky.Add("pod");
            tazky.Add("para");
            tazky.Add("opar");
            tazky.Add("poradca");
            tazkyKluc = "R,D,C,A,P,O";




            List<string> uhadnuteCisla = new List<string>();    //list na uhadnute slova
            int pocetZlych = 0;
            int pocetSpravnehoPokusu;
            int skoreLahkaObtiaznost = 0;
            int skoreStrednaObtiaznost = 0;
            int skoreTazkaObtiaznost = 0;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("              >>>>> PIKNIK HRA SPŠIT EDITION <<<<<");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Vítaj v našej hre!!!" + "\n" + "Pre začiatok hry si vyber z následujúcich obtiažností");

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("           Ľahkú obtiažnosť spusti zadaním klávesy L" + "\n" + "           Strednú obtiažnosť spusti zadaním klávesy S" + "\n" + "           Ťažkú obtiažnosť spusti zadaním klávesy T" + "\n");

                string vyber = Console.ReadLine();
                while (vyber == string.Empty)  //cekuje ci je prazdny input
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("nic si nezadal");
                    vyber = Console.ReadLine();
                }

                if (vyber == "L")
                {
                    pocetSpravnehoPokusu = -1;
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("Obtiažnosť, ktorú si zvolil >>> ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("ĽAHKÁ" + "\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Slová skladaj z následujúcich písmen >>> ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write(lahkyKluc + "\n" + "\n");
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Tvoje skóre: 0/5" + "\n");
                    while (true)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("Tvoja odpoveď: ");
                        string input = Console.ReadLine();
                        while (input == string.Empty) //cekuje ci je prazdny input
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("nic si nezadal");
                            input = Console.ReadLine();
                        }

                        if (ocekuvac(input, lahky) == true)
                        {
                            if (ocekuvacUzUhadnutych(input, uhadnuteCisla) == false)
                            {
                                pocetSpravnehoPokusu++;
                                uhadnuteCisla.Insert(pocetSpravnehoPokusu, input);
                                if (pocetSpravnehoPokusu < 4)
                                    Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Správne, pokračuj ;)" + "\n");
                                skoreLahkaObtiaznost++;
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine("Tvoje skóre: " + skoreLahkaObtiaznost + "/5");


                                if (ocekuvacVyslednehoPolaSoSpravnym(lahky, uhadnuteCisla) == true)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Splnil si úlohu! \n");
                                    vymazanieTestovaciehoListu(uhadnuteCisla);
                                    break;
                                }
                            }
                            else

                                Console.WriteLine("\n" + "Toto slovo si už zadal!" + "\n");

                        }

                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Slovo sa nenachádza, skus znova!");
                            pocetZlych++;

                            if (pocetZlych >= 3)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("Prehral si :(... ");
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.Write("\n" + "Skús znova!!!" + "\n" + "\n");
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
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("Obtiažnosť, ktorú si zvolil >>> ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("STREDNÁ" + "\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Slová skladaj z následujúcich písmen >>> ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write(strednyKluc + "\n" + "\n");
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Tvoje skóre: 0/5" + "\n");
                    while (true)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("Tvoja odpoveď: ");
                        string input = Console.ReadLine();
                        while (input == string.Empty)   //cekuje ci je prazdny input
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Nič si nezadal");
                            input = Console.ReadLine();
                        }

                        if (ocekuvac(input, stredny) == true)
                        {
                            if (ocekuvacUzUhadnutych(input, uhadnuteCisla) == false)
                            {
                                pocetSpravnehoPokusu++;
                                uhadnuteCisla.Insert(pocetSpravnehoPokusu, input);
                                if (pocetSpravnehoPokusu < 4)
                                    Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Správne, pokračuj ;)" + "\n");
                                skoreStrednaObtiaznost++;
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine("Tvoje skóre: " + skoreStrednaObtiaznost + "/5");

                                if (ocekuvacVyslednehoPolaSoSpravnym(stredny, uhadnuteCisla) == true)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Splnil si úlohu! \n");
                                    vymazanieTestovaciehoListu(uhadnuteCisla);
                                    break;
                                }
                            }
                            else

                                Console.WriteLine("\n" + "Toto slovo si už zadal!" + "\n");

                        }

                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Slovo sa nenachádza, skús znova!");
                            pocetZlych++;

                            if (pocetZlych >= 3)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Prehral si :(... ");
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.Write("Skús znova!!!" + "\n" + "\n");
                                vymazanieTestovaciehoListu(uhadnuteCisla);
                                break;
                            }
                        }

                    }
                }

                if (vyber == "T")
                {
                    pocetSpravnehoPokusu = -1;
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("Obtiažnosť, ktorú si zvolil >>> ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("ŤAŽKÁ" + "\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Slová skladaj z následujúcich písmen >>> ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write(tazkyKluc + "\n" + "\n");
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Tvoje skóre: 0/5" + "\n");
                    while (true)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("Tvoja odpoveď: ");
                        string input = Console.ReadLine();
                        while (input == string.Empty) //cekuje ci je prazdny input
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("nic si nezadal");
                            input = Console.ReadLine();
                        }

                        if (ocekuvac(input, lahky) == true)
                        {
                            if (ocekuvacUzUhadnutych(input, uhadnuteCisla) == false)
                            {
                                pocetSpravnehoPokusu++;
                                uhadnuteCisla.Insert(pocetSpravnehoPokusu, input);
                                if (pocetSpravnehoPokusu < 4)
                                    Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Správne, pokračuj ;)" + "\n");
                                skoreTazkaObtiaznost++;
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine("Tvoje skóre: " + skoreTazkaObtiaznost + "/5");


                                if (ocekuvacVyslednehoPolaSoSpravnym(lahky, uhadnuteCisla) == true)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Splnil si úlohu! \n");
                                    vymazanieTestovaciehoListu(uhadnuteCisla);
                                    break;
                                }
                            }
                            else

                                Console.WriteLine("\n" + "Toto slovo si už zadal!" + "\n");

                        }

                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Slovo sa nenachádza, skús znova!");
                            pocetZlych++;

                            if (pocetZlych >= 3)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("Prehral si :(... ");
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.Write("\n" + "Skús znova!!!" + "\n" + "\n");
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

