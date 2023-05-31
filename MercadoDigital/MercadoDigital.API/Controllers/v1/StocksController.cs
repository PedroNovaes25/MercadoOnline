using Lib.Exceptions;
using MercadoDigital.Application.DTO.Input;
using MercadoDigital.Application.DTO.Output;
using MercadoDigital.Application.IServices;
using MercadoDigital.Application.Services;
using MercadoDigital.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MercadoDigital.API.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        private readonly IStockService _stockService;

        public StocksController(IStockService stockService)
        {
            _stockService = stockService;
        }

        [Authorize(Roles = "Admin, Manager")]
        [HttpPost("")]
        public async Task<IActionResult> Create(StockInputDTO stockDTO)
        {
            try
            {
                var isCreated = await _stockService.Create(stockDTO);
                if (!isCreated)
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error creating record");

                return StatusCode(StatusCodes.Status201Created); 
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating records.");
            }
        }

        [Authorize(Roles = "Admin, Manager")]
        [HttpPut("{stockId}")]
        public async Task<IActionResult> Update(StockInputDTO stockDTO, int stockId)
        {
            try
            {
                var isUpdated = await _stockService.Update(stockDTO, stockId);
                if (!isUpdated)
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error updating record");
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (DataNotFoundException e)
            {
                return StatusCode(StatusCodes.Status404NotFound,
                    e.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating record");
            }
        }

        [Authorize(Roles = "Admin, Manager")]
        [HttpDelete("{stockId}")]
        public async Task<IActionResult> Delete(int stockId)
        {
            try
            {
                var isDeleted = await _stockService.Delete(stockId);
                if (!isDeleted)
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting record");
                
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (DataNotFoundException e)
            {
                return StatusCode(StatusCodes.Status404NotFound,
                    e.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting record");
            }
        }

        [Authorize]
        [HttpGet("")]
        public async Task<IActionResult> GetAllStock()
        {
            try
            {
                var categories = await _stockService.GetAllStock();
                return Ok(categories);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error getting all records.");
            }
        }

        [Authorize]
        [HttpGet("{stockId}")]
        public async Task<IActionResult> GetStockById(int stockId)
        {
            try
            {
                var category = await _stockService.GetStockById(stockId);
                return Ok(category);
            }
            catch (DataNotFoundException e)
            {
                return StatusCode(StatusCodes.Status404NotFound,
                    e.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error getting record by id");
            }
        }

        [Authorize]
        [HttpGet("by-product/{id}")]
        public async Task<IActionResult> GetStockByProductId(int id)
        {
            try
            {
                var category = await _stockService.GetStockByProductId(id);
                return Ok(category);
            }
            catch (DataNotFoundException e)
            {
                return StatusCode(StatusCodes.Status404NotFound,
                    e.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error getting record by Product Id");
            }
        }
        
      
    }
}
