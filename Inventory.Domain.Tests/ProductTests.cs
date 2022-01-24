using NUnit.Framework;

namespace Inventory.Domain.Tests
{
    public class ProductTests
    {
      
        [Test]
        public void ChangeStatus_FromInStockToDemaged_ReturnsTrue()
        {
            //arrange
            var product = new Product
            {
                Name = "Test",
                Barcode = "123",
                Status = ProductStatus.InStock
            };

            //act
            product.ChangeStatus(ProductStatus.Damaged);

            //assert
            Assert.IsTrue(product.Status == ProductStatus.Damaged);
        }

        [Test]
        public void SellProduct_ProductStatusIsInStock_ProductStatusIsSold()
        {
            //arrange
            var product = new Product
            {
                Name = "Test",
                Barcode = "123",
                Status = ProductStatus.InStock
            };

            //act
            product.Sell();

            //assert
            Assert.IsTrue(product.Status == ProductStatus.Sold);
        }

        [Test]
        public void SellProduct_ProductStatusIsDamaged_ProductStatusWillNotChange()
        {
            //arrange
            var product = new Product
            {
                Name = "Test",
                Barcode = "123",
                Status = ProductStatus.Damaged
            };

            //act
            product.Sell();

            //assert
            Assert.IsTrue(product.Status == ProductStatus.Damaged);
        }

        [Test]
        public void SellProduct_ProductStatusIsInStock_ProductStatusWillBeSold()
        {
            //arrange
            var product = new Product
            {
                Name = "Test",
                Barcode = "123",
                Status = ProductStatus.InStock
            };

            //act
            product.Sell();

            //assert
            Assert.IsTrue(product.Status == ProductStatus.Sold);
        }

    }
}