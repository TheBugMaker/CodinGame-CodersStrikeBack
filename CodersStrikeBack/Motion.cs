using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodersStrikeBack
{
    public static class Motion
    {
      

        public static bool testGlide(this Pod p, Position z , int turnsStop , int range)
        {
            double xs = p.speed.x , ys =  p.speed.y ;   
            double x = p.p.x , y = p.p.y ;


            if (turnsStop == 0) return false;
              for (int i = 0; i < turnsStop; i++)
			    {   
                     x+=xs ; y+=ys ;   
			         xs = xs * 0.85 ; ys = ys *0.85  ;    
			    }  
                if(new Position((int)x,(int)y).equal(z , range)){
                    return true  ; 
              
                }

                return false;
        }

     

    }
}
