using VirtualPetCareApi.Application.Features.Models;
using VirtualPetCareApi.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace VirtualPetCareApi.Application.Features.Queries.Foods
{
    public class GetAllFoodQuery : PageableQueryRequest, IRequest<GetAllFoodQueryResponse>
    {
        public class GetAllFoodQueryHandler : IRequestHandler<GetAllFoodQuery, GetAllFoodQueryResponse>
        {
            readonly IFoodReadRepository _foodReadRepository;
            readonly ILogger<GetAllFoodQueryHandler> _logger;
            public GetAllFoodQueryHandler(IFoodReadRepository foodReadRepository, ILogger<GetAllFoodQueryHandler> logger)
            {
                _foodReadRepository = foodReadRepository;
                _logger = logger;
            }
            public async Task<GetAllFoodQueryResponse> Handle(GetAllFoodQuery request, CancellationToken cancellationToken)
            {
                _logger.LogInformation("Get all foods...");
                var totalCount = _foodReadRepository.GetAll(false).Count();
                var foods = _foodReadRepository.GetAll(false)
                    .Select(p => new
                    {
                        p.Id,
                        p.Name,
                        p.Value,
                        p.CreatedDate,
                        p.UpdatedDate
                    }).Skip(request.Page * request.Size).Take(request.Size);

                return new()
                {
                    Foods = foods,
                    TotalCount = totalCount
                };
            }
        }
    }

    public class GetAllFoodQueryResponse
    {
        public int TotalCount { get; set; }
        public object Foods { get; set; }
    }
}
