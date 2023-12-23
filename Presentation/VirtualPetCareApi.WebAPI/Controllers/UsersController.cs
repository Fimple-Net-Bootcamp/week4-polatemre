using VirtualPetCareApi.Application.Features.Commands.AppUsers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VirtualPetCareApi.Application.Features.Queries.Activities;

namespace VirtualPetCareApi.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserCommand createUserCommand)
        {
            CreateUserCommandResponse response = await _mediator.Send(createUserCommand);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdUserQuery getByIdUserQuery)
        {
            GetByIdUserQueryResponse response = await _mediator.Send(getByIdUserQuery);
            return Ok(response);
        }

        [HttpGet("statistics/{Id}")]
        public async Task<IActionResult> GetStatisticsById([FromRoute] GetByIdUserQuery getByIdUserQuery)
        {
            GetByIdUserQueryResponse response = await _mediator.Send(getByIdUserQuery);
            return Ok(response);
        }
    }
}
