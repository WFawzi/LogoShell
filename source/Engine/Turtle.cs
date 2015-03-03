using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Coordinate
    {
        public double X { get; private set; }
        public double Y { get; private set; }

        public Coordinate(double x, double y)
        {
            X = x;
            Y = y;
        }
    }

    public class Turtle
    {
        public Coordinate Position{ get; private set; }

        public double Direction { get; private set; }

        private Queue<Coordinate> _path;
        public IEnumerable<Coordinate> Path
        {
            get
            {
                return _path;
            }
        } 

        public Turtle() : this(0.0d, 0.0d)
        {
        }

        public Turtle(double x, double y)
        {
            Position = new Coordinate(x, y);

            Direction = 0.0d;
            _path = new Queue<Coordinate>();

            AddCurrentPositionToPath();            
        }

        public void MoveForward(double step)
        {
            var tmpX = Position.X + step * Math.Sin(ConvertToRadians(Direction));
            var tmpY = Position.Y + step * Math.Cos(ConvertToRadians(Direction));

            Position = new Coordinate(tmpX, tmpY);

            AddCurrentPositionToPath();
        }

        private void AddCurrentPositionToPath()
        {
            _path.Enqueue(Position);
        }

        private double ConvertToRadians(double angle)
        {
            return (Math.PI / 180) * angle;
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
    }
}
