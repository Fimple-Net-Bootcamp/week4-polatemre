using MediatR;
using Microsoft.AspNetCore.Mvc;
using VirtualHealthCareApi.Application.Features.Queries.Healths;
using VirtualPetCareApi.Application.Features.Commands.Pets;
using VirtualPetCareApi.Application.Features.Queries.Activities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VirtualPetCareApi.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class HealthsController : ControllerBase
    {
        readonly IMediator _mediator;

        public HealthsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{PetId}")]
        public async Task<IActionResult> Get([FromRoute] GetByPetIdHealthQuery getByPetIdHealthQuery)
        {
            GetByPetIdHealthQueryResponse response = await _mediator.Send(getByPetIdHealthQuery);
            return Ok(response);
        }

        [HttpPatch("{petId}")]
        public async Task<IActionResult> Get([FromRoute] int petId, [FromBody] PatchHealthCommand patchHealthCommand)
        {
            PatchHealthCommandResponse response = await _mediator.Send(patchHealthCommand);
            return Ok(response);
        }

    }
}
