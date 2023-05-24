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
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [Authorize]
        [HttpPost("")]
        public async Task<IActionResult> Create(ProductInputDTO productDTO)
        {
            try
            {
                var produtc = await _productService.Create(productDTO);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating records.");
            }
        }

        [Authorize]
        [HttpPut("{productId}")]
        public async Task<IActionResult> Update(ProductInputDTO productDTO, int productId)
        {
            try
            {
                var isUpdated = await _productService.Update(productDTO, productId);
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

        [Authorize]
        [HttpDelete("{productId}")]
        public async Task<IActionResult> Delete(int productId)
        {
            try
            {
                var isDeleted = await _productService.Delete(productId);
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
                    "Error Deleting record");
            }
        }

        [Authorize]
        [HttpGet("")]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var category = await _productService.GetAllProducts();
                return Ok(category);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error getting all records.");
            }
        }

        [Authorize]
        [HttpGet("by-category/{id}")]
        public async Task<IActionResult> GetAllProductsFromCategoryId(int id)
        {
            try
            {
                var category = await _productService.GetAllProductsFromCategoryId(id);
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
                    "Error getting record by category id.");
            }
        }

        [Authorize]
        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProductById(int productId)
        {
            try
            {
                var category = await _productService.GetProductById(productId);
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
                    "Error getting record by product id.");
            }
        }

        [Authorize]
        [HttpGet("{name}")]
        public async Task<IActionResult> GetProductByName(string name)
        {
            try
            {
                var category = await _productService.GetProductByName(name);
                return Ok(category);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error getting records by name.");
            }
        }
    }
}
