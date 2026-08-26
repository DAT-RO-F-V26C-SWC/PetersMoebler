using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetersMoeblerLib.model
{
    public class Chair : Product
    {
        // instans felter
        private List<String> _materials;
        private int _height;
        private int _width;
        private int _depth;

        // konstruktør
        public Chair() : this(0, "this is dummy", 10, new List<string>() { "Dummy"}, 50, 30, 50)
        {
        }

        public Chair(int productNo, string name, int price, List<string> materials, int height, int width, int depth):base(productNo, name, price)
        {
            Materials = materials;
            Height = height;
            Width = width;
            Depth = depth;
        }

        // properties
        public List<String> Materials
        {
            get { return _materials; }
            set
            {
                if (value is null || value.Count < 1)
                {
                    throw new ArgumentException("Der skal være mindst et materiale");
                }
                _materials = value;
            }
        }
        public int Height
        {
            get { return _height; }
            set
            {
                if (value < 50 || 200 < value)
                {
                    throw new ArgumentException("Højde skal være 50 og 200 cm");
                }
                _height = value;
            }
        }

        public int Width
        {
            get { return _width; }
            set
            {
                if (value < 30 || 130 < value)
                {
                    throw new ArgumentException("Bredde skal være 30 og 130 cm");
                }
                _width = value;
            }
        }
        
        public int Depth    
        {
            get { return _depth; }
            set
            {
                if (value < 50 || 140 < value)
                {
                    throw new ArgumentException("Højde skal være 50 og 140 cm");
                }
                _depth = value;
            }
        }

        public override string ToString()
        {
            return $"{{{nameof(ProductNo)}={ProductNo.ToString()}, {nameof(Name)}={Name}, {nameof(Price)}={Price.ToString()}, {nameof(Materials)}=[{String.Join(" ", Materials)}], {nameof(Height)}={Height.ToString()}, {nameof(Width)}={Width.ToString()}, {nameof(Depth)}={Depth.ToString()}}}";
        }
    }
}
