namespace Tests
{
    using NUnit.Framework;

    using System;

    public class DatabaseTests
    {
        private Database database;
        private readonly int[] initialData = new int[] { 1, 2 };

        [SetUp]
        public void Setup()
        {
            this.database = new Database(initialData);
        }

        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            int[] data = new int[] { 1, 2, 3 };
            this.database = new Database(data);

            int expectedCount = data.Length;
            int actualCount = this.database.Count;

            Assert.AreEqual(expectedCount, actualCount);

        }

        [Test]
        public void ConstructorShouldThrowExceptionWhenBiggerCollection()
        {
            int[] data = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database = new Database(data);
            });
        }

        [Test]
        public void AddShouldIncreaseCountWhenAddedSuccessfully()
        {
            this.database.Add(3);

            int expectedCount = 3;
            int actualCount = this.database.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddShouldThrowExceptionWhenDatabaseFull()
        {
            for (int i = 3; i <= 16; i++)
            {
                this.database.Add(i);
            }

            Assert.Throws<InvalidOperationException>(() => 
            { 
                this.database.Add(17); 
            });
        }

        [Test]
        public void RemoveShouldDecreaseCountWhenSuccess()
        {
            int expected = 1;

            this.database.Remove();

            int actual = this.database.Count;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RemoveShouldThrowExceptionWhenDatabaseIsEmpty()
        {
            this.database.Remove();
            this.database.Remove();

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.Remove();
            });
        }

        [TestCase(new int[] { 1,2,3})]
        [TestCase(new int[] { })]
        [TestCase(new int[] { 1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16})]
        public void FetchShouldReturnCopyOfData(int[] expectedData)
        {
            this.database = new Database(expectedData);

            int[] actualData = this.database.Fetch();

            CollectionAssert.AreEqual(expectedData, actualData);
        }
    }
}