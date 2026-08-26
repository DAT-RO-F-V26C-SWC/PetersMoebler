using PetersMoeblerLib.model;

namespace TestPetersMoebelLib
{
    public class UnitTestProduct
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void TestProductNoOK(int value)
        {
            // Arrange
            Product product = new Product();
            int expectedProductNo = value;


            // Act
            product.ProductNo = value;
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
            Assert.Throws<ArgumentException>( () => product.ProductNo = -1 );
        }
    }
}
