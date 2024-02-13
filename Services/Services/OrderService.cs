using Applications.Abstractions;
using Applications.Factories;
using Applications.Models.Dtos;
using Applications.Models.Request;
using Applications.Models.Response;
using Models.Entities;
using Models.Repositories;
using System.Collections.Generic;

namespace Applications.Services {
    public class OrderService : IOrderService {
        private readonly UserRepository _userRepository;
        private readonly OrderRepository _orderRepository;
        private readonly DishRepository _dishRepository;
        private OrderFactory _orderFactory;
        private RecordOrderFactory _recordOrderFactory;

        public OrderService(UserRepository userRepository,
                OrderRepository orderRepository, DishRepository dishRepository) {
            _userRepository = userRepository;
            _orderRepository = orderRepository;
            _dishRepository = dishRepository;
            _orderFactory = new OrderFactory();
            _recordOrderFactory = new RecordOrderFactory();
        }

        public List<RecordOrderResponse> GetOrders(RecordOrderRequest request, int id) {
            var user = _userRepository.Get(id);
            if (user == null)
                return new List<RecordOrderResponse>();
            var list = GetOrders(request, user);
            return Pagination(list, request.PageSize, request.PageNumber);
        }

        //pagina gli ordini in base alla pagina visualizzata
        public List<RecordOrderResponse> Pagination(List<RecordOrderResponse> orders, int pageSize, int pageNumber) {
            var page = new List<RecordOrderResponse>();
            int max = pageSize * (pageNumber + 1);
            if(max - pageSize < orders.Count) {
                for (int i = max - pageSize; i < max && i < orders.Count; i++) {
                    page.Add(orders[i]);
                }
            }
            return page;
        }

        //ritorna gli ordini da vedere
        public List<RecordOrderResponse> GetOrders(RecordOrderRequest request, User user) {
            List<Order> orders;
            if (user.Role == User_Role.ADMIN) {
                if (request.UserId != null)
                    orders = _orderRepository.GetAllFromUser(request.UserId??0);
                else orders = _orderRepository.GetAll();
            } else orders = _orderRepository.GetAllFromUser(user.Id);
            return FromToOrders(orders, request.From, request.To);

        }

        //trova gli ordini tra due date
        private List<RecordOrderResponse> FromToOrders(IEnumerable<Order> orders, DateOnly from, DateOnly to) {
            return orders.Where(x => x.Date >= from && x.Date <= to)
                .Select(x => _recordOrderFactory.MakeOrderData(x)).ToList();
        }

        public OrderResponse AddOrder(OrderDto dto, int userId) {
            int id = this._orderRepository.GetNewId();
            var order = this._orderFactory.CreateEntity(dto, id, userId);
            id = this._dishRepository.GetNewId();
            order.Dishes.ToList().ForEach(dish => dish.Id = id++);
            this._orderRepository.Add(order);
            this._orderRepository.Save();
            return this._orderFactory.CreateResponse(order);
        }

    }
}
