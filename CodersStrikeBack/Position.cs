using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodersStrikeBack
{
    public class Position
    {
        public int x;
        public int y;

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y; 
        }

        public double getAngle(Position p){
            long x = p.x - this.x , y = p.y-this.y;
            double ang =  Math.Acos( y / Math.Sqrt(x*x+y*y)) * 180 / Math.PI;
            if(y>0) ang = 360 - ang;
            return ang;
        }

        public int getDistance(Position p)
        {
            int x = this.x - p.x;
            int y = this.y - p.y;
            return  (int)(Math.Sqrt(x * x + y * y));  

        }

        public bool equal(Position k)
        {
            return this.x == k.x && this.y == k.y; 
        }

        public bool equal(Position k, int marg)
        {
            return Math.Abs(this.x - k.x) < marg && Math.Abs(this.y - k.y) < marg; 
        }

        public Position getOuter( int margin, int x, int y)
        {
            var k = this;
            int nx = k.x;
            int ny = k.y; 
            if ( k.x > x)
            {
                nx -= margin;
            }
            else
            {
                nx += margin;
            }

            if (k.y > y)
            {
                ny -= margin;
            }
            else
            {
                ny += margin; 
            }
            return new Position(nx, ny);
        }
    }
}
