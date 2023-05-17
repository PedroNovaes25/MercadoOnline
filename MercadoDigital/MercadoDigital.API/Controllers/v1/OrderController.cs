using Lib.Exceptions;
using MercadoDigital.Application.DTO.Input;
using MercadoDigital.Application.DTO.Output;
using MercadoDigital.Application.IServices;
using MercadoDigital.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MercadoDigital.API.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;

        }


        [HttpPost("")]
        public async Task<IActionResult> Create(OrderInputDTO OrderDTO)
        {
            try
            {
                var isCreated = await _orderService.Create(OrderDTO);
                if (!isCreated)
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error creating record");

                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating record");
            }
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetOrdersById(int orderId)
        {
            try
            {
                var order = await _orderService.GetOdersById(orderId);
                if (order == null)
                    return NotFound("No existing data.");

                return Ok(order);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error getting record by idPedido");
            }

        }

        [HttpGet("by-user/{id}")]
        public async Task<IActionResult> GetAllOrdersByUserId(int id)
        {
            try
            {
                var order = await _orderService.GetAllOdersByUserId(id);
                return Ok(order);
            }
            catch (DataNotFoundException e)
            {
                return StatusCode(StatusCodes.Status404NotFound,
                    e.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error getting all records by userId");
            }
        }
    }
}
