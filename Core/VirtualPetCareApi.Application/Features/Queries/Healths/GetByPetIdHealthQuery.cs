using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VirtualPetCareApi.Application.Repositories;
using VirtualPetCareApi.Domain.Entities;

namespace VirtualHealthCareApi.Application.Features.Queries.Healths
{
    public class GetByPetIdHealthQuery : IRequest<GetByPetIdHealthQueryResponse>
    {
        public int PetId { get; set; }
        public class GetByHealthIdActivityQueryHandler : IRequestHandler<GetByPetIdHealthQuery, GetByPetIdHealthQueryResponse>
        {
            readonly IPetReadRepository _petReadRepository;
            readonly IHealthReadRepository _healthReadRepository;

            public GetByHealthIdActivityQueryHandler(IHealthReadRepository healthReadRepository, IPetReadRepository petReadRepository)
            {
                _healthReadRepository = healthReadRepository;
                _petReadRepository = petReadRepository;
            }

            public async Task<GetByPetIdHealthQueryResponse> Handle(GetByPetIdHealthQuery request, CancellationToken cancellationToken)
            {
                var pet = await _petReadRepository.Table.Where(x => x.Id == request.PetId).FirstOrDefaultAsync();
                var health = await _healthReadRepository.Table.FirstOrDefaultAsync(x => x.Id == pet.HealthId);
                return new()
                {
                    Name = pet.Name,
                    HealthValue = health != null ? health.Value : 0
                };
            }
        }
    }

    public class GetByPetIdHealthQueryResponse
    {
        public string Name { get; set; }
        public int HealthValue { get; set; }

    }
}
