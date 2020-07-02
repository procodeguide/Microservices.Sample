using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProCodeGuide.Sample.Microservice.Model;
using ProCodeGuide.Sample.Microservice.Repository;
using Serilog;

namespace ProCodeGuide.Sample.Microservice.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderRepository _orderRepository;
        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult> Add([FromBody] Order orderdet)
        {
            try
            {
                Log.Debug("Order Addition Started");
                Log.Debug("Order Addition Input", orderdet);
                string orderid = await _orderRepository.Add(orderdet);
                Log.Debug("Order Addition Output", orderid);
                return Ok(orderid);
            }
            catch (Exception ex)
            {
                Log.Error("Order Addition Failed", ex);
                throw new Exception("Order Addition Failed", innerException: ex);
            }
        }

        [HttpGet]
        [Route("GetByCustomerId/{id}")]
        public async Task<ActionResult> GetByCustomerId(string id)
        {
            var orders = await _orderRepository.GetByCustomerId(id);
            return Ok(orders);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<ActionResult> GetById(string id)
        {
            var orderdet = await _orderRepository.GetById(id);
            return Ok(orderdet);
        }

        [HttpDelete]
        [Route("Cancel/{id}")]
        public async Task<IActionResult> Cancel(string id)
        {
            string resp = await _orderRepository.Cancel(id);
            return Ok(resp);
        }
    }
}
