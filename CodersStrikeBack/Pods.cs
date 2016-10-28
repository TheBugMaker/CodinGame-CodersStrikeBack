using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodersStrikeBack
{
    public class Pods
    {
        public static  List<Pod> meP = new List<Pod>(2);
        public static List<Pod> enP = new List<Pod>(2);
        public List<CheckP> checkPs; 

        public Pods()
        {
            meP.Add(new Pod(0, 0));
            meP.Add(new Pod(0, 0));
            enP.Add(new Pod(0, 0));
            enP.Add(new Pod(0, 0));
        }

        public void SetP(int i  , int x, int y){
            if (i < 2)
            {
                meP.ElementAt<Pod>(i).SetP(x, y);
            }
            else
            {
                enP.ElementAt<Pod>(i-2).SetP(x, y); 
            }
        }

        public Pod getP(int i)
        {
            if (i < 2)
            {
                return meP.ElementAt<Pod>(i);
            }
            else
            {
                return enP.ElementAt<Pod>(i-2);
            }
        }

        public static bool HitEn(Pod p)
        {
            foreach (var q in enP)
            {
                if (p.getNext().equal(q.getNext() , 850)) return true; 
            }
            return false;
        }
    }
}
