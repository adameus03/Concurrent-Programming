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
        public BSDAbstractDataAPI() { }
        public static BSDAbstractDataAPI CreateInstance()
        {
            return new BSDDataAPI();
        }

        public abstract IConstraintManager GetConstraintManager();
    }
}
