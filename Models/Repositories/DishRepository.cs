using Microsoft.EntityFrameworkCore;
using Models.Context;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repositories {
    public class DishRepository : GenericRepository<Dish> {
        public DishRepository(RestaurantContext ctx) : base(ctx) { }

        public override Dish? Get(int id) {
            return _ctx.Dishes
                .Include(x => x.Order)
                .FirstOrDefault(x => x.Id == id);
        }


    }
}
