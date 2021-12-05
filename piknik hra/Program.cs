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

            /*v maine RICHARD spravi to ze ked  typek pride do programu
             * tak zada svoje meno. Potom dostane 4 moznosti: koniec, alebo jednu z troch obtiaznosti.
             * moznosti bude dostavat zakazdym ked sa skonci jedna moznost. 
             * pre pochopenie: vyberie moznost lahke, typek bude hrat atd atd a ked skonci 
             * je jedno ci vyhra alebo prehra dostane na vyber ci chce pokracovat alebo
             * skoncit. 
             */


            
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
