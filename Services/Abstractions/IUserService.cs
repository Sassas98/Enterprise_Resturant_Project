using Applications.Models.Dtos;
using Applications.Models.Response;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications.Abstractions {
    public interface IUserService {

        public void SignIn(UserDto dto);

        public UserResponse LogIn(string email, string password);

    }
}
