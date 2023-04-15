using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSDData
{
    internal class ConstraintManager
    {
        private Rectangle locationSpan;
        private double minimalBallRadius;
        private double maximalBallRadius;
        public ConstraintManager(Rectangle locationSpan, double minimalBallRadius, double maximalBallRadius)
        {
            this.locationSpan = locationSpan;
            this.minimalBallRadius = minimalBallRadius;
            this.maximalBallRadius = maximalBallRadius;
        }
        public Rectangle LocationSpan => this.locationSpan;
        public double MinimalBallRadius => this.minimalBallRadius;
        public double MaximalBallRadius => this.maximalBallRadius;
    }
}
