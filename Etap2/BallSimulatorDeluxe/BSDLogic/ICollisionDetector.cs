using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSDLogic
{
    public interface ICollisionDetector
    {
        public Task DetectAndResolve();

    }
}
