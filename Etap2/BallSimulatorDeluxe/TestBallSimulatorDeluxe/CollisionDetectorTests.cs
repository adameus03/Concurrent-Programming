using BSDData;
using BSDLogic;
using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBallSimulatorDeluxe
{
    internal class CollisionDetectorTests
    {
        BallCollection ballCollection;
        CollisionDetector collisionDetector;
        Ball b1, b2;

        [SetUp]
        public void Setup()
        {
            ballCollection = new BallCollection();
            collisionDetector = CollisionDetector.CreateInstance(ballCollection);
            b1 = new Ball((0, 0), 8, 10, "red", new System.Numerics.Vector2(0, 10));
            b2 = new Ball((10, 10), 8, 10, "blue", new System.Numerics.Vector2(2, 0));
            ballCollection.Put(new List<Ball>(new Ball[2]{ b1, b2 }));
        }

        [Test]
        
        public void Test1()
        {
            Assert.IsInstanceOf(typeof(CollisionDetector), collisionDetector);
        }
        [Test]
        public void Test2()
        {
            collisionDetector.DetectAndResolve();
            Assert.That(b1.Velocity.X, Is.EqualTo(2));
            Assert.That(b1.Velocity.Y, Is.EqualTo(0));
            Assert.That(b2.Velocity.X, Is.EqualTo(0));
            Assert.That(b2.Velocity.Y, Is.EqualTo(10));
        }
    }
}