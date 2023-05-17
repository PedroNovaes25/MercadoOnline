using MercadoDigital.Application.DTO.Input;
using MercadoDigital.Application.IServices;
using MercadoDigital.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MercadoDigital.API.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemService _orderItemService;

        public OrderItemController(IOrderItemService ordertemService)
        {
            _orderItemService = ordertemService;
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateItemOrder(OrderItemInputDTO[] ordersItemDTO)
        {
            try
            {
                 var orderCreated = await _orderItemService.Create(ordersItemDTO);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating record");
            }
        }
    }
}
