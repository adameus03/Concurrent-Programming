using BSDData;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSDLogic
{
    class BSDLogicAPI : BSDAbstractLogicAPI
    {
        private readonly ConstraintManager? constraintManager;
        public BSDLogicAPI(BSDData.BSDAbstractDataAPI dataAPI) : base(dataAPI) { }

        public override void GenerateBalls(int ballsNumber, Color ballsColor)
        {
            throw new NotImplementedException();
        }

        public override void SetContraints(Rectangle locationSpan, double minimalBallRadius, double maximalBallRadius)
        {
            this.constraintManager = new ConstraintManager()
        }

        public override void UpdateBalls()
        {
            throw new NotImplementedException();
        }
    }
}
