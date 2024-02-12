using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities {
    public class Order : Entity {
        public User User { get; set; } = null!;
        public int UserId { get; set; }
        public DateOnly Date {get; set;}
        public IEnumerable<Dish> Dishes { get; set; } = null!;
    }
}
