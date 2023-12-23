using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VirtualPetCareApi.Application.Features.Commands.Activities;
using VirtualPetCareApi.Application.Features.Queries.Educations;

namespace VirtualPetCareApi.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EducationsController : ControllerBase
    {
        readonly IMediator _mediator;

        public EducationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{PetId}")]
        public async Task<IActionResult> Get([FromRoute] GetByPetIdEducationQuery getByIdAcitivityQuery)
        {
            GetByPetIdEducationQueryResponse response = await _mediator.Send(getByIdAcitivityQuery);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateEducationCommand createEducationCommanRequest)
        {
            CreateEducationCommandResponse response = await _mediator.Send(createEducationCommanRequest);

            return Ok(response);
        }
    }
}
