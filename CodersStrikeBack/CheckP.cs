using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodersStrikeBack
{
    public class CheckP
    {
        public Position p;
        public int num;
        public CheckP(int num , int x , int y)
        {
            this.num = num;
            this.p = new Position(x, y);
        }
    }
}
