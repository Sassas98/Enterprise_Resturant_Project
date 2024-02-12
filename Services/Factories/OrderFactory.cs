using Applications.Abstractions;
using Applications.Models.Dtos;
using Applications.Models.Response;
using Models.Entities;
using PriceCalculation.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications.Factories {
    internal class OrderFactory : IFactory<Order, OrderDto, OrderResponse> {

        private PriceCalculator _calculator;

        public OrderFactory() {
            _calculator = new PriceCalculator();
        }

        public Order CreateEntity(OrderDto dto, int id) {
            List<Dish> dishes = dto.Dishes.Select(x => {
                return new Dish() {
                    name = x.name,
                    price = x.price,
                    portions = x.portions,
                    type = x.type,
                    OrderId = id
                };
            }).ToList();
            return new Order() {
                Id = id,
                Date = dto.Date,
                UserId = dto.UserId,
                Dishes = dishes
            };
        }

        public OrderResponse CreateResponse(Order? order) {
            if (order == null) {
                return new OrderResponse() {
                    State = ResponseState.ERROR
                };
            } else {
                return new OrderResponse() {
                    State = ResponseState.SUCCESS,
                    idOrder = order.Id,
                    total = _calculator.CalculatePrice(order.Dishes)
                };
            }
        }
    }
}
