using MercadoDigital.Application.DTO.Input;
using MercadoDigital.Application.IServices;
using MercadoDigital.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MercadoDigital.API.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CategoriesProductsController : ControllerBase
    {
        private readonly ICategoryProductService _categoryProductService;

        public CategoriesProductsController(ICategoryProductService categoryProductService)
        {
            _categoryProductService = categoryProductService;
        }

        [Authorize(Roles = "Admin, Manager")]
        [HttpPost("")]
        public async Task<IActionResult> Create(CategoryProductInputDTO[] categoriesProductsDTO) 
        {
            try
            {
                var isCreated = await _categoryProductService.Create(categoriesProductsDTO);
                if (!isCreated)
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error creating record");

                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating record");
            }
        }
    }
}
