using VirtualPetCareApi.Application.Features.Models;
using VirtualPetCareApi.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace VirtualPetCareApi.Application.Features.Queries.Pets
{
    public class GetAllPetQuery : PageableQueryRequest, IRequest<GetAllPetQueryResponse>
    {
        public class GetAllPetQueryHandler : IRequestHandler<GetAllPetQuery, GetAllPetQueryResponse>
        {
            readonly IPetReadRepository _petReadRepository;
            readonly ILogger<GetAllPetQueryHandler> _logger;
            public GetAllPetQueryHandler(IPetReadRepository petReadRepository, ILogger<GetAllPetQueryHandler> logger)
            {
                _petReadRepository = petReadRepository;
                _logger = logger;
            }
            public async Task<GetAllPetQueryResponse> Handle(GetAllPetQuery request, CancellationToken cancellationToken)
            {
                _logger.LogInformation("Get all pets...");
                var totalCount = _petReadRepository.GetAll(false).Count();
                var pets = _petReadRepository.GetAll(false)
                    .Select(p => new
                    {
                        p.Id,
                        p.Name,
                        p.Description,
                        p.CreatedDate,
                        p.UpdatedDate
                    }).Skip(request.Page * request.Size).Take(request.Size);

                return new()
                {
                    Pets = pets,
                    TotalCount = totalCount
                };
            }
        }
    }

    public class GetAllPetQueryResponse
    {
        public int TotalCount { get; set; }
        public object Pets { get; set; }
    }
}
