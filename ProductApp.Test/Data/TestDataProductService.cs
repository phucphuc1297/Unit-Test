using ProductApp.Models;

namespace ProductApp.Tests.Data
{
    public class TestDataProductService
    {
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
    }
}
