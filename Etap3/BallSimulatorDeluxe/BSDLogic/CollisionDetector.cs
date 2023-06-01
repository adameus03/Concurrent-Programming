using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BSDLogic
{
    public abstract class CollisionDetector : ICollisionDetector
    {
        protected BallCollection ballCollection;
        protected readonly BSDAbstractLogicAPI? logicAPI = null;
        public CollisionDetector(BallCollection ballCollection)
        {
            this.ballCollection = ballCollection;
        }
        public CollisionDetector(BallCollection ballCollection, BSDAbstractLogicAPI logicAPI)
        {
            this.logicAPI = logicAPI;
            this.ballCollection = ballCollection;
        }

        public static CollisionDetector CreateInstance(BallCollection ballCollection, BSDAbstractLogicAPI? logicAPI = null)
        {
            //return new CrossCollisionDetector(ballCollection);
            /* REFACTORING TO LOGGABLE CROSS COLLISION DETECTOR 
               (Easy thanks to DI)
             */
            return logicAPI == null ? new LoggableCrossCollisionDetector(ballCollection) : new LoggableCrossCollisionDetector(ballCollection, logicAPI);
        }

        public abstract Task DetectAndResolve();

        public event EventHandler<CollisionDetectedEventArgs>? CollisionDetected;
        protected void OnCollisionDetected(object? sender, CollisionDetectedEventArgs e)
        {
            this.CollisionDetected?.Invoke(sender, e);
        }

        public class CollisionDetectedEventArgs
        {
            private Ball ball1;
            private Ball ball2;
            public CollisionDetectedEventArgs(Ball ball1, Ball ball2)
            {
                this.ball1 = ball1;
                this.ball2 = ball2;
            }

            public Ball Ball1 => this.ball1;
            public Ball Ball2 => this.ball2;
        }

    }
}
