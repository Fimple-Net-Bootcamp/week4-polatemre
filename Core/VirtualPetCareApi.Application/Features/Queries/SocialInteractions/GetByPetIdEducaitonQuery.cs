using VirtualPetCareApi.Application.Repositories;
using VirtualPetCareApi.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace VirtualPetCareApi.Application.Features.Queries.Educations
{
    public class GetByPetIdEducationQuery : IRequest<GetByPetIdAcitivityQueryResponse>
    {
        public int PetId { get; set; }
        public class GetByPetIdEducationQueryHandler : IRequestHandler<GetByPetIdEducationQuery, GetByPetIdAcitivityQueryResponse>
        {
            readonly IEducationReadRepository _activityReadRepository;
            readonly IPetReadRepository _petReadRepository;

            public GetByPetIdEducationQueryHandler(IEducationReadRepository activityReadRepository, IPetReadRepository petReadRepository)
            {
                _activityReadRepository = activityReadRepository;
                _petReadRepository = petReadRepository;
            }
            public async Task<GetByPetIdAcitivityQueryResponse> Handle(GetByPetIdEducationQuery request, CancellationToken cancellationToken)
            {
                Pet? pet = await _petReadRepository.Table.Where(x => x.Id == request.PetId).Include(x => x.Educations).FirstOrDefaultAsync();
                var activities = pet.Educations.Select(x => x.Name).ToList();
                return new()
                {
                    Name = pet.Name,
                    Educations = activities
                };
            }
        }
    }

    public class GetByPetIdAcitivityQueryResponse
    {
        public string Name { get; set; }
        public List<string> Educations { get; set; }
    }
}
