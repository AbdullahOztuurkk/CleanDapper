using DapperORM.Application.Features.Commands.CreateEvent;
using DapperORM.Application.Features.Commands.DeleteEvent;
using DapperORM.Application.Features.Commands.UpdateEvent;
using DapperORM.Application.Features.Queries.GetAllEvent;
using DapperORM.Application.Features.Queries.GetEvent;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DapperORM.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator mediator;
        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        /// <summary>
        /// Get all products
        /// </summary>
        /// <param name="request">Empty request body</param>
        /// <returns>List of products</returns>
        /// <response code="200">Ok</response>
        /// <response code="400"> Bad Request</response>
        [HttpGet("/")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllProductQueryRequest request)
        {
            var result = await mediator.Send(request);
            if (result.IsSuccess == false)
                return BadRequest(result.Message);
            return Ok(result);
        }

        /// <summary>
        /// Get all products by category
        /// </summary>
        /// <param name="request">Category identifier number</param>
        /// <returns>List of products</returns>
        /// <response code="200">Ok</response>
        /// <response code="400"> Bad Request</response>
        [HttpGet("/c/{Id}")]
        public async Task<IActionResult> GetAllByCategory([FromQuery] GetProductByCategoryQueryRequest request)
        {
            var result = await mediator.Send(request);
            if (result.IsSuccess == false)
                return BadRequest(result.Message);
            return Ok(result);
        }

        /// <summary>
        /// Get product by Id
        /// </summary>
        /// <param name="request">Product identifier number</param>
        /// <returns>A product</returns>
        /// <response code="200">Ok</response>
        /// <response code="400"> Bad Request</response>
        [HttpGet("/{Id}")]
        public async Task<IActionResult> Get([FromQuery] GetProductQueryRequest request)
        {
            var result = await mediator.Send(request);
            if (result.IsSuccess == false)
                return BadRequest(result.Message);
            return Ok(result);
        }

        /// <summary>
        /// Add Product to System
        /// </summary>
        /// <param name="request">Product body</param>
        /// <response code="200">Ok</response>
        /// <response code="400"> Bad Request</response>
        [Route("/")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductCommandRequest request)
        {
            var result = await mediator.Send(request);
            if (result.IsSuccess == false)
                return BadRequest(result.Message);
            return Ok(result);
        }
        /// <summary>
        /// Delete product from System
        /// </summary>
        /// <param name="request">Product identifier number</param>
        /// <response code="200">Ok</response>
        /// <response code="400"> Bad Request</response>
        [Route("/{Id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DeleteProductCommandRequest request)
        {
            var result = await mediator.Send(request);
            if (result.IsSuccess == false)
                return BadRequest(result.Message);
            return Ok(result);
        }

        /// <summary>
        /// Update product in System
        /// </summary>
        /// <param name="request">Product features</param>
        /// <response code="200">Ok</response>
        /// <response code="400"> Bad Request</response>
        [Route("/")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProductCommandRequest request)
        {
            var result = await mediator.Send(request);
            if (result.IsSuccess == false)
                return BadRequest(result.Message);
            return Ok(result);
        }
    }
}
