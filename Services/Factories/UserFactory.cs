using Applications.Abstractions;
using Applications.Models.Dtos;
using Applications.Models.Response;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications.Factories {
    internal class UserFactory: IFactory<User, UserDto, UserResponse> {

        public User CreateEntity(UserDto dto, int id) {
            return new User() {
                Id = id,
                Name = dto.Name,
                Email = dto.Email,
                Surname = dto.Surname,
                Password = dto.Password,
                Role = dto.Role,
                Orders = new List<Order>()
            };
        }

        public UserResponse CreateResponse(User? user) {
            if(user == null) {
                return new UserResponse() {
                    State = ResponseState.ERROR
                };
            } else {
                return new UserResponse() {
                    State = ResponseState.SUCCESS,
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    Surname = user.Surname
                };
            }
        }

    }
}
