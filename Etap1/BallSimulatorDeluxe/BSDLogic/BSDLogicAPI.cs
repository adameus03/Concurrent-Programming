using BSDData;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BSDLogic
{
    class BSDLogicAPI : BSDAbstractLogicAPI
    {
        public BSDLogicAPI(BSDData.BSDAbstractDataAPI dataAPI) : base(dataAPI) { }

        public override void GenerateBalls(int ballsNumber, Color ballsColor)
        {
            IConstraintManager constraints = dataAPI.GetConstraintManager();
            Rectangle locationSpan = constraints.GetLocationSpan();
            int minimalBallRadius = constraints.GetMinimalBallRadius();
            int maximalBallRadius = constraints.GetMaximalBallRadius();
            Random random = new Random();
            List<Ball> ballList = new List<Ball>();
            for(int i=0; i<ballsNumber; i++)
            {
                Point location = new Point(
                    locationSpan.X + random.Next(locationSpan.Width),
                    locationSpan.Y + random.Next(locationSpan.Height)
                );
                ballList.Add(new Ball(
                    location: new Point(
                        locationSpan.X + random.Next(locationSpan.Width),
                        locationSpan.Y + random.Next(locationSpan.Height)
                    ),
                    radius: minimalBallRadius+random.Next(maximalBallRadius-minimalBallRadius),
                    color: ballsColor
                ));
            }
            base.balls = new BallCollection(ballList);
        }

        public override void UpdateBalls(int chrononMiliseconds, int planckPixels)
        {

            Rectangle locationSpan = dataAPI.GetConstraintManager().GetLocationSpan();
            foreach (Ball ball in base.balls)
            {
                ball.Location.Offset(
                    (int)(chrononMiliseconds * ball.Velocity.X * planckPixels),
                    (int)(chrononMiliseconds * ball.Velocity.Y * planckPixels)
                );
                if (!locationSpan.Contains(ball.Location))
                {
                    ball.Location = new Point(
                        locationSpan.Left + (ball.Location.X - locationSpan.Left) % locationSpan.Width,
                        locationSpan.Top + (ball.Location.Y - locationSpan.Top) % locationSpan.Height
                    );
                }
                balls.ConfirmSetBall(ball);
            }
           
            
        }
    }
}
