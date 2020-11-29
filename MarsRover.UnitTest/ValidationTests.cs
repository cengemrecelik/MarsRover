using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MarsRover.Validation;

namespace MarsRover.UnitTest
{
    [TestClass]
    public class ValidationTests
    {
        [TestMethod]
        public void CoordinateValidationTest()
        {
            string upperRight = "5 5";
            new Validation.CoordinateValidation(upperRight).IsValid();
        }

        [TestMethod]
        public void CoordinateValidationTestError()
        {
            try
            {
                string upperRight = "5 -1";
                new CoordinateValidation(upperRight).IsValid();

                Assert.Fail("Expected exception was not thrown.");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Coordinate must be greater than zero!", ex.Message);
            }

        }

        [TestMethod]
        public void PositionValidationTest()
        {
            string position = "1 5 N";

            int Width = 10;
            int Height = 10;
            new PositionValidation(position, Width, Height).IsValid();
        }

        [TestMethod]
        public void PositionValidationTestError()
        {
            try
            {
                string position = "1 15 N";
                int Width = 10;
                int Height = 10;
                new PositionValidation(position, Width, Height).IsValid();

                Assert.Fail("Expected exception was not thrown.");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Starting position must be inside the plateau!", ex.Message);
            }

        }

        [TestMethod]
        public void CommandValidationTest()
        {
            string command = "LMLMLM";
            new CommandValidation(command).IsValid();
        }

        [TestMethod]
        public void CommandValidationTestError()
        {
            try
            {
                string command = "LMLALM";
                new CommandValidation(command).IsValid();
                Assert.Fail("Expected exception was not thrown.");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Invalid Movement!", ex.Message);
            }

        }

    }
}
