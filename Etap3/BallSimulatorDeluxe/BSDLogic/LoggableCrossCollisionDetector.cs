using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSDLogic
{
    internal class LoggableCrossCollisionDetector : CrossCollisionDetector, BSDData.ILoggable
    {
        private (Ball, Ball) ballCouple;

        public LoggableCrossCollisionDetector(BallCollection ballCollection) : base(ballCollection)
        {
            base.CollisionDetected += LoggableCrossCollisionDetector_CollisionDetected;
        }

        private void LoggableCrossCollisionDetector_CollisionDetected(object? sender, CollisionDetectedEventArgs e)
        {
            this.ballCouple = (
                e.Ball1,
                e.Ball2
            );
            this.Log();
        }

        public void Log()
        {
            base.logicAPI?.DataAPI.UploadDataCouple(this.ballCouple.Item1, this.ballCouple.Item2, "COLLISION");
        }
    }
}
