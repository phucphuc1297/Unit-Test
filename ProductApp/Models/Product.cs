namespace ProductApp.Models
{
    public class Product
    {
        private string _id;
        private string _productName;
        private double _price;
        private int _discountPercentage;

        public Product()
        {
        }

        public Product(string id, string name, double price, int discount)
        {
            _id = id;
            _productName = name;
            _price = price;
            _discountPercentage = discount;
        }

        public string Id { get { return _id; } set { _id = value; } }
        public string ProductName { get { return _productName; } set { _productName = value; } }
        public double Price { get { return _price; } set { _price = value; } }
        public int DiscountPercentage { get { return _discountPercentage; } set { _discountPercentage = value; } }
    }
}
