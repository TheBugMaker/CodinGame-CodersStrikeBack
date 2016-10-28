using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodersStrikeBack
{
   
    class Player
    {
        static void Main(string[] args)
        {
             
            #region init
            string[] inputs;
            int laps = int.Parse(Console.ReadLine());
            
            Game.tlap= (laps);
            Pods ps = new Pods();

            int checkpointCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < checkpointCount; i++)
            {
                inputs = Console.ReadLine().Split(' ');
                int checkpointX = int.Parse(inputs[0]);
                int checkpointY = int.Parse(inputs[1]);
                
                Game.checkPs.Add(new CheckP(i, checkpointX, checkpointY)); 
            }
            ps.checkPs = Game.checkPs; 
        #endregion

            // game loop
            while (true)
            {
                Console.Error.WriteLine(Game.tlap);
                #region setUp
                for (int i = 0; i < 2; i++)
                {
                    inputs = Console.ReadLine().Split(' ');
                    int x = int.Parse(inputs[0]);
                    int y = int.Parse(inputs[1]);

                    ps.SetP(i, x, y); 

                    int vx = int.Parse(inputs[2]);
                    int vy = int.Parse(inputs[3]);

                    ps.getP(i).speed = new Speed(vx,vy);

                    int angle = int.Parse(inputs[4]);

                    ps.getP(i).ang = Math.Max(0,angle); 

                    int nextCheckPointId = int.Parse(inputs[5]);

                    ps.getP(i).SetC( Game.checkPs.ElementAt(nextCheckPointId) ); 

                }
                for (int i = 0; i < 2; i++)
                {
                    inputs = Console.ReadLine().Split(' ');
                    int x = int.Parse(inputs[0]);
                    int y = int.Parse(inputs[1]);

                    ps.SetP(i+2, x, y);

                    int vx = int.Parse(inputs[2]);
                    int vy = int.Parse(inputs[3]);

                    ps.getP(i+2).speed = new Speed(vx, vy);

                    int angle = int.Parse(inputs[4]);

                    ps.getP(i+2).ang = angle;

                    int nextCheckPointId = int.Parse(inputs[5]);

                    ps.getP(i+2).SetC( Game.checkPs.ElementAt(nextCheckPointId) ) ;

                }
            #endregion

                // To debug: Console.Error.WriteLine("Debug messages...");
                // using 
                // using 16516 
                Pods.meP.ElementAt(0).Action(0);
                Pods.meP.ElementAt(1).Action(1); 
            }
        }
    }
}
