using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace ConsoleApp12
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath1 = @"E:\piknikHra\lahkaObtiaznost.txt";
            List<string> lahky = File.ReadAllLines(filePath1).ToList();
            string lahkyKluc = "K,E,Y,D,D,O,R,V";

            string filePath2 = @"E:\piknikHra\strednaObtiaznost.txt";
            List<string> stredny = File.ReadAllLines(filePath2).ToList();
            string strednyKluc = "T,K,A,Y,Š";

            string filePath3 = @"E:\piknikHra\tazkaObtiaznost.txt";
            List<string> tazky = File.ReadAllLines(filePath3).ToList();
            string tazkyKluc = "N,O,E,S,B,P,R";

            List<string> codeList = new List<string>();
            string codeKluc = String.Empty;

            List<string> uhadnuteCisla = new List<string>();    //list na uhadnute slova
            int pocetZlych = 0;


            while (true)
            {
                int pocetSpravnehoPokusu = -1;

                string nadpis = ">>>PIKNIK HRA<<<";
                Console.SetCursorPosition((Console.WindowWidth - nadpis.Length) / 2, Console.CursorTop);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(nadpis, "\n");
                Console.WriteLine(""); Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Pre vrátenie sa k výberu možností napíš: back");
                Console.WriteLine("Pre ukončenie hry stlač klávesu: K \n");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Ľahkú obtiažnosť spusti zadaním klávesy L");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Strednú obtiažnosť spusti zadaním klávesy S");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ťažkú obtiažnosť spusti zadaním klávesy T" + "\n");
                Console.ForegroundColor = ConsoleColor.White;

                Console.Write("Tvoj výber: ");
                string vyber = Console.ReadLine();
                while (vyber == string.Empty)  //cekuje ci je prazdny input
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nič si nezadal");
                    vyber = Console.ReadLine();
                }

                if (vyber == "L")
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Obtiažnosť, ktorú si zvolil >>> ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("ĽAHKÁ" + "\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    prepisListov(lahky, codeList);
                    codeKluc = lahkyKluc;
                }
                else if (vyber == "S")
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Obtiažnosť, ktorú si zvolil >>> ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("STREDNÁ" + "\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    prepisListov(stredny, codeList);
                    codeKluc = strednyKluc;
                }
                else if (vyber == "T")
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Obtiažnosť, ktorú si zvolil >>> ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("ŤAŽKÁ" + "\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    prepisListov(tazky, codeList);
                    codeKluc = tazkyKluc;
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

                    if (input == "back")
                    {
                        Console.Clear();
                        break;
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
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Splnil si úlohu! Stlač ENTER  \n");
                                pocetSpravnehoPokusu = -1;
                                vymazanieListu(uhadnuteCisla);
                                vymazanieListu(codeList);
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
                            pocetZlych = 0;
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("\n" + "Stlač ENTER" + "\n" + "\n");
                            vymazanieListu(codeList);
                            if (uhadnuteCisla.Count != 0)
                                vymazanieListu(uhadnuteCisla);
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
        static void vymazanieListu(List<string> list)
        {
            for (int i = list.Count - 1; i >= 0; i--)
            {
                list.RemoveAt(i);
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

