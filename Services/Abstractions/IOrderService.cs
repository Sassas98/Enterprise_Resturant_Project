using Applications.Models.Dtos;
using Applications.Models.Response;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications.Abstractions {
    public interface IOrderService {

        public OrderResponse AddOrder(OrderDto dto);

        public IEnumerable<Order> GetOrders(int id, DateOnly from, DateOnly to);


    }
}
