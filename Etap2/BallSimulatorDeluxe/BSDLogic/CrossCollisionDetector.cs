using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSDLogic
{
    internal class CrossCollisionDetector : ICollisionDetector
    {
        private BallCollection ballCollection;
        public CrossCollisionDetector(BallCollection ballCollection)
        {
            this.ballCollection = ballCollection;
        }
        private double CenterSquaredDistance(Ball b1, Ball b2)
        {
            double dx = b1.Location.Item1 - b2.Location.Item1;
            double dy = b1.Location.Item2 - b2.Location.Item2;
            return dx * dx + dy * dy;
        }
        public void DetectAndResolve()
        {
            for(int i=0; i<this.ballCollection.Count()-1; i++)
            {
                for(int j=i+1; j<this.ballCollection.Count(); j++)
                {
                    Ball b1 = this.ballCollection[i];
                    Ball b2 = this.ballCollection[j];
                    double radiiSum = b1.Radius + b2.Radius;
                    if (CenterSquaredDistance(b1, b2) < radiiSum * radiiSum)
                    {
                        ElasticCollisionPhysics.BallCollision(ref b1, ref b2);
                        //b1.Color = "red";
                    }
                }
            }
        }
    }
}
