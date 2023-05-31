using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSDData
{
    public interface IConstraintManager
    {
        public Rectangle GetLocationSpan();
        public int GetMinimalBallRadius();
        public int GetMaximalBallRadius();
        public double GetBallVelocityMagnitude();

        public void SetLocationSpan(Rectangle locationSpan);
        public void SetMinimalBallRadius(int minimalBallRadius);
        public void SetMaximalBallRadius(int maximalBallRadius);
        public void SetBallVelocityMagnitude(double ballVelocityMagnitude);
    }
}
