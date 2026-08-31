using PetersMoeblerLib.model;

namespace TestPetersMoebelLib
{
    public class UnitTestProduct
    {

        /*
         * ProductNo
         */
        [Fact]
        public void TestProductNoOK()
        {
            // Arrange
            Product product = new Product();
            int expectedProductNo = 0;


            // Act
            product.ProductNo = 0;
            int actualProductNo = product.ProductNo;


            // Assert
            Assert.Equal(expectedProductNo, actualProductNo);
        }



        [Fact]
        public void TestProductNoNotOK()
        {
            // Arrange
            Product product = new Product();
            //int expectedProductNo = 0;


            // Act
            //product.ProductNo = 0;
            //int actualProductNo = product.ProductNo;


            // Act + Assert
            Assert.Throws<ArgumentException>(() => product.ProductNo = -1);
        }


        /*
         * price
         */
        [Fact]
        public void TestPriceOK()
        {
            // Arrange
            Product product = new Product();
            int expectedPrice = 10;


            // Act
            product.Price = 10;
            int actualPrice = product.Price;


            // Assert
            Assert.Equal(expectedPrice, actualPrice);
        }



        [Fact]
        public void TestPriceNotOK()
        {
            // Arrange
            Product product = new Product();


            // Act + Assert
            Assert.Throws<ArgumentException>(() => product.Price = 9);
        }

        /*
         * Name
         */
        [Fact]
        public void TestNameOK()
        {
            // Arrange
            Product product = new Product();
            string expectedName = "1234567"; // 7 tegn


            // Act
            product.Name = "1234567";
            string actualName = product.Name;


            // Assert
            Assert.Equal(expectedName, actualName);
        }



        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("123456")]
        [InlineData("         ")]
        [InlineData("         p")]
        public void TestNameNotOK(string name)
        {
            // Arrange
            Product product = new Product();


            // Act + Assert
            Assert.Throws<ArgumentException>(() => product.Name = name);
        }



        /*
         * constructor
         */
        [Fact]
        public void TestConstructorOK()
        {
            // Arrange
            int expectedProductNo = 1;
            string expectedName = "1234567";
            int expectedPrice = 10;

            // Act  - parametre constructor
            Product product = new Product(expectedProductNo, expectedName, expectedPrice);

            // Assert
            Assert.Equal(expectedProductNo, product.ProductNo);
            Assert.Equal(expectedName, product.Name);
            Assert.Equal(expectedPrice, product.Price);

            // Act  - default constructor
            Product productDefault = new Product();
            productDefault.Name = "1234567";
            productDefault.Price = 10;
            productDefault.ProductNo = 1;

            // Assert
            Assert.Equal(expectedProductNo, productDefault.ProductNo);
            Assert.Equal(expectedName, productDefault.Name);
            Assert.Equal(expectedPrice, productDefault.Price);

        }

        [Fact]
        public void TestConstructorNotOK()
        {
            // Arrange
            int errorProductNo = -1;
            string errorName = "123456";
            int errorPrice = 9;

            // Act + Assert  - parametre constructor
            Assert.Throws<ArgumentException>(() => new Product(errorProductNo, "1234567", 10));
            Assert.Throws<ArgumentException>(() => new Product(1, errorName, 10));
            Assert.Throws<ArgumentException>(() => new Product(1, "1234567", errorPrice));

        }
    }
}
