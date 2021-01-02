namespace INStock.Tests
{
    using System;
    using System.Linq;
    using NUnit.Framework;

    [TestFixture]
    public class ProductStockTests
    {
        private const string ProductLabel = "Test";
        private const string AnotherProductLabel = "Another Test";

        private ProductStock productStock;
        private Product product;
        private Product anotherProduct;

        [SetUp]
        public void SetUpProduct()
        {
            this.productStock = new ProductStock();
            this.product = new Product(ProductLabel, 10, 1);
            this.anotherProduct = new Product(AnotherProductLabel, 20, 5);
        }

        [Test]
        public void AddProductShouldSaveTheProduct()
        {
            //Act
            this.productStock.Add(this.product);

            //Assert
            var productInStock = this.productStock.FindByLabel(ProductLabel);

            Assert.That(productInStock, Is.Not.Null);
            Assert.That(productInStock.Label, Is.EqualTo(ProductLabel));
            Assert.That(productInStock.Price, Is.EqualTo(10));
            Assert.That(productInStock.Quantity, Is.EqualTo(1));
        }

        [Test]
        public void AddProductShouldThrowExceptionWithDuplicateLabel()
        {
            //Arrange & Act
            Assert.That(
                () =>
            {
                this.productStock.Add(product);
                this.productStock.Add(product);
            }, Throws.Exception.InstanceOf<ArgumentException>().With.Message.EqualTo($"A product with {ProductLabel} label already exist."));
        }

        [Test]
        public void AddingTwoProductsShouldSaveThem()
        {
            //Act
            this.productStock.Add(this.product);
            this.productStock.Add(this.anotherProduct);

            //Assert
            var firstProductInStock = this.productStock.FindByLabel(ProductLabel);
            var secondProductInStock = this.productStock.FindByLabel(AnotherProductLabel);

            Assert.That(firstProductInStock, Is.Not.Null);
            Assert.That(firstProductInStock.Label, Is.EqualTo(ProductLabel));
            Assert.That(firstProductInStock.Price, Is.EqualTo(10));
            Assert.That(firstProductInStock.Quantity, Is.EqualTo(1));

            Assert.That(secondProductInStock, Is.Not.Null);
            Assert.That(secondProductInStock.Label, Is.EqualTo(AnotherProductLabel));
            Assert.That(secondProductInStock.Price, Is.EqualTo(20));
            Assert.That(secondProductInStock.Quantity, Is.EqualTo(5));
        }

        [Test]
        public void RemoveShouldThrowExceptionWhenProductIsNull()
        {
            Assert.Throws<ArgumentException>(
                () => this.productStock.Remove(null), 
                "Product cannot be null");

            //Assert.That(
            //    () => this.productStock.Remove(null), Throws
            //    .Exception.InstanceOf<ArgumentException>().With.Message.EqualTo("Product cannot be null"));
        }

        [Test]
        public void RemoveShouldReturnTrueWhenProductIsRemoved()
        {
            //Arrange
            this.AddMultipleProductsToProductStock();
            var productToRemove = this.productStock.Find(3);

            //Act
            var result = this.productStock.Remove(productToRemove);

            //Assert
            Assert.That(result, Is.True);
            Assert.That(this.productStock.Count, Is.EqualTo(4));
            Assert.That(this.productStock[3].Label, Is.EqualTo("5"));
        }

        [Test]
        public void RemoveShouldReturnFalseWhenProductIsNotFound()
        {
            //Arrange
            this.AddMultipleProductsToProductStock();
            var productIsNotInStock = new Product(ProductLabel, 10, 20);
            //Act
            var result = this.productStock.Remove(productIsNotInStock);

            //Assert
            Assert.That(result, Is.False);
            Assert.That(this.productStock.Count, Is.EqualTo(5));
        }

        [Test]
        public void ContainsShouldReturnTrueWhenProductExist()
        {
            //Arrange
            this.productStock.Add(this.product);

            //Act
            var result = this.productStock.Contains(this.product);

            //Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void ContainsShouldReturnFalseWhenProductDoesNotExist()
        {
            //Act
            var result = this.productStock.Contains(this.product);

            //Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void ContainsShouldThrowExceptionWhenProductIsNull()
        {
            Assert.Throws<ArgumentException>(
                () => this.productStock.Contains(null),
                "Product cannot be null");

            //Assert.That(
            //    () => this.productStock.Contains(null), Throws
            //    .Exception.InstanceOf<ArgumentException>().With.Message.EqualTo("Product cannot be null"));
        }

        [Test]
        public void CountShouldReturnCorrectProductCount()
        {
            //Arrange
            this.productStock.Add(this.product);
            this.productStock.Add(this.anotherProduct);
            //Act
            var result = this.productStock.Count;

            //Assert    
            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void FindShouldReturnCorrectProductByIndex()
        {
            //Arrange
            this.productStock.Add(this.product);
            this.productStock.Add(this.anotherProduct);

            //Act
            var productInStock = this.productStock.Find(1);

            //Assert
            Assert.That(productInStock, Is.Not.Null);
            Assert.That(productInStock.Label, Is.EqualTo(AnotherProductLabel));
            Assert.That(productInStock.Price, Is.EqualTo(20));
            Assert.That(productInStock.Quantity, Is.EqualTo(5));
        }

        [Test]
        public void FindShouldThrowExceptionWhenIndexIsOutOfRange()
        {
            //Arrange 
            this.productStock.Add(this.product);

            Assert.That(
                //Act
                () => this.productStock.Find(1),
                //Assert
                Throws
                .Exception.InstanceOf<IndexOutOfRangeException>()
                .With.Message.EqualTo("Product index does not exist."));
        }

        [Test]
        public void FindShouldThrowExceptionWhenIndexIsBelowZero()
        {
            //Arrange 
            this.productStock.Add(this.product);

            Assert.That(
                //Arrange & Act
                () => this.productStock.Find(-1),
                //Assert
                Throws
                .Exception.InstanceOf<IndexOutOfRangeException>()
                .With.Message.EqualTo("Product index does not exist."));
        }

        [Test]
        public void FindByLabelShouldThrowExceptionWhenLabelIsNull()
        {
            Assert.Throws<ArgumentException>(() => this.productStock.FindByLabel(null), "Productnlabel cannot be null");

            //Assert.That(
            //    () => this.productStock.FindByLabel(null), Throws
            //    .Exception.InstanceOf<ArgumentException>().With.Message.EqualTo("Product label cannot be null"));
        }

        [Test]
        public void FindByLabelShouldThrowExceptionWhenLabelDoesNotExist()
        {
            //Arrange
            const string invalidLabel = "Invalid label.";

            Assert.That(
                //Act
                () => this.productStock.FindByLabel(invalidLabel),
                //Assert
                Throws
                .Exception.InstanceOf<ArgumentException>().With.Message.EqualTo($"Product with {invalidLabel} label could not be found."));
        }

        [Test]
        public void FindByLabelShouldReturnCorrectProduct()
        {
            //Arrange
            this.productStock.Add(this.product);
            this.productStock.Add(this.anotherProduct);

            //Act
            var productInStock = this.productStock.FindByLabel(ProductLabel);

            //Assert
            Assert.That(productInStock, Is.Not.Null);
            Assert.That(productInStock.Label, Is.EqualTo(ProductLabel));
            Assert.That(productInStock.Price, Is.EqualTo(10));
            Assert.That(productInStock.Quantity, Is.EqualTo(1));
        }

        [Test]
        public void FindAllInPriceRangeShouldReturnEmptyCollectionWhenNoProductMatch()
        {
            //Arrange
            this.AddMultipleProductsToProductStock();

            //Act
            var result = this.productStock.FindAllInRange(30, 50);

            //Assert
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void FindAllInPriceRangeShouldReturnCorrectCollectionWithCorrectOrder()
        {
            //Arrange
            this.AddMultipleProductsToProductStock();

            //Act
            var result = this.productStock.FindAllInRange(4, 21).ToList();

            //Assert
            Assert.That(result.Count, Is.EqualTo(3));
            Assert.That(result[0].Price, Is.EqualTo(20));
            Assert.That(result[1].Price, Is.EqualTo(10));
            Assert.That(result[2].Price, Is.EqualTo(5));
        }

        [Test]
        public void FindAllByPriceShouldReturnEmptyCollectionWhenNoProductMatch()
        {
            //Arrange
            this.AddMultipleProductsToProductStock();

            //Act
            var result = this.productStock.FindAllByPrice(30);

            //Assert
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void FindAllByPriceShouldReturnCorrectCollection()
        {
            //Arrange
            this.AddMultipleProductsToProductStock();

            //Act
            var result = this.productStock.FindAllByPrice(400).ToList();

            //Assert
            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result[0].Label, Is.EqualTo("4"));
            Assert.That(result[1].Label, Is.EqualTo("5"));
        }

        [Test]
        public void FindMostExpensiveProductShouldThrowExceptionWhenProductStockIsEmpty()
        {
            Assert.That(
                () => this.productStock.FindMostExpensiveProduct(),
                Throws
                .Exception.InstanceOf<InvalidOperationException>()
                .With.Message.EqualTo("Product stock is empty."));
        }

        [Test]
        public void FindMostExpensiveProductShouldReturnCorrectProduct()
        {
            //Arrange
            this.AddMultipleProductsToProductStock();

            //Act
            var productInStock = this.productStock.FindMostExpensiveProduct();

            //Assert
            Assert.That(productInStock, Is.Not.Null);
            Assert.That(productInStock.Label, Is.EqualTo("4"));
            Assert.That(productInStock.Price, Is.EqualTo(400));
            Assert.That(productInStock.Quantity, Is.EqualTo(4));
        }

        [Test]
        public void FindAllByQuantityShouldReturnEmptyCollectionWhenNoProductMatch()
        {
            //Arrange
            this.AddMultipleProductsToProductStock();

            //Act
            var result = this.productStock.FindAllByQuantity(6);

            //Assert
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void FindAllByQuantityShouldReturnCorrectCollection()
        {
            //Arrange
            this.AddMultipleProductsToProductStock();

            //Act
            var result = this.productStock.FindAllByQuantity(5).ToList();

            //Assert
            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result[0].Label, Is.EqualTo("5"));
        }

        [Test]
        public void GetEnumeratorShouldReturnCorrectInsertionOrder()
        {
            //Arrange
            this.AddMultipleProductsToProductStock();

            //Act
            var result = this.productStock.ToList();

            //Assert
            Assert.That(result[0].Label, Is.EqualTo("1"));
            Assert.That(result[1].Label, Is.EqualTo("2"));
            Assert.That(result[2].Label, Is.EqualTo("3"));
            Assert.That(result[3].Label, Is.EqualTo("4"));
            Assert.That(result[4].Label, Is.EqualTo("5"));
        }

        [Test]
        public void GetIndexShouldReturnCorrectProductByIndex()
        {
            //Arrange
            this.productStock.Add(this.product);
            this.productStock.Add(this.anotherProduct);

            //Act
            var productInStock = this.productStock[1];

            //Assert
            Assert.That(productInStock, Is.Not.Null);
            Assert.That(productInStock.Label, Is.EqualTo(AnotherProductLabel));
            Assert.That(productInStock.Price, Is.EqualTo(20));
            Assert.That(productInStock.Quantity, Is.EqualTo(5));
        }

        [Test]
        public void GetIndexShouldThrowExceptionWhenIndexIsOutOfRange()
        {
            //Arrange
            this.productStock.Add(this.product);

            Assert.That(
                //Act
                () => this.productStock[1], 
                //Assert
                Throws
                .Exception.InstanceOf<IndexOutOfRangeException>()
                .With.Message.EqualTo("Product index does not exist."));
        }

        [Test]
        public void GetIndexShouldThrowExceptionWhenIndexIsBelowZero()
        {
            //Arrange
            this.productStock.Add(this.product);

            Assert.That(
                //Act
                () => this.productStock[-1],
                //Assert
                Throws
                .Exception.InstanceOf<IndexOutOfRangeException>()
                .With.Message.EqualTo("Product index does not exist."));
        }

        [Test]
        public void SetIndexShouldChangeProduct()
        {
            const string productLabel = "Yet Another Test";
            //Arrange
            this.AddMultipleProductsToProductStock();

            //Act
            this.productStock[3] = new Product(productLabel, 50, 3);

            //Assert
            var productInStock = this.productStock.Find(3);

            Assert.That(productInStock, Is.Not.Null);
            Assert.That(productInStock.Label, Is.EqualTo(productLabel));
            Assert.That(productInStock.Price, Is.EqualTo(50));
            Assert.That(productInStock.Quantity, Is.EqualTo(3));
        }

        [Test]
        public void SetIndexShouldThrowExceptionWhenIndexIsOutOfRange()
        {
            //Arrange
            this.productStock.Add(this.product);

            Assert.That(
                //Act
                () => this.productStock[1] = new Product(ProductLabel, 10, 10),
                //Assert
                Throws
                .Exception.InstanceOf<IndexOutOfRangeException>()
                .With.Message.EqualTo("Product index does not exist."));
        }

        [Test]
        public void SetIndexShouldThrowExceptionWhenIndexIsBelowZero()
        {
            //Arrange
            this.productStock.Add(this.product);

            Assert.That(
                //Act
                () => this.productStock[-1] = new Product(ProductLabel, 10, 10),
                //Assert
                Throws
                .Exception.InstanceOf<IndexOutOfRangeException>()
                .With.Message.EqualTo("Product index does not exist."));
        }

        private void AddMultipleProductsToProductStock()
        {
            this.productStock.Add(new Product("1", 10, 1));
            this.productStock.Add(new Product("2", 5, 2));
            this.productStock.Add(new Product("3", 20, 3));
            this.productStock.Add(new Product("4", 400, 4));
            this.productStock.Add(new Product("5", 400, 5));

        }
    }
}
