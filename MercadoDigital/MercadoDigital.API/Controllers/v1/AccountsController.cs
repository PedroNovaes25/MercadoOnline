using MercadoDigital.Application.Account;
using MercadoDigital.Application.DTO.input.Login;
using MercadoDigital.Application.IServices.Account;
using MercadoDigital.Application.Services;
using MercadoDigital.Application.Services.Account;
using MercadoDigital.Domain.Entities.Identity;
using MercadoDigital.Infra.Ioc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MercadoDigital.API.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IUserService _userManager;
        private readonly IRoleService _roleService;

        public AccountsController(IUserService userService, IRoleService roleService)
        {
            _userManager = userService;
            _roleService = roleService;
        }

        #region About Register
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

                return CreatedAtAction(nameof(GetUserBy), new { username = user.UserName }, user);
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

            var token = await _userManager.CreateToken(user);

            return Ok(token);
        }

        #endregion

        #region About authorization
        [Authorize(Roles = "Admin")]
        [HttpPost("{email}/{roleName}/assign-role")]
        public async Task<IActionResult> AssignRolesToUser(string email, string roleName)
        {
            try
            {
                var isCreated = await _userManager.AssignRolesToUser(email, roleName);
                if (!isCreated)
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error creating record");

                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{email}/{roleName}/assign-role")]
        public async Task<IActionResult> RemoveUserFromRole(string email, string roleName)
        {
            try
            {
                var isDeleted = await _userManager.RemoveUserFromRole(email, roleName);
                if (!isDeleted)
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting record");
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Authorize(Roles = "Admin, Manager")]
        [HttpGet("{email}/assign-role")]
        public async Task<IActionResult> GetUserRoles(string email)
        {
            try
            {
                var result = await _userManager.GetUserRoles(email);
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }


        #endregion

        #region About role register
        [Authorize(Roles = "Admin")]
        [HttpPost("{roleName}/roles")]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            try
            {
                var isCreated = await _roleService.CreateRole(roleName);
                if (!isCreated)
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error creating record");

                return StatusCode(StatusCodes.Status201Created);

            }
            catch (InvalidOperationException e)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                   e.Message);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{roleName}/roles")]
        public async Task<IActionResult> DeleteRole(string roleName)
        {
            try
            {
                var isDeleted = await _roleService.DeleteRole(roleName);
                if (!isDeleted)
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting record");

                return StatusCode(StatusCodes.Status201Created);

            }
            catch (InvalidOperationException e)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                   e.Message);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Authorize(Roles = "Admin, Manager")]
        [HttpGet("/roles")]
        public async Task<IActionResult> GetAllRoles() 
        {
            try
            {
                var result =  await _roleService.GetAllRoles();
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion
    }
}
