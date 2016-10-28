using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodersStrikeBack
{
    public class Pod
    {
        public Position p;
        public Position des;
        public int acc;
        public int shield= 5 ;
        public CheckP nextC;
        public CheckP nNextC;
        public Speed speed;
        public int ang = 0;
        public bool inPosition = false;
        public bool gettingInPos = false;
        int prog = 0;
        public CheckP target; 
        public bool direct = false  ;
        public int testGlid = 5;
        public bool isFirst = false;
        public bool kickStart = false ;
        public bool goKick = false;
        
       
        public Pod(int x , int y)
        {
            p = new Position(x,y);
   
        }

        public int gettingThere(Position p1){
            double x = p1.x - p.x, y = p1.y - p.y;
            var k =  (x * this.speed.x + y * this.speed.y);
           
            k = k / ( Math.Sqrt(x*x + y*y) * Math.Sqrt(speed.x*speed.x + speed.y*speed.y) ) ;
   
            return (int)( Math.Acos(k) * 180.0 / Math.PI) ;

        }
        public void SetC(CheckP c)
        {
            if (this.nextC == null || this.nextC.num != c.num)
            {
                nextC = c;
                nNextC = Game.checkPs.ElementAt((c.num + 1) % Game.checkPs.Count()); 
                prog++;
                if (nextC.num == 1 && isFirst ) Game.tlap-- ; 

                if(prog>1)kickStart = true;
            }
        }

        public bool colide(Pod po)
        {
            Position p1 = new Position(this.p.x + this.speed.x, this.p.y + this.speed.y);
            Position p2 = new Position(po.p.x + po.speed.x, po.p.y + po.speed.y);

            return p1.getDistance(p2) < 850;  

        }

        public Position getNext()
        {
            return new Position(p.x + speed.x, p.y + speed.y); 
        }
       

        public void SetP(int x, int y)
        {
            p.x = x;
            p.y = y; 
        }

        public void Action(int type)
        {
            if (type == 0)
            {
                isFirst = true;
            }
            String pr = nextC.p.x + " " + nextC.p.y;
            String act = "";
            int dis = this.p.getDistance(nextC.p);
            var targAng = gettingThere(nextC.p); 
            var speed = (gettingThere(nextC.p) / 180.0); 

            switch (type)
            {   
                    // Racer
                case 0 :
                    Console.Error.WriteLine("Speed id " + this.speed.getSpeed());

                    int turn = (this.speed.getSpeed() / 80);
                    turn = Math.Min(turn, 4);
                    if (this.testGlide(nextC.p, turn, 600) && gettingThere(nNextC.p) > 90 && (Game.tlap > 0 || nextC.num != 0 )  )
                    {
                        pr = nNextC.p.x + " " + nNextC.p.y;
                        act = this.testGlide(nextC.p, 1, 450)?"50":"1";
                        Console.Error.WriteLine("GLIDING !!");
                    }
                    else
                    {
                    
                      
                     int print = (int) (200 - speed*200);
                  

                     
                     if (targAng > 120 && dis < 1500)
                     {
                         print = 5 ;
                         Console.Error.WriteLine(" POSITIONING");
                     }
                     else if (targAng > 18 && getNext().getDistance(nextC.p) < 3000)
                     {
                         print = print / 2;
                         Console.Error.WriteLine("BRAKING /2");
                     }
                     
                      
                     
                     act = print + ""; 
                    }
                    if (Pods.HitEn(this) || Pods.meP.ElementAt(1).getNext().equal(getNext() , 800)  && shield <= 0  )
                    {
                        shield = 5;
                        act = "SHIELD";
                    }
                    else
                    {
                        shield -- ; 
                    }
                    act = (kickStart)? act + " KICK ME" : act;
                    Console.WriteLine(pr + " "+act);
                    break; 
                    // BLOCKER 
                case 1 :
                     
                     Pod en ;
                     en = (Pods.enP.ElementAt(0).prog > Pods.enP.ElementAt(1).prog ||( Pods.enP.ElementAt(0).prog == Pods.enP.ElementAt(1).prog && Pods.enP.ElementAt(0).p.getDistance(this.p) < Pods.enP.ElementAt(1).p.getDistance(this.p))) ? Pods.enP.ElementAt(0) : Pods.enP.ElementAt(1);
                     Pod frd =Pods.meP.ElementAt(0) ;
                     if (goKick == true && frd.kickStart && p.getDistance(frd.p) < 1500 && Game.getNext(target.num).num == frd.nextC.num && p.getDistance(target.p) > 400) 
                     {
                         pr = frd.p.x + " " + frd.p.y;
                         act = ""+200;
                     }
                     else
                     {
                         if (!gettingInPos)
                         {
                             target = Game.checkPs.ElementAt((en.nextC.num + 2) % Game.checkPs.Count);
                             gettingInPos = true;
                         }


                         // Ready to Attack 
                         if (en.nextC.num == target.num && en.getNext().getDistance(this.p) < 5000)
                         {
                             if (!en.getNext().equal(getNext(), 900))
                             {    // ATTACK !! 
                                 act = 200 + "";
                                 pr = en.getNext().x + " " + en.getNext().y;

                             }
                             else
                             {
                                 act = "SHIELD";
                                 pr = en.p.x + " " + en.p.y;

                             }

                         }
                         else
                         {

                             if (this.testGlide(Game.getNext(target.num).p.getOuter(target.p.x, target.p.y, 400), 4 , 600))
                             {
                                 act = " 1";
                                 pr = en.p.x + " " + en.p.y;
                                 goKick = true;
                             }
                             else
                             {
                                 if (this.p.equal(target.p, 2000))
                                 {
                                     act = "10";
                                 }
                                 else
                                 {
                                     act = "90";
                                 }


                                 pr = target.p.x + " " + target.p.y;
                             }




                         }
                     }
                     if (frd.kickStart && getNext().equal(frd.getNext(), 800))
                     {
                        // act = "SHIELD GO GO ";
                         frd.kickStart = false;
                         goKick = false;
                     }    
                     if (Pods.HitEn(this)){
                         act = "SHIELD ATTACK!";
                         goKick = false ;
                     };   
                     Console.WriteLine(pr + " " + act);
                     if (((target.num + 1) % Game.checkPs.Count) == en.nextC.num)
                     {
                         gettingInPos = false;
                         direct = false;
                     } 

                    break; 
            }
                
        }
    }
}
