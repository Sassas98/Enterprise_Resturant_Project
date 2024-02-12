using Applications.Abstractions;
using Applications.Factories;
using Applications.Models.Dtos;
using Applications.Models.Response;
using Models.Entities;
using Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications.Services {
    public class RestaurantService : IUserService, IOrderService {

        private UserRepository _userRepository;
        private OrderRepository _orderRepository;
        private DishRepository _dishRepository;
        private UserFactory _userFactory;
        private OrderFactory _orderFactory;

        public RestaurantService(UserRepository userRepository, OrderRepository orderRepository, DishRepository dishRepository) {
            _userRepository = userRepository;
            _orderRepository = orderRepository;
            _dishRepository = dishRepository;
            _userFactory = new UserFactory();
            _orderFactory = new OrderFactory();
        }

        public IEnumerable<Order> GetOrders(int id, DateOnly from, DateOnly to) {
            var user = _userRepository.Get(id);
            if(user == null) 
                return new List<Order>();
            else if (user.Role == User_Role.ADMIN)
                return FromToOrders(_orderRepository.GetAll(), from, to);
            else 
                return FromToOrders(user.Orders, from, to);
        }

        private IEnumerable<Order> FromToOrders (IEnumerable<Order> orders, DateOnly from, DateOnly to) {
            return orders.Where(x => x.Date >= from && x.Date <= to);
        }

        public UserResponse LogIn(string email, string password) {
            var user = this._userRepository.Get(email, password);
            return this._userFactory.CreateResponse(user);
        }

        public void SignIn(UserDto dto) {
            int id = this._userRepository.GetNewId();
            var user = this._userFactory.CreateEntity(dto, id);
            this._userRepository.Add(user);
            this._userRepository.Save();
        }

        public OrderResponse AddOrder(OrderDto dto) {
            int id = this._orderRepository.GetNewId();
            var order = this._orderFactory.CreateEntity(dto, id);
            id = this._dishRepository.GetNewId();
            order.Dishes.ToList().ForEach(dish => dish.Id = id++);
            this._orderRepository.Add(order);
            this._orderRepository.Save();
            order.Dishes.ToList().ForEach(dish => _dishRepository.Add(dish));
            this._dishRepository.Save();
            return this._orderFactory.CreateResponse(order);
        }
    }
}
