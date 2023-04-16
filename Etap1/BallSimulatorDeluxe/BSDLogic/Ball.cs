using System.Drawing;
using System.Numerics;
using System.Windows;

namespace BSDLogic
{
    class Ball
    {
        private Point location;
        private int radius;
        private Color color;
        private Vector2 velocity;
       
        public Ball(Point location, int radius, Color color, Vector2? velocity = null)
        {
            this.location = location;
            this.radius = radius;
            this.color = color;
            this.velocity = velocity ?? new Vector2(0);
        }
        
        public Point Location
        {
            get => this.location;
            set => this.location = value;
        }
        public int Radius => this.radius;
        public Color Color => this.color;
        public Vector2 Velocity
        {
            get => this.velocity;
            set => this.velocity = value;
        }

    }
}