using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSDLogic
{
    internal class CrossCollisionDetector : CollisionDetector, ICollisionDetector
    {
        public CrossCollisionDetector(BallCollection ballCollection) : base(ballCollection) { }
        private double CenterSquaredDistance(Ball b1, Ball b2)
        {
            double dx = b1.Location.Item1 - b2.Location.Item1;
            double dy = b1.Location.Item2 - b2.Location.Item2;
            return dx * dx + dy * dy;
        }
        


        public override async Task DetectAndResolve()
        {
            //Debug.WriteLine("OK");
            await Task.Run(() =>
            {
                Parallel.For(0, base.ballCollection.Count() - 1, (i) =>
                {
                    Monitor.Enter(ballCollection[i]);
                    Ball b1 = base.ballCollection[i];
                    for (int j = i + 1; j < base.ballCollection.Count(); j++)
                    {
                        Monitor.Enter(ballCollection[j]);
                        Ball b2 = base.ballCollection[j];
                        double radiiSum = b1.Radius + b2.Radius;
                        if (CenterSquaredDistance(b1, b2) < radiiSum * radiiSum)
                        {
                            base.OnCollisionDetected(this, new CollisionDetectedEventArgs(b1, b2));
                            ElasticCollisionPhysics.BallCollision(ref b1, ref b2);
                            //b1.Color = "red";
                        }
                        Monitor.Exit(ballCollection[j]);
                    }
                    Monitor.Exit(ballCollection[i]);
                    
                });
            });
            /*for(int i=0; i<base.ballCollection.Count()-1; i++)
            {
                for(int j=i+1; j<base.ballCollection.Count(); j++)
                {
                    Ball b1 = base.ballCollection[i];
                    Ball b2 = base.ballCollection[j];
                    double radiiSum = b1.Radius + b2.Radius;
                    if (CenterSquaredDistance(b1, b2) < radiiSum * radiiSum)
                    {
                        ElasticCollisionPhysics.BallCollision(ref b1, ref b2);
                        //b1.Color = "red";
                    }
                }
            }*/
        }


    }
}
