using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BSDLogic;

namespace TestBallSimulatorDeluxe
{
    public class BallCollectionTests
    {
        private BallCollection ballCollection = new BallCollection();
        private List<Ball> list = new List<Ball>();

        [SetUp]
        public void Setup()
        {
            Ball ball1 = new Ball((0.5, 0.2), 3, 1, "Gray", new System.Numerics.Vector2(2, -3));
            list.Add(ball1);
            Ball ball2 = new Ball((-0.2, -3), 2, 1,"Yellow", new System.Numerics.Vector2(3, -8));
            list.Add(ball2);
        }

        [Test]
        public void Test1()
        {
            ballCollection.Put(list);
            Assert.That(ballCollection.Count(), Is.EqualTo(2));
        }
        [Test]
        public void Test2()
        {
            Assert.That(ballCollection[0], Is.EqualTo(list[0]));
            Assert.That(ballCollection[1], Is.EqualTo(list[1]));
        }
    }
}