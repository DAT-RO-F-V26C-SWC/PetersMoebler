using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetersMoeblerLib.model
{
    public class Product
    {
        // instans felter
        private int _productNo;
        private string _name;
        private int _price;

        // konstruktør
        public Product():this(0, "this is dummy", 10)
        {
        }

        public Product(int productNo, string name, int price)
        {
            ProductNo = productNo;
            Name = name;
            Price = price;
        }

        // properties
        public int ProductNo
        {
            get { return _productNo; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Produkt nummer skal være 0 eller positiv.");
                }
                _productNo = value;
            }
        }
        public string Name
        { 
            get { return _name; } 
            set 
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 7)
                {
                    throw new ArgumentException("Produkt navn skal være mindst 7 tegn langt");
                }
                _name = value; } 
        }
        public int Price
        { 
            get { return _price; } 
            set 
            {
                if (value < 10)
                {
                    throw new ArgumentException("Produkt pris skal mindst 10 kr");
                }
                _price = value;
            }
        }

        public override string ToString()
        {
            return $"{{{nameof(ProductNo)}={ProductNo.ToString()}, {nameof(Name)}={Name}, {nameof(Price)}={Price.ToString()}}}";
        }
    }
}
