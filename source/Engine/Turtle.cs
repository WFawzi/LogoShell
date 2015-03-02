using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Turtle
    {
        public Turtle()
        {
            this.X = 0;
            this.Y = 0;
        }

        public Turtle(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public double X { get; private set; }
        public double Y { get; private set; }


        public void moveRight(double step)
        {
            X += step;
        }

        public void moveLeft(double step)
        {
            X -= step;
        }

        public void moveUp(double step)
        {
            Y -= step;
        }

        public void moveDown(double step)
        {
            Y += step;
        }
    }
}
