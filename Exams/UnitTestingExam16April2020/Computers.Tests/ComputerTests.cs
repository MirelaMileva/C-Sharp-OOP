namespace Computers.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class ComputerTests
    {
        private List<Part> parts;

        [SetUp]
        public void Setup()
        {
            this.parts = new List<Part>();
        }

        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            Computer computer = new Computer("a");

            Assert.IsEmpty(computer.Parts);
        }

        [Test]
        public void NameShouldThrowExceptionIfNullOrWhiteSpace()
        {
            Computer computer; 

            Assert.Throws<ArgumentNullException>(
                () => { computer = new Computer(null); });
        }

        [Test]
        public void NameShouldWorkCorrectly()
        {
            string name = "PC";
            Computer computer = new Computer(name);

            var expected = "PC";
            Assert.AreEqual(expected, computer.Name);
        }

        [Test]
        public void TestIfAddPartMethodWorksCorrectly()
        {
            Computer computer = new Computer("a");
            computer.AddPart(new Part("abm", 2));

            var expected = 1;
            Assert.AreEqual(expected, computer.Parts.Count);
        }

        [Test]
        public void AddPartMethodShouldThrowExceptionIfPartIsNull()
        {
            Computer computer = new Computer("a");

            Assert.Throws<InvalidOperationException>
                (() => { computer.AddPart(null); });
        }

        [Test]
        public void TestIfTotalPriceCalculateProperly()
        {
            Computer computer = new Computer("a");
            computer.AddPart(new Part("abm", 2));
            computer.AddPart(new Part("abc", 3));

            var expected = 5;
            var actual = computer.TotalPrice;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestIfRemovePartMethodRemovesFromCollection()
        {
            Computer computer = new Computer("a");
            Part part = new Part("aba", 2);
            computer.AddPart(part);

            computer.RemovePart(part);
            var expected = 0;

            Assert.AreEqual(expected, computer.Parts.Count);
        }

        [Test]
        public void TestIfGetPartMethodWorksCorrectly()
        {
            Computer computer = new Computer("a");
            Part expectedPart = new Part("abc", 2);
            computer.AddPart(expectedPart);

            Part actualPart = computer.GetPart("abc");

            Assert.AreEqual(expectedPart, actualPart);
        }
    }
}