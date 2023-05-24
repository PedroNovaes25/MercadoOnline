using MercadoDigital.Application.Account;
using MercadoDigital.Application.DTO.input.Login;
using MercadoDigital.Application.IServices;
using MercadoDigital.Application.Services;
using MercadoDigital.Domain.Entities.Identity;
using MercadoDigital.Infra.Ioc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MercadoDigital.API.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userManager;

        public UsersController(IUserService userService, IAuthenticate authenticate)
        {
            _userManager = userService;
        }

        [HttpPost("")]
        public async Task<IActionResult> Create(UserInputDTO user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = await _userManager.Create(user);

                if (!result.Succeeded)
                {
                    return BadRequest(result.Errors);
                }

                return CreatedAtAction(nameof(GetUserBy), new { username = user.UserName}, user);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating record.");
            }
        }

        [HttpGet("{username}")]
        public async Task<IActionResult> GetUserBy(string username) 
        {
            try
            {

                var user = await _userManager.GetUserBy(username);
                if (user == null) return NotFound();

                return Ok(user);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error getting record by name.");
            }
        }

        // POST: api/Users/BearerToken
        [HttpPost("BearerToken")]
        public async Task<IActionResult> CreateBearerToken(UserLogin request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Bad credentials");
            }

            var user = await _userManager.GetUserBy(request.UserName);

            if (user == null)
            {
                return BadRequest("Bad credentials");
            }

            var isPasswordValid = await _userManager.CheckPasswordAsync(user.UserName, request.Password);

            if (!isPasswordValid)
            {
                return BadRequest("Bad credentials");
            }

            var token = _userManager.CreateToken(user);

            return Ok(token);
        }

    }
}
