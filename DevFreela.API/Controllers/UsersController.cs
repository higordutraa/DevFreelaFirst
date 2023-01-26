using DevFreela.API.Models;
using DevFreela.Application.Commands.CreateComment;
using DevFreela.Application.Commands.CreateUser;
using DevFreela.Application.Queries.GetProjectById;
using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace DevFreela.API.Controllers
{
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var getProjectByIdQuery = new GetProjectByIdQuery(id);

            var project = await _mediator.Send(getProjectByIdQuery);

            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }


        [HttpPost]

        public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = 1 }, command);
        }


        [HttpPut("{id}/login")]

        public IActionResult Login(int id, [FromBody] LoginModel login)
        {
            return NoContent();
        }

    }
}
