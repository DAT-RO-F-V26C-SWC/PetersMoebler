using PetersMoeblerLib.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPetersMoebelLib
{
    public class UnitChair
    {
        /*
         * height       50-200
         */

        [Theory]
        [InlineData(50)]
        [InlineData(200)]
        public void TestHeightOK(int value)
        {
            // Arrange
            Chair product = new Chair();
            int expectedHeight = value;


            // Act
            product.Height = value;
            int actualHeight = product.Height;


            // Assert
            Assert.Equal(expectedHeight, actualHeight);
        }

        [Theory]
        [InlineData(49)]
        [InlineData(201)]
        public void TestHeightNotOK(int value)
        {
            // Arrange
            Chair product = new Chair();

            // Act + Assert
            Assert.Throws<ArgumentException>(() => product.Height = value);
        }

        /*
         * width       30-130
         */

        [Theory]
        [InlineData(30)]
        [InlineData(130)]
        public void TestWidthOK(int value)
        {
            // Arrange
            Chair product = new Chair();
            int expectedWidth = value;


            // Act
            product.Width = value;
            int actualWidth = product.Width;


            // Assert
            Assert.Equal(expectedWidth, actualWidth);
        }

        [Theory]
        [InlineData(29)]
        [InlineData(131)]
        public void TestWidthNotOK(int value)
        {
            // Arrange
            Chair product = new Chair();

            // Act + Assert
            Assert.Throws<ArgumentException>(() => product.Width = value);
        }

        /*
         * depth       50-140
         */

        [Theory]
        [InlineData(50)]
        [InlineData(140)]
        public void TestDepthOK(int value)
        {
            // Arrange
            Chair product = new Chair();
            int expectedDepth = value;

            // Act
            product.Depth = value;
            int actualDepth = product.Depth;

            // Assert
            Assert.Equal(expectedDepth, actualDepth);
        }

        [Theory]
        [InlineData(49)]
        [InlineData(141)]
        public void TestDepthNotOK(int value)
        {
            // Arrange
            Chair product = new Chair();

            // Act + Assert
            Assert.Throws<ArgumentException>(() => product.Depth = value);
        }



        /*
         * materials       mindst en
         */
        public static IEnumerable<object[]> MaterialsDataOK()
        {
            yield return new object[] { new List<string> { "wood" } };
            yield return new object[] { new List<string> { "metal", "plastic" } };
        }

        [Theory]
        [MemberData(nameof(MaterialsDataOK))]
        public void TestMaterialsOK(List<String> value)
        {
            // Arrange
            Chair product = new Chair();
            int expectedLength = value.Count;

            // Act
            product.Materials = value;
            int actualLength = product.Materials.Count;

            // Assert
            Assert.Equal(expectedLength, actualLength);
        }



        [Fact]
        public void TestMaterialsNotOKNull()
        {
            // Arrange
            Chair product = new Chair();

            // Act + Assert
            Assert.Throws<ArgumentException>(() => product.Materials = null);
        }

        [Fact]
        public void TestMaterialsNotOKempty()
        {
            // Arrange
            Chair product = new Chair();
            List<string> emptyList = new List<string>();

            // Act + Assert
            Assert.Throws<ArgumentException>(() => product.Materials = emptyList);
        }


        /*
         * Konstruktør
         */
        [Fact]
        public void TestConstructorOK()
        {
            // Arrange
            int expectedProductNo = 1;
            string expectedName = "1234567";
            int expectedPrice = 10;
            int expectedHeight = 100;
            int expectedWidth = 100;
            int expectedDepth = 100;
            List<string> expectedMaterials = new List<string> { "wood" };


            // Act  - parametre constructor
            Chair chair = new Chair(expectedProductNo, expectedName, expectedPrice, expectedMaterials, expectedHeight, expectedWidth, expectedDepth);

            // Assert
            Assert.Equal(expectedProductNo, chair.ProductNo);
            Assert.Equal(expectedName, chair.Name);
            Assert.Equal(expectedPrice, chair.Price);
            Assert.Equal(expectedHeight, chair.Height);
            Assert.Equal(expectedWidth, chair.Width);
            Assert.Equal(expectedDepth, chair.Depth);
            Assert.Equal(expectedMaterials, chair.Materials);



            // Act  - default constructor
            Chair chairDefault = new Chair();
            chairDefault.Name = "1234567";
            chairDefault.Price = 10;
            chairDefault.ProductNo = 1;
            chairDefault.Height = 100;
            chairDefault.Width = 100;
            chairDefault.Depth = 100;
            chairDefault.Materials = new List<string> { "wood" };

            // Assert
            Assert.Equal(expectedProductNo, chairDefault.ProductNo);
            Assert.Equal(expectedName, chairDefault.Name);
            Assert.Equal(expectedPrice, chairDefault.Price);
            Assert.Equal(expectedHeight, chairDefault.Height);
            Assert.Equal(expectedWidth, chairDefault.Width);
            Assert.Equal(expectedDepth, chairDefault.Depth);
            Assert.Equal(expectedMaterials, chairDefault.Materials);
        }

        [Fact]
        public void TestConstructorNotOK()
        {
            // Arrange
            int errorProductNo = -1;
            string errorName = "123456";
            int errorPrice = 9;
            int errorHeight = 49;
            int errorWidth = 29;
            int errorDepth = 141;
            List<string> errorMaterials = new List<string> ();

            // Act + Assert  - parametre constructor
            Assert.Throws<ArgumentException>(() => new Chair(errorProductNo, "1234567", 10, new List<string> { "wood" }, 100,100,100));
            Assert.Throws<ArgumentException>(() => new Chair(1, errorName, 10, new List<string> { "wood" }, 100, 100, 100));
            Assert.Throws<ArgumentException>(() => new Chair(1, "1234567", errorPrice, new List<string> { "wood" }, 100, 100, 100));
            Assert.Throws<ArgumentException>(() => new Chair(1, "1234567", 10, errorMaterials, 100, 100, 100));
            Assert.Throws<ArgumentException>(() => new Chair(1, "1234567", 10, new List<string> { "wood" }, errorHeight, 100, 100));
            Assert.Throws<ArgumentException>(() => new Chair(1, "1234567", 10, new List<string> { "wood" }, 100, errorWidth, 100));
            Assert.Throws<ArgumentException>(() => new Chair(1, "1234567", 10, new List<string> { "wood" }, 100, 100, errorDepth));

        }

    }
}
