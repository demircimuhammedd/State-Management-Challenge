using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMC.Application.Commands;
using SMC.Application.Queries;
using SMC.Application.Responses;

namespace SMC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TaskController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<List<SMC.Core.Entities.Task>> Get() => await _mediator.Send(new GetAllTaskQuery());


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<TaskResponse>> CreateEmployee([FromBody] CreateTaskCommand command)
        {
            TaskResponse result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}