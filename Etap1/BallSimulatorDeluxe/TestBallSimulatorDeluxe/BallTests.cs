using BSDLogic;

namespace TestBallSimulatorDeluxe
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test1()
        {
            Ball ball = new Ball((15.5, -17.2), 2, "AliceBlue", new System.Numerics.Vector2(3, 5));
            Assert.That(ball.Location.Item1, Is.EqualTo(15.5));
            Assert.That(ball.Location.Item2, Is.EqualTo(-17.2));
            Assert.That(ball.Radius, Is.EqualTo(2));
            Assert.That(ball.Color, Is.EqualTo("AliceBlue"));
            Assert.That(ball.Velocity.X, Is.EqualTo(3));
            Assert.That(ball.Velocity.Y, Is.EqualTo(5));

        }
    }
}