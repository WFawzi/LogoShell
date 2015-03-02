﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Tests
{
    [TestClass]
    public class TurtleTests
    {
        [TestMethod]
        public void Turtle_WhenCreated_StartsAtOrigin()
        {
            //Arrange
            
            //Act
            var turtle = new Turtle();

            //Assert
            Assert.AreEqual(0.0, turtle.X, Double.Epsilon);
            Assert.AreEqual(0.0, turtle.Y, Double.Epsilon);
        }

        [TestMethod]
        public void Turtle_WhenCreatedWithPosition_StartsAtDefinedPosition()
        {
            //Arrange
            var xPos = 3.0d;
            var yPos = 3.0d;
            
            //Act
            var turtle = new Turtle(xPos, yPos);

            //Assert
            Assert.AreEqual(xPos, turtle.X, Double.Epsilon);
            Assert.AreEqual(yPos, turtle.Y, Double.Epsilon);
        }

        [TestMethod]
        public void Turtle_WhenCreated_PointsUp()
        {
            var turtle = new Turtle();

            Assert.AreEqual(0.0d, turtle.Direction, Double.Epsilon);
        }

        [TestMethod]
        public void Turn_UpdatesDirection()
        {
            var turtle = new Turtle();
            var angleToRotate = 90.0d;

            turtle.Turn(angleToRotate);

            Assert.AreEqual(angleToRotate, turtle.Direction, Double.Epsilon);
        }


        [TestMethod]
        public void Turn_MultipleTimes_AccumulatesTotalAngle()
        {
            var turtle = new Turtle();
            var angleToRotate = 90.0d;

            turtle.Turn(angleToRotate);
            turtle.Turn(angleToRotate);

            Assert.AreEqual(2*angleToRotate, turtle.Direction, Double.Epsilon);
        }


        [TestMethod]
        public void Turn_OnNegativeAngle_DirectionRemainsPositive()
        {
            var turtle = new Turtle();

            turtle.Turn(-450.5d);

            Assert.AreEqual(269.5d, turtle.Direction, Double.Epsilon);
        }

        [TestMethod]
        public void Turn_OnAngleGreaterThan360_DirectionRemainsLessThan360()
        {
            var turtle = new Turtle();

            turtle.Turn(1080.5d); //360 * 3

            Assert.AreEqual(0.5d, turtle.Direction, Double.Epsilon);
        }

        [TestMethod]
        public void MoveForward_OnInitialTurtle_MovesUp()
        {
            //Arrange
            var step = 3.0d;
            Turtle turtle = new Turtle();

            //Act
            turtle.MoveForward(step);

            //Assert
            Assert.AreEqual(0.0d, turtle.X, Double.Epsilon);
            Assert.AreEqual(step, turtle.Y, Double.Epsilon);
        }

        [TestMethod]
        public void MoveForward_MultipleTimes_AccumulatesTotalDistance()
        {
            //Arrange
            var step = 3.0d;
            Turtle turtle = new Turtle();

            //Act
            turtle.MoveForward(step);
            turtle.MoveForward(step);

            //Assert
            Assert.AreEqual(0.0d, turtle.X, Double.Epsilon);
            Assert.AreEqual(2*step, turtle.Y, Double.Epsilon);
        }

        [TestMethod]
        public void TurnAndMove_MovesAtAnAngle()
        {
            //Arrange
            var turtle = new Turtle();

            //Act
            turtle.Turn(53.130102354155978703144387440907d);
            turtle.MoveForward(5.0d);

            //Assert
            Assert.AreEqual(4.0d, turtle.X, 0.000000001d);
            Assert.AreEqual(3.0d, turtle.Y, 0.000000001d);
        }
    }
}


//When modifying the core logic, make sure that you do not break any of the older test