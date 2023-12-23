using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VirtualPetCareApi.Application.Features.Commands.Activities;

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

        [HttpPost]
        public async Task<IActionResult> Post(CreateEducationCommand createEducationCommanRequest)
        {
            CreateEducationCommandResponse response = await _mediator.Send(createEducationCommanRequest);

            return Ok(response);
        }
    }
}
