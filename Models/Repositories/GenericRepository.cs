using Microsoft.EntityFrameworkCore;
using Models.Context;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repositories {
    public abstract class GenericRepository<T> where T : Entity {
        protected RestaurantContext _ctx;
        public GenericRepository(RestaurantContext ctx) {
            _ctx = ctx;
        }

        public void Add(T entity) {
            _ctx.Set<T>().Add(entity);
        }

        public void Modify(T entity) {
            _ctx.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public virtual T? Get(int id) {
            return _ctx.Set<T>().Where(x => x.Id == id).FirstOrDefault();

        }

        public void Delete(int id) {
            var entity = Get(id);
            if(entity != null)
                _ctx.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
        }

        public void Save() {
            _ctx.SaveChanges();
        }

        public int GetNewId() {
            var first = _ctx.Set<T>()
                .OrderBy(x => x.Id)
                .Reverse().FirstOrDefault();
            if (first != null)
                return first.Id + 1;
            else return 1;
        }

    }
}
