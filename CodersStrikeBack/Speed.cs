using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodersStrikeBack
{
    public class Speed
    {
        public int x ;
        public int y;
        public Speed(int x, int y)
        {
            this.x = x;
            this.y = y; 
        }

        public void applyFric(){
            this.x = (int) (x*0.85) ; 
            this.y = (int) (y*0.85) ; 
        }

        public int getSpeed()
        {
            return (int)Math.Sqrt(x * x + y * y); 
        }
    }
}
