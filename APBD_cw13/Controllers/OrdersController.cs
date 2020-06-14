using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APBD_cw13.DTOs.Request;
using APBD_cw13.Models;
using APBD_cw13.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD_cw13.Controllers
{
    [Route("api")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IDbService _service;
    

        public OrdersController(IDbService service)
        {
            _service = service;
        }

        [HttpGet("/orders/{nazwisko?}")]
        public IActionResult GetCustomerOrders(string nazwisko = "")
        {
            var result = _service.GetCustomerOrder(nazwisko);
            if (!(result is null))
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("Something went wrong :/");
            }
        }

        [HttpPost("client/{id}/orders")]
        public IActionResult InsertOrder(AddOrderRequest request, int id)
        {

            var res = _service.AddOrder(request, id);

            if (!(res is null))
            {
                return Ok(res);
            }
            else
            {
                return BadRequest(res);
            }

        }

    }
}