using BSDLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBallSimulatorDeluxe
{
    internal class ElasticCollisionPhysicsTests
    {
        //public static (float, float) VelocitiesAfterCollision(float v1, float v2, float m1, float m2)
        Ball b1, b2;
        [SetUp]
        public void Setup()
        {
            b1 = new Ball((0, 0), 8, 10, "red", new System.Numerics.Vector2(0, 10));
            b2 = new Ball((10, 10), 8, 10, "blue", new System.Numerics.Vector2(2, 0));
        }
        [Test]
        public void Test1_VelocitiesAfterCollisionTest()
        {
            float m1 = 1;
            float m2 = 1;
            float v1 = 1;
            float v2 = 0;
            (v1, v2) = ElasticCollisionPhysics.VelocitiesAfterCollision(v1, v2, m1, m2);
            Assert.That(v1, Is.EqualTo(0));
            Assert.That(v2, Is.EqualTo(1));
        }
        [Test]
        public void Test2_BallCollisionTest()
        {
            ElasticCollisionPhysics.BallCollision(ref b1, ref b2);
            Assert.That(b1.Velocity.X, Is.EqualTo(2));
            Assert.That(b1.Velocity.Y, Is.EqualTo(0));
            Assert.That(b2.Velocity.X, Is.EqualTo(0));
            Assert.That(b2.Velocity.Y, Is.EqualTo(10));
        }
        [Test]
        public void Test3_WallCollisionTest()
        {
            System.Numerics.Vector2 vec1 = ElasticCollisionPhysics.WallCollision(new System.Numerics.Vector2(3, 5), ElasticCollisionPhysics.WallPair.TopBottom);
            System.Numerics.Vector2 vec2 = ElasticCollisionPhysics.WallCollision(new System.Numerics.Vector2(3, 5), ElasticCollisionPhysics.WallPair.LeftRight);
            Assert.That(vec1.X, Is.EqualTo(3));
            Assert.That(vec1.Y, Is.EqualTo(-5));
            Assert.That(vec2.X, Is.EqualTo(-3));
            Assert.That(vec2.Y, Is.EqualTo(5));

        }
    }
}