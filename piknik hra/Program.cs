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
        static List<string> codeList = new List<string>();
        static string codeKluc = String.Empty;

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

            //naplnenie tretirho    
            tazky.Add("rad");
            tazky.Add("pod");
            tazky.Add("para");
            tazky.Add("opar");
            tazky.Add("poradca");
            tazkyKluc = "R,D,C,A,P,O";



            List<string> uhadnuteCisla = new List<string>();    //list na uhadnute slova
            List<string> codeList = new List<string>();
            int pocetZlych = 0;
            int pocetSpravnehoPokusu;
            
            while (true)
            {
                pocetSpravnehoPokusu = -1;

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("          >>>>> PIKNIK HRA SPŠIT EDITION <<<<<");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Vitaj v našej hre!!!" + "\n" + "Pre hrenie hry si vyber z následujúcich obtiažností");


                string vyber = Console.ReadLine();
                while (vyber == string.Empty)  //cekuje ci je prazdny input
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("nic si nezadal");
                    vyber = Console.ReadLine();
                }

                if (vyber == "L")
                {
                    prepisListov(lahky, codeList);
                    codeKluc = lahkyKluc;
                }
                else if (vyber == "S")
                {
                    prepisListov(stredny, codeList);
                    codeKluc = strednyKluc;
                }
                else if (vyber == "T")
                {
                    prepisListov(tazky, codeList);
                    codeKluc = tazkyKluc;
                }
                else if (vyber == "K")
                {
                    Console.WriteLine("Pre potvrdenie stlac ENTER");
                    string enterInput = Console.ReadLine();
                    if (enterInput == String.Empty)
                    {
                        break;
                    }
                }

                Console.Write("Slová skladaj z následujúcich písmen >>> ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(codeKluc + "\n" + "\n");

                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Tvoja odpoveď: ");
                    string input = Console.ReadLine();
                    while (input == string.Empty) //cekuje ci je prazdny input
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("nic si nezadal");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("Tvoja odpoveď: ");
                        input = Console.ReadLine();
                    }

                    if (ocekuvac(input, codeList) == true)
                    {
                        if (ocekuvacUzUhadnutych(input, uhadnuteCisla) == false)
                        {
                            pocetSpravnehoPokusu++;
                            uhadnuteCisla.Insert(pocetSpravnehoPokusu, input);
                            if (pocetSpravnehoPokusu < 4)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Správne, pokračuj ;)" + "\n");
                            }
                            

                            if (ocekuvacVyslednehoPolaSoSpravnym(codeList, uhadnuteCisla) == true)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Splnil si úlohu! Stlač ENTER  \n");
                                vymazanieTestovaciehoListu(uhadnuteCisla);
                                Console.ReadLine();
                                Console.Clear();
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
                            Console.Write("\n" + "Stlač ENTER" + "\n" + "\n");
                            if (uhadnuteCisla.Count != 0)
                                vymazanieTestovaciehoListu(uhadnuteCisla);
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }
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

        //vymazanie listu po skonceni
        static void vymazanieTestovaciehoListu(List<string> list)
        {
            for (int i = 0; i <= 4; i++)
            {
                list.RemoveAt(0);
            }
        }
        //prepisanie true listu do code listu
        static void prepisListov(List<string> trueList, List<string> codeList)
        {
            for (int i = 0; i < trueList.Count; i++)
            {
                codeList.Add(trueList[i]);
            }
        }
    }

}

