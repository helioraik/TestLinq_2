using System.Globalization;

namespace TestLinq_2.Entities
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public Category Category { get; set; }

        public Product()
        {
        }

        public Product(int id, string name, double price)
        {
            ID = id;
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return ID
                   + ", "
                   + Name
                   + ", "
                   + Price.ToString("F2", CultureInfo.InvariantCulture)
                   + ", "
                   + Category.Name
                   + ", "
                   + Category.Tier;
        }
    }
}