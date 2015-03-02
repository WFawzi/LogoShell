using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        public void Turtle_MovedRight()
        {
            //Arrange
            var xPos = 3.0d;
            var yPos = 3.0d;

            var step = 3.0d;

            //Act
            var turtle = new Turtle(xPos, yPos);
            turtle.moveRight(step);

            //Assert
            Assert.AreEqual((xPos+step), turtle.X, Double.Epsilon);
            Assert.AreEqual(yPos, turtle.Y, Double.Epsilon);
        }

        [TestMethod]
        public void Turtle_MovedLeft()
        {
            //Arrange
            var xPos = 3.0d;
            var yPos = 3.0d;

            var step = 3.0d;

            //Act
            var turtle = new Turtle(xPos, yPos);
            turtle.moveLeft(step);

            //Assert
            Assert.AreEqual((xPos - step), turtle.X, Double.Epsilon);
            Assert.AreEqual(yPos, turtle.Y, Double.Epsilon);
        }
    }
}


//When modifying the core logic, make sure that you do not break any of the older test