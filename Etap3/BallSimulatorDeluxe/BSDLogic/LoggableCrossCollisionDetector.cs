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
            Initialize();
        }
        public LoggableCrossCollisionDetector(BallCollection ballCollection, BSDAbstractLogicAPI logicAPI) : base(ballCollection, logicAPI)
        {
            Initialize();
        }

        private void Initialize()
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
            if (base.logicAPI == null) return;
            if (base.logicAPI.DataAPI.GetSerializationLogManager().IsActive)
            {
                base.logicAPI?.DataAPI.UploadDataCouple(this.ballCouple.Item1, this.ballCouple.Item2, "COLLISION");
            }
            
        }
    }
}
