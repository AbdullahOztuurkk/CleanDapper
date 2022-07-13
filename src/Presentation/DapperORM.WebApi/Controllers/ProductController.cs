using DapperORM.Application.Features.Commands.CreateEvent;
using DapperORM.Application.Features.Commands.DeleteEvent;
using DapperORM.Application.Features.Commands.UpdateEvent;
using DapperORM.Application.Features.Queries.GetAllEvent;
using DapperORM.Application.Features.Queries.GetEvent;
using DapperORM.Domain.Common.Result;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DapperORM.WebApi.Controllers
{
    [Route("api/products")]
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("get-all")]
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("get-all-by-category")]
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet(":Id")]
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
