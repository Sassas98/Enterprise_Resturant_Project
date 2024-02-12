using Applications.Models.Dtos;
using Applications.Services;
using Models.Context;
using Models.Entities;
using Models.Repositories;

var ctx = new RestaurantContext();
var repo1 = new DishRepository(ctx);
var repo2 = new OrderRepository(ctx);
var repo3 = new UserRepository(ctx);
var service = new RestaurantService(repo3, repo2, repo1);
var user = new UserDto() {
    Email = "Test",
    Name = "Test",
    Surname = "Test",
    Password = "Test",
    Role = User_Role.CLIENT
};
service.SignIn(user);