using System.Drawing;
using System.Numerics;
using System.Windows;

namespace BSDLogic
{
    public class Ball
    {
        private (double, double) location;
        private int radius;
        private string color;
        private Vector2 velocity;
       
        public Ball((double, double) location, int radius, string color, Vector2? velocity = null)
        {
            this.location = location;
            this.radius = radius;
            this.color = color;
            this.velocity = velocity ?? new Vector2(0);
        }
        
        public (double,double) Location
        {
            get => this.location;
            set => this.location = value;
        }
        public int Radius => this.radius;
        public string Color => this.color;
        public Vector2 Velocity
        {
            get => this.velocity;
            set => this.velocity = value;
        }

        public int IntegerX => (int)this.Location.Item1;
        public int IntegerY => (int)this.Location.Item2;

    }
}