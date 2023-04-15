using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSDData
{
    public abstract class BSDAbstractDataAPI
    {
        private ConstraintManager constraintManager;
        public BSDAbstractDataAPI() { }
        public static BSDAbstractDataAPI CreateInstance()
        {
            return new BSDDataAPI();
        }

        public abstract void SetContraints(Rectangle locationSpan, double minimalBallRadius, double maximalBallRadius);
    }
}
