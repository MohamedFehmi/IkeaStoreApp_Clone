using System;
namespace IkeaStore.Models
{
    public class Product
    {
        public string Name { get; set; }

        public string Details { get; set; }

        public double[] Dimensions { get; set; }

        public string Image { get; set; }

        public double Price { get; set; }

        public string Currency { get; set; }

        public string Category { get; set; }

        public bool IsLastItemInProducts { get; set; }
    }
}
