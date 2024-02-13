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
    internal class OrderFactory {

        private PriceCalculator _calculator;

        public OrderFactory() {
            _calculator = new PriceCalculator();
        }

        public Order CreateEntity(OrderDto dto, int id, int userId) {
            List<Dish> dishes = dto.Dishes.Select(x => {
                return new Dish() {
                    Name = x.Name,
                    Price = x.Price,
                    Portions = x.Portions,
                    Type = x.Type,
                    OrderId = id
                };
            }).ToList();
            return new Order() {
                Id = id,
                Date = dto.Date,
                UserId = userId,
                Dishes = dishes
            };
        }

        public OrderResponse CreateResponse(Order? order) {
            if (order == null) {
                return new OrderResponse() {
                    State = ResponseState.ERROR.ToString()
                };
            } else {
                return new OrderResponse() {
                    State = ResponseState.SUCCESS.ToString(),
                    idOrder = order.Id,
                    total = _calculator.CalculatePrice(order.Dishes)
                };
            }
        }
    }
}
