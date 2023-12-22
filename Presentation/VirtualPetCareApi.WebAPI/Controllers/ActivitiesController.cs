using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using VirtualPetCareApi.Application.Features.Commands.Activities;
using VirtualPetCareApi.Application.Features.Queries.Activities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VirtualPetCareApi.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        readonly IMediator _mediator;

        public ActivitiesController(
            IMediator mediator)
        {
            _mediator = mediator;
        }

        //[HttpGet]
        //public async Task<IActionResult> Get([FromQuery] GetAllActivityQuery getAllActivityQueryRequest)
        //{
        //    GetAllActivityQueryResponse response = await _mediator.Send(getAllActivityQueryRequest);
        //    return Ok(response);
        //}

        [HttpGet("{PetId}")]
        public async Task<IActionResult> Get([FromRoute] GetByPetIdAcitivityQuery getByIdAcitivityQuery)
        {
            GetByPetIdAcitivityQueryResponse response = await _mediator.Send(getByIdAcitivityQuery);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateActivityCommand createActivityCommanRequest)
        {
            CreateActivityCommandResponse response = await _mediator.Send(createActivityCommanRequest);

            return Ok(response);
        }

        //[Authorize(AuthenticationSchemes = "User")]
        //[HttpPut]
        //public async Task<IActionResult> Put([FromBody] UpdateActivityCommand updateActivityCommand)
        //{
        //    UpdateActivityCommandResponse response = await _mediator.Send(updateActivityCommand);
        //    return Ok();
        //}

        //[Authorize(AuthenticationSchemes = "User")]
        //[HttpDelete("{Id}")]
        //public async Task<IActionResult> Delete([FromRoute] RemoveActivityCommand removeActivityCommand)
        //{
        //    RemoveActivityCommandResponse response = await _mediator.Send(removeActivityCommand);
        //    return Ok();
        //}

        //[Authorize(AuthenticationSchemes = "User")]
        //[HttpPost("[action]")]
        //public async Task<IActionResult> Upload([FromQuery] UploadActivityImageCommand uploadActivityImageCommand)
        //{
        //    UploadActivityImageCommandResponse response = await _mediator.Send(uploadActivityImageCommand);

        //    return Ok();
        //}

        //[Authorize(AuthenticationSchemes = "User")]
        //[HttpGet("[action]/{Id}")]
        //public async Task<IActionResult> GetActivityImages([FromRoute] GetActivityImagesQuery getActivityImagesQuery)
        //{
        //    List<GetActivityImagesQueryResponse> response = await _mediator.Send(getActivityImagesQuery);

        //    return Ok(response);
        //}

        //[Authorize(AuthenticationSchemes = "User")]
        //[HttpDelete("[action]/{Id}")]
        //public async Task<IActionResult> DeleteActivityImages([FromRoute] RemoveActivityImageCommand removeActivityImageCommand, [FromQuery] string imageId)
        //{
        //    removeActivityImageCommand.ImageId = imageId;
        //    RemoveActivityImageCommandResponse response = await _mediator.Send(removeActivityImageCommand);

        //    return Ok();
        //}

        //[HttpGet("[action]")]
        //[Authorize(AuthenticationSchemes = "User")]
        //public async Task<IActionResult> ChangeShowcaseImage([FromQuery] ChangeShowcaseImageCommand changeShowcaseImageCommandRequest)
        //{
        //    ChangeShowcaseImageCommandResponse response = await _mediator.Send(changeShowcaseImageCommandRequest);
        //    return Ok(response);
        //}
    }
}
