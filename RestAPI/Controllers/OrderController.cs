using Applications.Abstractions;
using Applications.Models.Dtos;
using Applications.Models.Request;
using Applications.Models.Response;
using Applications.Services;
using Azure.Core;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using System.Security.Claims;

namespace RestAPI.Controllers {
    [ApiController]
    [Route("api/v1/[controller]/order")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class OrderController : ControllerBase {

        IOrderService _orderService;

        public OrderController(IOrderService orderService) {
            this._orderService = orderService;
        }


        [HttpPost]
        [Route("add")]
        public IActionResult AddOrder(OrderDto order) {
            int? Id = GetUserId();
            if (Id == null)
                Unauthorized();
            var response = _orderService.AddOrder(order, Id ?? 0);
            if (response.State == "SUCCESS")
                return Ok(response);
            return BadRequest();
        }

        [HttpPost]
        [Route("get")]
        public IActionResult GetOrders(RecordOrderRequest request) {
            int? Id = GetUserId();
            if(Id == null)
                Unauthorized();
            var response = _orderService.GetOrders(request, Id ?? 0);
            return Ok(response);
        }

        private int? GetUserId() {
            var identity = User.Identity as ClaimsIdentity;
            if (identity != null) {
                var userIdClaim = identity.FindFirst(c => c.Type == "Id");
                if (userIdClaim != null) {
                    return int.Parse(userIdClaim.Value);
                }
            }
            return null;
        }
    }
}
