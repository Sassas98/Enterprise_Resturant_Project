using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications.Models.Dtos {
    public class DishDto {
        public string name { get; set; } = string.Empty;
        public float price { get; set; }
        public Dish_Type type { get; set; }
        public int portions { get; set; }
    }
}
