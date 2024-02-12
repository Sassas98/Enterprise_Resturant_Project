using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculation.Models {
    internal class Product {
        public float price { get; set; }
        public Dish_Type type { get; set; }
    }
}
