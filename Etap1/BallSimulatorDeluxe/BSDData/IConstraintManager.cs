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
        public double GetMinimalBallRadius();
        public double GetMaximalBallRadius();

        public void SetLocationSpan(Rectangle locationSpan);
        public void SetMinimalBallRadius(double minimalBallRadius);
        public void SetMaximalBallRadius(double maximalBallRadius);
    }
}
