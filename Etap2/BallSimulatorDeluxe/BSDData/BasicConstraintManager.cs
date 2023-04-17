using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSDData
{
    class BasicConstraintManager : IConstraintManager
    {
        private Rectangle locationSpan;
        private int maximalBallRadius;
        private int minimalBallRadius;
        private double ballVelocityMagnitude;

        public Rectangle GetLocationSpan()
        {
            return this.locationSpan;
        }

        public int GetMaximalBallRadius()
        {
            return this.maximalBallRadius;
        }

        public int GetMinimalBallRadius()
        {
            return this.minimalBallRadius;
        }
        public double GetBallVelocityMagnitude()
        {
            return this.ballVelocityMagnitude;
        }

        public void SetLocationSpan(Rectangle locationSpan)
        {
            this.locationSpan = locationSpan;
        }

        public void SetMaximalBallRadius(int maximalBallRadius)
        {
            this.maximalBallRadius = maximalBallRadius;
        }

        public void SetMinimalBallRadius(int minimalBallRadius)
        {
            this.minimalBallRadius = minimalBallRadius;
        }
        public void SetBallVelocityMagnitude(double ballVelocityMagnitude)
        {
            this.ballVelocityMagnitude = ballVelocityMagnitude;
        }
    }
}
