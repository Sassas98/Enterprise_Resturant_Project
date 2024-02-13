using Applications.Models.Dtos;
using Applications.Models.Response;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications.Factories {
    internal class RecordOrderFactory {
        public RecordOrderResponse MakeOrderData(Order order) {
            return new RecordOrderResponse() {
                UserId = order.UserId,
                Date = order.Date,
                Dishes = order.Dishes.Select(x => MakeDishData(x)).ToList(),
            };
        }

        private RecordDishResponse MakeDishData(Dish dish) {
            return new RecordDishResponse() {
                Name = dish.Name + "x" + dish.Portions,
                Price = dish.Price * dish.Portions,
                Type = dish.Type.ToString()
            };
        }
    }
}
