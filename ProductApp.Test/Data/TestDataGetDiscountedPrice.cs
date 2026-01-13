using ProductApp.Models;
using System.Collections;

namespace ProductApp.Tests.Data
{
    public class TestDataGetDiscountedPrice : IEnumerable<object[]>
    {
        private readonly List<object[]> _testData = new List<object[]>
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

        public IEnumerator<object[]> GetEnumerator()
        {
            return _testData.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
