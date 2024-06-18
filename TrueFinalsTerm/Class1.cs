using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrueFinalsTerm
{
    public class ProductViewModel
    {
        public string ImagePath { get; }
        public string Name { get; }
        public string Description { get; }
        public double Price { get; }


        public ProductViewModel(string imagePath, string name, string description, double price)
        {
            ImagePath = imagePath;
            Name = name;
            Description = description;
            Price = price;
        }
    }
}
