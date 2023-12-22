using VirtualPetCareApi.Application.Repositories;
using VirtualPetCareApi.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace VirtualPetCareApi.Application.Features.Queries.Pets
{
    public class GetByIdPetQuery : IRequest<GetByIdPetQueryResponse>
    {
        public int Id { get; set; }
        public class GetByPetIdActivityQueryHandler : IRequestHandler<GetByIdPetQuery, GetByIdPetQueryResponse>
        {
            readonly IActivityReadRepository _activityReadRepository;
            readonly IPetReadRepository _petReadRepository;

            public GetByPetIdActivityQueryHandler(IActivityReadRepository activityReadRepository, IPetReadRepository petReadRepository)
            {
                _activityReadRepository = activityReadRepository;
                _petReadRepository = petReadRepository;
            }
            public async Task<GetByIdPetQueryResponse> Handle(GetByIdPetQuery request, CancellationToken cancellationToken)
            {
                Pet? pet = await _petReadRepository.Table.Include(x => x.Activities).Where(x => x.Id == request.Id).FirstOrDefaultAsync();
                var activities = pet.Activities.Select(x => x.Name).ToList();
                return new()
                {
                    Name = pet.Name,
                    Activities = activities,
                    HealthId = pet.HealthId
                };
            }
        }
    }

    public class GetByIdPetQueryResponse
    {
        public string Name { get; set; }
        public List<string> Activities { get; set; }
        public int HealthId { get; set; }

    }
}
