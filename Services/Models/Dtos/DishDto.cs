using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications.Models.Dtos {
    public class DishDto {
        public string Name { get; set; } = string.Empty;
        public float Price { get; set; }
        public Dish_Type Type { get; set; }
        public int Portions { get; set; }
    }
}
