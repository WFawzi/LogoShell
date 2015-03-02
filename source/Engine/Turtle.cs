using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Turtle
    {
        public double X { get; private set; }
        public double Y { get; private set; }
        public double Direction { get; private set; }

        public Turtle()
        {
            this.X = 0;
            this.Y = 0;
            this.Direction = 0;
        }

        public Turtle(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public void MoveForward(double step)
        {
            Y += step;
        }

        public void Turn(double angle)
        {
            Direction += angle;

            Direction = Direction % 360d;

            if (Direction < 0)
            {
                Direction += 360d;
            }
        }


        public void MoveRight(double step)
        {
            X += step;
        }

        public void MoveLeft(double step)
        {
            X -= step;
        }
    }
}
