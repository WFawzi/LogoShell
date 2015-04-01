using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Coordinate //x and y position of the turtle
    {
        public double X { get; private set; }
        public double Y { get; private set; }

        public Coordinate(double x, double y) //you can only set the X and Y through the constructor
        {
            X = x;
            Y = y;
        }
    }


    public class Turtle
    {
        //Properties START HERE
        public Coordinate Position{ get; private set; } //current X and Y of the turtle
        public double Direction { get; private set; } // rotation angle

        private Queue<Coordinate> _path; //_path is a queue of the Coordinate of the turtle, each Coordinate is the X and Y of the turtle   

        //Path is an interface
        //We use the interface Path to access the queue _path as a way of protecting _path,
        //so that _path cannot be modifed from outside of the Turtle class, and new coordianets are added by mistake to _queue
        //Another unsafe way of implementing this, is to ignore the IEnumerable Path, and make _path public
        public IEnumerable<Coordinate> Path 
        {
            get
            {
                return _path;
            }
        }
        //Properties END HERE


        //Constructores START HERE 
        public Turtle() : this(0.0d, 0.0d, 0.0d) //calls the other constructor and passes 0.0d as X and Y
        {
        }

        public Turtle(double x, double y, double direction)
        {
            Position = new Coordinate(x, y);

            //Direction = 0.0d;
            Direction = direction;

            _path = new Queue<Coordinate>();

            AddCurrentPositionToPath();            
        }
        //Constructores END HERE


        //Functions START HERE
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

            Direction = Direction % 360d; //if direction (the angle) is greater than 360, make it between 0 and 360

            if (Direction < 0) //if direction (the angle) is negative, keep rotating it by 360 till it's positive
            {
                Direction += 360d;
            }
        }

        public void MoveForwardArc(double angle, double radius)
        { 
            double steps = 1000;
            double angleStep = angle/steps;
            double radiusStep = radius/steps;

            double i = 0;

            while(i < steps)
            {
                MoveForward(radiusStep);
                Turn(angleStep);
                i++;
            }
        }

        //Functions END HERE
    }
}
