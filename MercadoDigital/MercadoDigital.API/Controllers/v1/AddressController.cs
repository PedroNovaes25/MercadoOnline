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
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpPost("")]
        public async Task<IActionResult> Create(AddressInputDTO addressDTO)
        {
            try
            {
                var isCreated = await _addressService.Create(addressDTO);
                if (!isCreated)
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error creating record");

                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating record.");
            }
        }

        [HttpPut("{addressId}")]
        public async Task<IActionResult> Update(AddressInputDTO addressDTO, int addressId)
        {
            try
            {
                var isUpdated = await _addressService.Update(addressDTO, addressId);
                if (!isUpdated)
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error updating record");

                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating record.");
            }
        }

        [HttpDelete("{addressId}")]
        public async Task<IActionResult> Delete(int addressId)
        {
            try
            {
                var isDeleted = await _addressService.Delete(addressId);
                if (!isDeleted)
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting record");

                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting record.");
            }
        }

        [HttpGet("{addressId}")]
        public async Task<IActionResult> GetAddressById(int addressId) 
        {
            try
            {
                var address = await _addressService.GetAddressById(addressId);
                return Ok(address);
            }
            catch (DataNotFoundException e)
            {
                return StatusCode(StatusCodes.Status404NotFound,
                    e.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error getting record.");
            }
        }

        [HttpGet("by-user/{id}")]
        public async Task<IActionResult> GetAddressByUserId(int id)
        {
            try
            {
                var address = await _addressService.GetAddressByUserId(id);
                return Ok(address);
            }
            catch (DataNotFoundException e)
            {
                return StatusCode(StatusCodes.Status404NotFound,
                    e.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error getting record.");
            }
        }
    }
}
