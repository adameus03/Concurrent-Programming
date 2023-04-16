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
            for(int i=0; i<ballsNumber; i++)
            {
                Point location = new Point(
                    locationSpan.X + random.Next(locationSpan.Width),
                    locationSpan.Y + random.Next(locationSpan.Height)
                );
                balls.Add(new Ball(
                    location: new Point(
                        locationSpan.X + random.Next(locationSpan.Width),
                        locationSpan.Y + random.Next(locationSpan.Height)
                    ),
                    radius: minimalBallRadius+random.Next(maximalBallRadius-minimalBallRadius),
                    color: ballsColor
                ));
            }
        }

        public override void UpdateBalls(int chrononMiliseconds, int planckPixels)
        {

            Rectangle locationSpan = dataAPI.GetConstraintManager().GetLocationSpan();
            for (int i=0; i<balls.Count; i++)
            {
                balls[i].Location.Offset(
                    (int)(chrononMiliseconds * balls[i].Velocity.X * planckPixels),
                    (int)(chrononMiliseconds * balls[i].Velocity.Y * planckPixels)
                );
                if (!locationSpan.Contains(balls[i].Location))
                {
                    balls[i].Location = new Point(
                        locationSpan.Left + (balls[i].Location.X - locationSpan.Left) % locationSpan.Width,
                        locationSpan.Top + (balls[i].Location.Y - locationSpan.Top) % locationSpan.Height
                    );
                }
            }
           
            
        }
    }
}
