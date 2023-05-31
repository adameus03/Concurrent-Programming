using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BSDLogic
{
    public static class ElasticCollisionPhysics
    {
        public enum WallPair
        {
            TopBottom,
            LeftRight
        }
        public static Vector2 WallCollision(Vector2 velocity, WallPair wallPair)
        {
            if (wallPair == WallPair.TopBottom)
            {
                return new Vector2(velocity.X, -velocity.Y);
            }
            else
            {
                return new Vector2(-velocity.X, velocity.Y);
            }
        }

        public static (float, float) VelocitiesAfterCollision(float v1, float v2, float m1, float m2)
        {
            return (
                ((m1-m2)*v1+2*m2*v2)/(m1+m2),
                (2*m1*v1+(m2-m1)*v2)/(m1+m2)
            );
        }

        public static void BallCollision(ref Ball b1, ref Ball b2)
        {
            float v1x, v1y, v2x, v2y;
            (v1x, v2x) = VelocitiesAfterCollision(b1.Velocity.X, b2.Velocity.X, b1.Mass, b2.Mass);
            (v1y, v2y) = VelocitiesAfterCollision(b1.Velocity.Y, b2.Velocity.Y, b1.Mass, b2.Mass);
            b1.Velocity = new Vector2(v1x, v1y);
            b2.Velocity = new Vector2(v2x, v2y);
            b1.Color = b1.Color == "green" ? "blue" : "green";
            b2.Color = b2.Color == "blue" ? "green" : "blue";

            //b1.Velocity = new Vector2(0, 0);
            //b2.Velocity = new Vector2(0, 0);
        }
    }
}
