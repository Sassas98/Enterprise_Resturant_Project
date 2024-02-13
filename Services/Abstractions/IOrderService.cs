using Applications.Models.Dtos;
using Applications.Models.Request;
using Applications.Models.Response;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications.Abstractions {
    public interface IOrderService {

        public OrderResponse AddOrder(OrderDto dto, int userId);

        public List<RecordOrderResponse> GetOrders(RecordOrderRequest request, int id);


    }
}
