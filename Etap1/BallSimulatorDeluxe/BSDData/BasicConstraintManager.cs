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
        private double maximalBallRadius;
        private double minimalBallRadius;

        public Rectangle GetLocationSpan()
        {
            return this.locationSpan;
        }

        public double GetMaximalBallRadius()
        {
            return this.maximalBallRadius;
        }

        public double GetMinimalBallRadius()
        {
            return this.minimalBallRadius;
        }

        public void SetLocationSpan(Rectangle locationSpan)
        {
            this.locationSpan = locationSpan;
        }

        public void SetMaximalBallRadius(double maximalBallRadius)
        {
            this.maximalBallRadius = maximalBallRadius;
        }

        public void SetMinimalBallRadius(double minimalBallRadius)
        {
            this.minimalBallRadius = minimalBallRadius;
        }
    }
}
