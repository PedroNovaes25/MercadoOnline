﻿using Lib.Exceptions;
using MercadoDigital.Application.DTO.Input;
using MercadoDigital.Application.IServices;
using MercadoDigital.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MercadoDigital.API.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [Authorize(Roles = "Admin, Manager")]
        [HttpPost("")]
        public async Task<IActionResult> Create(CategoryInputDTO categoryInputDTO)
        {
            try
            {
                var isCreated = await _categoryService.Create(categoryInputDTO);
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

        [Authorize(Roles = "Admin, Manager")]
        [HttpDelete("{categoryId}")]
        public async Task<IActionResult> Delete(int categoryId)
        {
            try
            {
                var isDeleted = await _categoryService.Delete(categoryId);
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

        [Authorize(Roles = "Admin, Manager")]
        [HttpPut("{categoryId}")]
        public async Task<IActionResult> Update(CategoryInputDTO categoryInputDTO, int categoryId)
        {

            try
            {
                var isUpdated = await _categoryService.Update(categoryInputDTO, categoryId);
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

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var categories = await _categoryService.GetAllCategories();
                return Ok(categories);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error getting all records.");
            }
        }

        [HttpGet("{categoryId:int}")]
        public async Task<IActionResult> GetByIdCategory(int categoryId)
        {
            try
            {
                var category = await _categoryService.GetCategoryById(categoryId);
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
                    "Error getting record by user id.");
            }
        }

        [HttpGet("{name}/search")]
        public async Task<IActionResult> GetByName(string name)
        {
            try
            {
                var categories = await _categoryService.GetCategoryByName(name);
                return Ok(categories);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error getting record");
            }
        }

    }
}
