using System.Net;
using AutoMapper;
using Auxo.Models.Dtos.Requests;
using Auxo.Models.Dtos.Responses;
using Auxo.Services;
using Microsoft.AspNetCore.Mvc;

namespace Auxo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        private readonly IMapper _mapper;


        public OrdersController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> PostOrders([FromBody] OrdersRequest ordersRequest)
        {
            if(ordersRequest == null || ordersRequest.LineItems == null || ordersRequest.LineItems.Count == 0) 
            {
                return BadRequest("Mandatory fields are invalid.");
            }
            var order = await _orderService.PostOrders(ordersRequest);
            return Ok(_mapper.Map<OrderResponse>(order));
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _orderService.GetOrders();
            return Ok(_mapper.Map<List<OrderResponse>>(orders));
        }
    }
}
