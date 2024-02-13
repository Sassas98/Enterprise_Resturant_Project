using Applications.Abstractions;
using Applications.Factories;
using Applications.Models.Authentication;
using Applications.Models.Dtos;
using Applications.Models.Response;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Models.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Applications.Services {
    public class UserService : IUserService {

        private readonly UserRepository _userRepository;
        private UserFactory _userFactory;
        private readonly JwtAuthenticationOption _jwtAuthOption;

        public UserService(UserRepository userRepository, IOptions<JwtAuthenticationOption> jwtAuthOption) {
            _userRepository = userRepository;
            _userFactory = new UserFactory();
            _jwtAuthOption = jwtAuthOption.Value;
        }

        public string LogIn(string email, string password) {
            var user = this._userRepository.Get(email, password);
            var response =  this._userFactory.CreateResponse(user);
            if(response.State == "ERROR") {
                return string.Empty;
            }
            var securityToken = GetSecurityToken(response);
            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }

        //creo il token di sicurezza
        private JwtSecurityToken GetSecurityToken(UserResponse response) {
            return new JwtSecurityToken(_jwtAuthOption.Issuer,
                null,
                response.Claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: GetCredentials()
            );
        }

        //genero le credenziali
        private SigningCredentials GetCredentials() {
            var securityKey = new SymmetricSecurityKey(
               Encoding.UTF8.GetBytes(_jwtAuthOption.Key)
           );
           return new SigningCredentials(securityKey, 
               SecurityAlgorithms.HmacSha256);
        }

        public bool SignIn(UserDto dto) {
            if (this._userRepository.AlreadyTaken(dto.Email))
                return false;
            int id = this._userRepository.GetNewId();
            var user = this._userFactory.CreateEntity(dto, id);
            this._userRepository.Add(user);
            this._userRepository.Save();
            return true;
        }
    }
}
