using MediatR;
using Microsoft.AspNetCore.Mvc;
using VirtualFoodCareApi.Application.Features.Commands.Foods;
using VirtualPetCareApi.Application.Features.Queries.Foods;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VirtualPetCareApi.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FoodsController : ControllerBase
    {
        readonly IMediator _mediator;

        public FoodsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllFoodQuery getAllFoodQueryRequest)
        {
            GetAllFoodQueryResponse response = await _mediator.Send(getAllFoodQueryRequest);
            return Ok(response);
        }

        [HttpPost("{petId}")]
        public async Task<IActionResult> GiveFood([FromRoute] int petId, [FromBody] int foodId)
        {
            var updateFoodCommand = new UpdateFoodCommand()
            {
                FoodId = foodId,
                PetId = petId
            };
            UpdateFoodCommandResponse response = await _mediator.Send(updateFoodCommand);
            return Ok(response);
        }
    }
}
