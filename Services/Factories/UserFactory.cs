using Applications.Abstractions;
using Applications.Models.Dtos;
using Applications.Models.Response;
using Azure;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Applications.Factories {
    internal class UserFactory {

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
                    State = ResponseState.ERROR.ToString()
                };
            } else {
                return new UserResponse() {
                    State = ResponseState.SUCCESS.ToString(),
                    Claims = [
                         new Claim("Name", user.Name),
                        new Claim("Surname", user.Surname),
                        new Claim("Email", user.Email),
                        new Claim("Role", user.Role.ToString()),
                        new Claim("Id", user.Id.ToString())
                    ]
                };
            }
        }

    }
}
