using ProductApp.Models;
using ProductApp.Tests.Data;

namespace ProductApp.Tests
{
    public class ProductHelperShould
    {
        #region Fact Attribute

        [Fact]
        public void IsOnSale_DiscountEqualZero_ReturnFalse()
        {
            // Arrange
            int discount = 0;

            // Act
            bool actualResult = ProductHelper.IsOnSale(discount);

            // Assert
            Assert.False(actualResult);
        }

        [Fact]
        public void IsOnSale_DiscountLargerThan100_ThrowException()
        {
            // Arrange
            int discount = 100;

            // Act
            Action actualResult = () => ProductHelper.IsOnSale(discount);

            // Assert
            ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(actualResult);
            Assert.Equal("Discount must be larger than 0 and less than 100", exception.ParamName);
        }

        [Fact(DisplayName = "Display Name Skip Test", Skip = "Skip this test because some reason")]
        public void Skip_Test()
        {
            // Arrange

            // Act
            
            // Assert
        }

        #endregion

        #region Theory Attribute - InlineData

        [Theory]
        [InlineData(1, true)]
        [InlineData(50, true)]
        //[InlineData(50, false)]
        public void IsOnSale_DiscountLargerThan0LessThan100_ReturnTrue(int discount, bool expectedResult)
        {
            // Arrange and Act
            bool actualResult = ProductHelper.IsOnSale(discount);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        //[Theory]
        //[InlineData(new Product("1", "C20/30", 100, 0), 100)]
        //public void GetDiscountedPrice_InlineData(Product product, int expectedResult)
        //{
        //    // Arrange and Act
        //    double actualResult = ProductHelper.GetDiscountedPrice(product);

        //    // Assert
        //    Assert.Equal(expectedResult, actualResult);
        //}

        [Theory]
        [InlineData("1", "C20/30", 100, 0, 100)]
        [InlineData("2", "C25/35", 450, 50, 225)]
        public void GetDiscountedPrice_InlineData(string productId, string productName, double price, int discount, double expectedResult)
        {
            // Arrange
            Product product = new Product(productId, productName, price, discount);

            // Act
            double actualResult = ProductHelper.GetDiscountedPrice(product);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        #endregion

        #region Theory Attribute - ClassData

        [Theory]
        [ClassData(typeof(TestDataGetDiscountedPrice))]
        public void GetDiscountedPrice_ClassData(Product product, double expectedResult)
        {
            // Arrange and Act
            double actualResult = ProductHelper.GetDiscountedPrice(product);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        #endregion

        #region Theory Attribute - MemberData - Property - on the test class

        [Theory]
        [MemberData(nameof(GetDiscountedPriceData))]
        public void GetDiscountedPrice_MemberDataProperty(Product product, double expectedResult) 
        {
            // Arrange and Act
            double actualResult = ProductHelper.GetDiscountedPrice(product);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        public static IEnumerable<object[]> GetDiscountedPriceData
        {
            get
            {
                return new List<object[]>
                {
                    new object[]
                    {
                        new Product("1", "C20/30", 100, 0),
                        100
                    },
                    new object[]
                    {
                        new Product("2", "C25/35", 450, 50),
                        225
                    }
                };
            }
        }

        #endregion

        #region Theory Attribute - MemberData - Method - on the test class

        [Theory]
        [MemberData(nameof(GetDiscountedPriceDataMethod), parameters: 1)]
        public void GetDiscountedPrice_MemberDataMethod(Product product, double expectedResult)
        {
            // Arrange and Act
            double actualResult = ProductHelper.GetDiscountedPrice(product);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        public static IEnumerable<object[]> GetDiscountedPriceDataMethod(int numTests)
        {
            var allData = new List<object[]>
            {
                new object[]
                {
                    new Product("1", "C20/30", 100, 0),
                    100
                },
                new object[]
                {
                    new Product("2", "C25/35", 450, 50),
                    225
                }
            };

            return allData.Take(numTests);
        }

        #endregion

        #region Theory Attribute - MemberData - Property and Method - on a different class

        [Theory]
        [MemberData(nameof(TestDataProductService.GetDiscountedPriceData), MemberType = typeof(TestDataProductService))]
        public void GetDiscountedPrice_MemberDataPropertyDiffClass(Product product, double expectedResult)
        {
            // Arrange and Act
            double actualResult = ProductHelper.GetDiscountedPrice(product);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [MemberData(nameof(TestDataProductService.GetDiscountedPriceDataMethod), parameters: 1, MemberType = typeof(TestDataProductService))]
        public void GetDiscountedPrice_MemberDataMethodDiffClass(Product product, double expectedResult)
        {
            // Arrange and Act
            double actualResult = ProductHelper.GetDiscountedPrice(product);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        #endregion
    }
}