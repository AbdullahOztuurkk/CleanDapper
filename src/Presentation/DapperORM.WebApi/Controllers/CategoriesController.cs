using DapperORM.Application.Features.Commands.CreateEvent;
using DapperORM.Application.Features.Commands.DeleteEvent;
using DapperORM.Application.Features.Commands.UpdateEvent;
using DapperORM.Application.Features.Queries.GetAllEvent;
using DapperORM.Application.Features.Queries.GetEvent;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DapperORM.WebApi.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator mediator;
        public CategoriesController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        /// <summary>
        /// Get all categories
        /// </summary>
        /// <param name="request">Empty request body</param>
        /// <returns>List of categories</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllCategoryQueryRequest request)
        {
            var result = await mediator.Send(request);
            if (result.IsSuccess == false)
                return BadRequest(result.Message);
            return Ok(result);
        }

        /// <summary>
        /// Get category by Id
        /// </summary>
        /// <param name="request">Category identifier number</param>
        /// <returns>A Category</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet(":Id")]
        public async Task<IActionResult> Get([FromQuery] GetCategoryQueryRequest request)
        {
            var result = await mediator.Send(request);
            if (result.IsSuccess == false)
                return BadRequest(result.Message);
            return Ok(result);
        }

        /// <summary>
        /// Add category to System
        /// </summary>
        /// <param name="request">Category body</param>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryCommandRequest request)
        {
            var result = await mediator.Send(request);
            if (result.IsSuccess == false)
                return BadRequest(result.Message);
            return Ok(result);
        }

        /// <summary>
        /// Delete category from System
        /// </summary>
        /// <param name="request">Category identifier number</param>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DeleteCategoryCommandRequest request)
        {
            var result = await mediator.Send(request);
            if (result.IsSuccess == false)
                return BadRequest(result.Message);
            return Ok(result);
        }

        /// <summary>
        /// Update category in System
        /// </summary>
        /// <param name="request">Category features</param>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryCommandRequest request)
        {
            var result = await mediator.Send(request);
            if (result.IsSuccess == false)
                return BadRequest(result.Message);
            return Ok(result);
        }
    }
}
