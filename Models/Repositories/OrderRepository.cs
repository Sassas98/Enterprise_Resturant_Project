using Microsoft.EntityFrameworkCore;
using Models.Context;
using Models.Entities;

namespace Models.Repositories {
    public class OrderRepository : GenericRepository<Order> {

        public OrderRepository(RestaurantContext ctx) : base(ctx) { }

        public override Order? Get(int id) {
            return GetAll()
                .FirstOrDefault(x => x.Id == id);
        }

        public List<Order> GetAll() {
            return _ctx.Orders
                .Include(x => x.User)
                .Include(x => x.Dishes)
                .ToList();
        }

        public List<Order> GetAllFromUser(int userId) {
            return GetAll().Where(x => x.UserId == userId).ToList();
        }

    }
}
