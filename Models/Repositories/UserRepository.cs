using Microsoft.EntityFrameworkCore;
using Models.Context;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repositories {
    public class UserRepository : GenericRepository<User> {

        public UserRepository(RestaurantContext ctx) : base(ctx) { }

        public override User? Get(int id) {
            return _ctx.Users
                .Include(x => x.Orders)
                .FirstOrDefault(x => x.Id == id);
        }

        public User? Get(string email, string password) {
            return _ctx.Users
                .Include(x => x.Orders)
                .Where(x => x.Email == email)
                .FirstOrDefault(x => x.Password == password); ;
        }

    }
}
