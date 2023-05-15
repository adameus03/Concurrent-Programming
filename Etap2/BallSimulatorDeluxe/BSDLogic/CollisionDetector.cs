using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BSDLogic
{
    internal abstract class CollisionDetector : ICollisionDetector
    {
        protected BallCollection ballCollection;
        public CollisionDetector(BallCollection ballCollection)
        {
            this.ballCollection = ballCollection;
        }

        public static CollisionDetector CreateInstance(BallCollection ballCollection)
        {
            return new CrossCollisionDetector(ballCollection);
        }

        public abstract void DetectAndResolve();
    }
}
