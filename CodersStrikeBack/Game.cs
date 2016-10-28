using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodersStrikeBack
{
   public  class Game
    {
        public static  int tlap ;
        public  static int lapCount;
        public static  List<CheckP> checkPs = new List<CheckP>();
        public static  CheckP getNext(int num)
        {
            return checkPs.ElementAt((num + 1) % checkPs.Count() ); 
        }  

    }
}
