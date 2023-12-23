using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using VirtualPetCareApi.Application.Features.Commands.Activities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VirtualPetCareApi.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SocialInteractionsController : ControllerBase
    {
        readonly IMediator _mediator;

        public SocialInteractionsController(
            IMediator mediator)
        {
            _mediator = mediator;
        }

        //[HttpGet]
        //public async Task<IActionResult> Get([FromQuery] GetAllSocialInteractionQuery getAllSocialInteractionQueryRequest)
        //{
        //    GetAllSocialInteractionQueryResponse response = await _mediator.Send(getAllSocialInteractionQueryRequest);
        //    return Ok(response);
        //}

        [HttpGet("{PetId}")]
        public async Task<IActionResult> Get([FromRoute] GetByPetIdAcitivityQuery getByIdAcitivityQuery)
        {
            GetByPetIdSocialInteractionQueryResponse response = await _mediator.Send(getByIdAcitivityQuery);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateSocialInteractionCommand createSocialInteractionCommanRequest)
        {
            CreateSocialInteractionCommandResponse response = await _mediator.Send(createSocialInteractionCommanRequest);

            return Ok(response);
        }

        //[Authorize(AuthenticationSchemes = "User")]
        //[HttpPut]
        //public async Task<IActionResult> Put([FromBody] UpdateSocialInteractionCommand updateSocialInteractionCommand)
        //{
        //    UpdateSocialInteractionCommandResponse response = await _mediator.Send(updateSocialInteractionCommand);
        //    return Ok();
        //}

        //[Authorize(AuthenticationSchemes = "User")]
        //[HttpDelete("{Id}")]
        //public async Task<IActionResult> Delete([FromRoute] RemoveSocialInteractionCommand removeSocialInteractionCommand)
        //{
        //    RemoveSocialInteractionCommandResponse response = await _mediator.Send(removeSocialInteractionCommand);
        //    return Ok();
        //}

        //[Authorize(AuthenticationSchemes = "User")]
        //[HttpPost("[action]")]
        //public async Task<IActionResult> Upload([FromQuery] UploadSocialInteractionImageCommand uploadSocialInteractionImageCommand)
        //{
        //    UploadSocialInteractionImageCommandResponse response = await _mediator.Send(uploadSocialInteractionImageCommand);

        //    return Ok();
        //}

        //[Authorize(AuthenticationSchemes = "User")]
        //[HttpGet("[action]/{Id}")]
        //public async Task<IActionResult> GetSocialInteractionImages([FromRoute] GetSocialInteractionImagesQuery getSocialInteractionImagesQuery)
        //{
        //    List<GetSocialInteractionImagesQueryResponse> response = await _mediator.Send(getSocialInteractionImagesQuery);

        //    return Ok(response);
        //}

        //[Authorize(AuthenticationSchemes = "User")]
        //[HttpDelete("[action]/{Id}")]
        //public async Task<IActionResult> DeleteSocialInteractionImages([FromRoute] RemoveSocialInteractionImageCommand removeSocialInteractionImageCommand, [FromQuery] string imageId)
        //{
        //    removeSocialInteractionImageCommand.ImageId = imageId;
        //    RemoveSocialInteractionImageCommandResponse response = await _mediator.Send(removeSocialInteractionImageCommand);

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
