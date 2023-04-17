using BSDLogic;

namespace TestBallSimulatorDeluxe
{
    public class Tests
    {
        Ball ball;
        double x = 15.5;
        double y = -17.5;
        int radius = 2;
        string color = "AliceBlue";
        int vx = 3;
        int vy = 5;


        [SetUp]
        public void Setup()
        {
            ball = new Ball((x, y), radius, color, new System.Numerics.Vector2(vx, vy));
        }

        [Test]
        public void Test1()
        {

            Assert.That(ball.Location.Item1, Is.EqualTo(x));
            Assert.That(ball.Location.Item2, Is.EqualTo(y));
            Assert.That(ball.Radius, Is.EqualTo(2));
            Assert.That(ball.Color, Is.EqualTo("AliceBlue"));
            Assert.That(ball.Velocity.X, Is.EqualTo(3));
            Assert.That(ball.Velocity.Y, Is.EqualTo(5));

        }

        [Test]
        public void Test2()
        {
            Assert.That(ball.IntegerX, Is.EqualTo(15));
            Assert.That(ball.IntegerY, Is.EqualTo(-17));
        }
    }
}