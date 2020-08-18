using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment01.Contracts;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace Assignment01.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class OrderController : Controller
    {
        IRequestClient<CheckOrderStatus> _client;
        public OrderController(IRequestClient<CheckOrderStatus> client)
        {
            _client = client;
        }
        public async Task<string> Index(string id = "1")
        {
            var response = await _client.GetResponse<OrderStatusResult>(new { OrderId = id });

            return response.Message.StatusText;
        }
    }
}
