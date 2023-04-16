using BSDLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSDMVVM
{
    class BSDModel
    {
        private BSDLogic.BSDAbstractLogicAPI logicAPI;
        public BSDModel(BSDLogic.BSDAbstractLogicAPI? logicAPI = null)
        {
            this.logicAPI = logicAPI ?? BSDLogic.BSDAbstractLogicAPI.CreateInstance();
        }
    }
}
