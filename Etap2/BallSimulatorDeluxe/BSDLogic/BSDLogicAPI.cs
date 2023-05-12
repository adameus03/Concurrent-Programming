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

        public override void GenerateBalls(int ballsNumber, string ballsColor)
        {
            IConstraintManager constraints = dataAPI.GetConstraintManager();
            Rectangle locationSpan = constraints.GetLocationSpan();
            int minimalBallRadius = constraints.GetMinimalBallRadius();
            int maximalBallRadius = constraints.GetMaximalBallRadius();
            double velocityMagnitude = constraints.GetBallVelocityMagnitude();
            Random random = new Random();
            List<Ball> ballList = new List<Ball>();
            for(int i=0; i<ballsNumber; i++)
            {
                Point location = new Point(
                    locationSpan.X + random.Next(locationSpan.Width),
                    locationSpan.Y + random.Next(locationSpan.Height)
                );

                double theta = 2 * Math.PI * random.NextDouble();

                ballList.Add(new Ball(
                    location: (
                        locationSpan.X + random.Next(locationSpan.Width),
                        locationSpan.Y + random.Next(locationSpan.Height)
                    ),
                    radius: minimalBallRadius+random.Next(maximalBallRadius-minimalBallRadius),
                    color: ballsColor,
                    velocity: new Vector2(
                        (float)(velocityMagnitude*Math.Cos(theta)),
                        (float)(velocityMagnitude*Math.Sin(theta))
                    )
                ));
            }
            base.balls.Put(ballList);
            base.balls.ConfirmSetBalls();
        }

        public override void UpdateBalls(int chrononMiliseconds, int planckPixels)
        {

            Rectangle locationSpan = dataAPI.GetConstraintManager().GetLocationSpan();
            for (int i=0; i<base.balls.Count(); i++)
            {
                double dx = chrononMiliseconds * balls[i].Velocity.X * planckPixels / 1000;
                double dy = chrononMiliseconds * balls[i].Velocity.Y * planckPixels / 1000;
                /*balls[i].Location.Offset(
                    dx,
                    dy
                );*/
                balls[i].Location = (
                        balls[i].Location.Item1 + dx,
                        balls[i].Location.Item2 + dy
                );
                if (!locationSpan.Contains(new Point((int)balls[i].Location.Item1, (int)balls[i].Location.Item2)))
                {
                    balls[i].Location = (
                        locationSpan.Left + (balls[i].Location.Item1 - locationSpan.Left + locationSpan.Width) % locationSpan.Width,
                        locationSpan.Top + (balls[i].Location.Item2 - locationSpan.Top + locationSpan.Height) % locationSpan.Height
                    );
                }
                //balls.ConfirmSetBall(balls[i]); COMMENTED OUT FOR PERFORMANCE
            }
            balls.ConfirmSetBalls();
            
        }
        public override void SetConstraint(string constraintName, object constraintValue)
        {
            switch (constraintName)
            {
                case "LocationSpan":
                    dataAPI.GetConstraintManager().SetLocationSpan((Rectangle)constraintValue);
                    break;
                case "MinimalBallRadius":
                    dataAPI.GetConstraintManager().SetMinimalBallRadius((int)constraintValue);
                    break;
                case "MaximalBallRadius":
                    dataAPI.GetConstraintManager().SetMaximalBallRadius((int)constraintValue);
                    break;
                case "BallVelocityMagnitude":
                    dataAPI.GetConstraintManager().SetBallVelocityMagnitude((double)constraintValue);
                    break;
                default:
                    throw new Exception("Invalid BasicConstraintManager constraint name");
            }
        }
    }
}
