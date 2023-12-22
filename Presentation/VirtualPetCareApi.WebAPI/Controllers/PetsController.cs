using MediatR;
using Microsoft.AspNetCore.Mvc;
using VirtualPetCareApi.Application.Features.Commands.Activities;
using VirtualPetCareApi.Application.Features.Commands.Pets;
using VirtualPetCareApi.Application.Features.Queries.Activities;
using VirtualPetCareApi.Application.Features.Queries.Pets;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VirtualPetCareApi.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        readonly IMediator _mediator;

        public PetsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllPetQuery getAllPetQueryRequest)
        {
            GetAllPetQueryResponse response = await _mediator.Send(getAllPetQueryRequest);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdPetQuery getByIdPetQuery)
        {
            GetByIdPetQueryResponse response = await _mediator.Send(getByIdPetQuery);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePetCommand createPetCommand)
        {
            CreatePetCommandResponse response = await _mediator.Send(createPetCommand);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdatePetCommand updatePetCommand)
        {
            updatePetCommand.Id = id;
            UpdatePetCommandResponse response = await _mediator.Send(updatePetCommand);
            return Ok(response);
        }
    }
}
