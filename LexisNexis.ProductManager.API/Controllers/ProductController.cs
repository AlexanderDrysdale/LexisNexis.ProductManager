using LexisNexis.ProductManager.Core.Handlers.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using LexisNexis.ProductManager.Contracts.DTO;
using LexisNexis.ProductManager.Core.Exceptions;
using LexisNexis.ProductManager.Providers.Handlers.Commands;
using LexisNexis.ProductManager.Providers.Handlers.Queries;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using LexisNexis.ProductManager.Core.Handlers.Queries;

namespace LexisNexis.ProductManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET /api/product?name=Phone&categoryId=2
        [HttpGet]
        [ProducesResponseType(typeof(GetProductsResult), (int)HttpStatusCode.OK)]
        [ProducesErrorResponseType(typeof(BaseResponseDTO))]
        public async Task<IActionResult> Get([FromQuery] SearchProductDTO model)
        {
            var query = new GetProductsQuery(model);
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        // GET /api/product/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProductDTO), (int)HttpStatusCode.OK)]
        [ProducesErrorResponseType(typeof(BaseResponseDTO))]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var query = new GetProductByIdQuery(id);
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

        // POST /api/product
        [HttpPost]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.Created)]
        [ProducesErrorResponseType(typeof(BaseResponseDTO))]
        public async Task<IActionResult> Post([FromBody] CreateProductDTO model)
        {
            try
            {
                var command = new CreateProductCommand(model);
                var response = await _mediator.Send(command);
                return StatusCode((int)HttpStatusCode.Created, response);
            }
            catch (InvalidRequestBodyException ex)
            {
                return BadRequest(new BaseResponseDTO
                {
                    IsSuccess = false,
                    Errors = ex.Errors
                });
            }
        }

        // PUT /api/product/{id}
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesErrorResponseType(typeof(BaseResponseDTO))]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateProductDTO model)
        {
            try
            {
                var command = new UpdateProductCommand(id, model);
                await _mediator.Send(command);
                return NoContent();
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new BaseResponseDTO
                {
                    IsSuccess = false,
                    Errors = new[] { ex.Message }
                });
            }
            catch (InvalidRequestBodyException ex)
            {
                return BadRequest(new BaseResponseDTO
                {
                    IsSuccess = false,
                    Errors = ex.Errors
                });
            }
        }

        // DELETE /api/product/{id}
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesErrorResponseType(typeof(BaseResponseDTO))]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var command = new DeleteProductCommand(id);
                await _mediator.Send(command);
                return NoContent();
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
    }
}