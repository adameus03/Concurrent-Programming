using BSDData;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BSDLogic
{
    class BSDLogicAPI : BSDAbstractLogicAPI
    {
        protected ICollisionDetector? collisionDetector = null;
        public BSDLogicAPI(BSDData.BSDAbstractDataAPI dataAPI/*, CollisionDetector? collisionDetector = null*/) : base(dataAPI) {
            //this.collisionDetector = collisionDetector ?? new CollisionDetector();
        }


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
                int r = minimalBallRadius + random.Next(maximalBallRadius - minimalBallRadius);

                ballList.Add(new Ball(
                    location: (
                        locationSpan.X+r + random.Next(locationSpan.Width-2*r),
                        locationSpan.Y+r + random.Next(locationSpan.Height-2*r)
                    ),
                    radius: r,
                    r,
                    color: ballsColor /*"#"+random.Next().ToString("X")*/,
                    velocity: new Vector2(
                        (float)(velocityMagnitude*Math.Cos(theta)),
                        (float)(velocityMagnitude*Math.Sin(theta))
                    )
                ));
                //ballList.Add(b);
                /*ballList.Add(new Ball(
                    location: b.Location,
                    radius: 5,
                    color: "red",
                    velocity: b.Velocity
                ));*/
            }
            /*ballList.Add(new Ball(
                location: (locationSpan.Left, locationSpan.Top),
                radius: 25,
                color: "green",
                velocity: new Vector2(0,0)
            ));
            ballList.Add(new Ball(
                location: (locationSpan.Right, locationSpan.Top),
                radius: 25,
                color: "green",
                velocity: new Vector2(0, 0)
            ));
            ballList.Add(new Ball(
                location: (locationSpan.Left, locationSpan.Bottom),
                radius: 25,
                color: "green",
                velocity: new Vector2(0, 0)
            ));
            ballList.Add(new Ball(
                location: (locationSpan.Right, locationSpan.Bottom),
                radius: 25,
                color: "green",
                velocity: new Vector2(0, 0)
            ));


            ballList.Add(new Ball(
                location: (0, 0),
                radius: 20,
                color: "purple",
                velocity: new Vector2(0, 0)
            ));
            ballList.Add(new Ball(
                location: (locationSpan.Width, 0),
                radius: 20,
                color: "purple",
                velocity: new Vector2(0, 0)
            ));
            ballList.Add(new Ball(
                location: (0, locationSpan.Height),
                radius: 20,
                color: "purple",
                velocity: new Vector2(0, 0)
            ));
            ballList.Add(new Ball(
                location: (locationSpan.Width, locationSpan.Height),
                radius: 20,
                color: "purple",
                velocity: new Vector2(0, 0)
            ));*/

            base.balls.Put(ballList);
            base.balls.ConfirmSetBalls();
            this.collisionDetector = new CrossCollisionDetector(base.balls);
        }

        public override async void UpdateBalls(int chrononMiliseconds, int planckPixels)
        {
            await Task.Run(async () =>
            {
                Rectangle locationSpan = dataAPI.GetConstraintManager().GetLocationSpan();
                Parallel.For(0, base.balls.Count(), (i) =>
                {
                    Monitor.Enter(balls[i]);
                    double dx = chrononMiliseconds * balls[i].Velocity.X * planckPixels / 1000;
                    double dy = chrononMiliseconds * balls[i].Velocity.Y * planckPixels / 1000;

                    balls[i].Location = (
                            balls[i].Location.Item1 + dx,
                            balls[i].Location.Item2 + dy
                    );
                    //if (!locationSpan.Contains(new Point((int)balls[i].Location.Item1, (int)balls[i].Location.Item2)))
                    //{
                    //    /*balls[i].Location = (
                    //        locationSpan.Left + (balls[i].Location.Item1 - locationSpan.Left + locationSpan.Width) % locationSpan.Width,
                    //        locationSpan.Top + (balls[i].Location.Item2 - locationSpan.Top + locationSpan.Height) % locationSpan.Height
                    //    );*/
                    //    CollisionPhysics.WallPair wallPair;
                    //    if (balls[i].Location.Item1-balls[i].Radius < locationSpan.Left || balls[i].Location.Item1 + balls[i].Radius > locationSpan.Right){
                    //        wallPair = CollisionPhysics.WallPair.LeftRight;
                    //        balls[i].Velocity = CollisionPhysics.WallCollision(balls[i].Velocity, CollisionPhysics.WallPair.LeftRight);
                    //    }
                    //    else if(balls[i].Location.Item2 - balls[i].Radius < locationSpan.Top || balls[i].Location.Item2 + balls[i].Radius > locationSpan.Bottom)
                    //    {
                    //        wallPair = CollisionPhysics.WallPair.TopBottom;
                    //    }

                    //    balls[i].Velocity = CollisionPhysics.WallCollision(balls[i].Velocity, wallPair);
                    //}

                    if (balls[i].Location.Item1 - balls[i].Radius < locationSpan.Left || balls[i].Location.Item1 + balls[i].Radius > locationSpan.Right)
                    {
                        balls[i].Velocity = ElasticCollisionPhysics.WallCollision(balls[i].Velocity, ElasticCollisionPhysics.WallPair.LeftRight);
                    }
                    if (balls[i].Location.Item2 - balls[i].Radius < locationSpan.Top || balls[i].Location.Item2 + balls[i].Radius > locationSpan.Bottom)
                    {
                        balls[i].Velocity = ElasticCollisionPhysics.WallCollision(balls[i].Velocity, ElasticCollisionPhysics.WallPair.TopBottom);
                    }

                    //balls.ConfirmSetBall(balls[i]); MOVED OUT OF THE LOOP FOR PERFORMANCE

                    Monitor.Exit(balls[i]);
                });
                /*for (int i = 0; i < base.balls.Count(); i++) //SEQUENTIAL LOOP WAS REPLACED WITH PARALLELIZED VERSION
                {

                }*/

                if (this.collisionDetector != null)
                {
                    await this.collisionDetector.DetectAndResolve();
                }
            });
            

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
