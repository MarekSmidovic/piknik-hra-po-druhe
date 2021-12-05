using System;
using System.Collections.Generic;

namespace piknik_hra
{
    class Program
    {


        /*tu MATEJ naplni vsetky tri stringy (lahky, stredny, tazky) slovami
         * zatial bez kluca, tj. slov z ktorych ma skladat slova
         */
        static List<string> lahky = new List<string>();


        static List<string> stredny = new List<string>();


        static List<string> tazky = new List<string>();


        static void Main(string[] args)
        {

            
        }

        //funkcia na testovanie ci je input totozny s hladanym slovom
        static bool porovnanieInputS(string input, List<string> ks)
        {
            bool aa = false;
            for (int i = 0; i < ks.Count; i++)
            {
                if (input == ks[i])
                {
                    aa = true;
                }
            }
            return aa;
        }
    }
}
