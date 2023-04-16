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
        public BSDLogicAPI(BSDData.BSDAbstractDataAPI dataAPI) : base(dataAPI) { }

        public override void GenerateBalls(int ballsNumber, Color ballsColor)
        {
            throw new NotImplementedException();
        }

        public override void UpdateBalls()
        {
            throw new NotImplementedException();
        }
    }
}
