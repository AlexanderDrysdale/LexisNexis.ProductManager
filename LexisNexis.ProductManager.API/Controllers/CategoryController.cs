using LexisNexis.ProductManager.Contracts.DTO;
using LexisNexis.ProductManager.Core.Exceptions;
using LexisNexis.ProductManager.Core.Handlers.Commands;
using LexisNexis.ProductManager.Core.Handlers.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace LexisNexis.ProductManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET /api/categories (flat list)
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CategoryDTO>), (int)HttpStatusCode.OK)]
        [ProducesErrorResponseType(typeof(BaseResponseDTO))]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllCategoriesQuery();
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        // GET /api/categories/tree
        [HttpGet("tree")]
        [ProducesResponseType(typeof(IEnumerable<CategoryNodeDTO>), (int)HttpStatusCode.OK)]
        [ProducesErrorResponseType(typeof(BaseResponseDTO))]
        public async Task<IActionResult> GetTree()
        {
            var query = new GetCategoryTreeQuery();
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        // GET /api/categories/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CategoryDTO), (int)HttpStatusCode.OK)]
        [ProducesErrorResponseType(typeof(BaseResponseDTO))]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var query = new GetCategoryByIdQuery(id);
                var response = await _mediator.Send(query);
                return Ok(response);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new BaseResponseDTO
                {
                    IsSuccess = false,
                    Errors = new[] { ex.Message }
                });
            }
        }

        // POST /api/categories
        // custom serializer
        [HttpPost]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.Created)]
        [ProducesErrorResponseType(typeof(BaseResponseDTO))]
        public async Task<IActionResult> Post([FromBody] CreateCategoryDTO model)
        {
            try
            {
                var command = new CreateCategoryCommand(model);
                var response = await _mediator.Send(command);

                // Explicit serialization with System.Text.Json
                var json = JsonSerializer.Serialize(response, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true,
                    DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
                });

                return Content(json, "application/json");
            }
            catch (InvalidRequestBodyException ex)
            {
                var errorJson = JsonSerializer.Serialize(new BaseResponseDTO
                {
                    IsSuccess = false,
                    Errors = ex.Errors
                }, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true
                });

                return BadRequest(errorJson);
            }
        }
    }
}