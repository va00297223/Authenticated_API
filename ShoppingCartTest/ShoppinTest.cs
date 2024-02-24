using ShoppingCart_Model;

namespace ShoppingCartTest
{
    [TestClass]
    public class ShoppinTest
    {
        [TestMethod]
        public void ShoppingCart_CreateInstance()
        {
            // Arrange & Act
            var shoppingCart = new ShoppingCart();

            // Assert
            Assert.IsNotNull(shoppingCart);
        }

        [TestMethod]
        public void ShoppingCart_GettersAndSetters()
        {
            // Arrange & Act
            var shoppingCart = new ShoppingCart();

            // Assert
            Assert.IsNotNull(shoppingCart.Id);
            Assert.IsNotNull(shoppingCart.User);
            Assert.IsNotNull(shoppingCart.Products);
        }

        [TestMethod]
        public void ShoppingCart_UserNotNullByDefault()
        {
            // Arrange
            var shoppingCart = new ShoppingCart();

            // Assert
            Assert.IsNotNull(shoppingCart.User);
        }

        [TestMethod]
        public void ShoppingCart_ProductsListEmptyByDefault()
        {
            // Arrange
            var shoppingCart = new ShoppingCart();

            // Assert
            Assert.AreEqual(0, shoppingCart.Products.Count);
        }

        //

        [TestMethod]
        public void ProductModel_CreateInstance()
        {
            // Arrange & Act
            var product = new Product_Model();

            // Assert
            Assert.IsNotNull(product);
        }

        [TestMethod]
        public void ProductModel_GettersAndSetters()
        {
            // Arrange & Act
            var product = new Product_Model();

            // Assert
            Assert.IsNotNull(product.Id);
            Assert.IsNotNull(product.Price);
            Assert.IsNotNull(product.Name);
            Assert.IsNotNull(product.Description);
            Assert.IsNotNull(product.ProductCategory);
        }

        [TestMethod]
        public void ProductModel_NullByDefault()
        {
            // Arrange
            var product = new Product_Model();

            // Assert
            Assert.IsNull(product.ProductCategory);
        }

        [TestMethod]
        public void ProductModel_NegativePrice()
        {
            // Arrange & Act
            var product = new Product_Model { Price = -10.0m };

            // Assert
            Assert.IsTrue(product.Price >= 0);
        }
    }
}