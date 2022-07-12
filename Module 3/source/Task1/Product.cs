using System;

namespace Task1
{
    public class Product : IEquatable<Product>
    {
        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; }

        public double Price { get; }

        public override bool Equals(object obj)
        {
            if (!(obj is Product product)) return false;

            return Equals(product);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Price);
        }

        public bool Equals(Product productToCompare)
        {
            if (productToCompare == null) return false;

            return Name.Equals(productToCompare.Name) && Price.Equals(productToCompare.Price);
        }
    }
}
