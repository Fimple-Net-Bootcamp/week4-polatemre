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
    public class GetByPetIdEducationQuery : IRequest<GetByPetIdEducationQueryResponse>
    {
        public int PetId { get; set; }
        public class GetByPetIdEducationQueryHandler : IRequestHandler<GetByPetIdEducationQuery, GetByPetIdEducationQueryResponse>
        {
            readonly IEducationReadRepository _activityReadRepository;
            readonly IPetReadRepository _petReadRepository;

            public GetByPetIdEducationQueryHandler(IEducationReadRepository activityReadRepository, IPetReadRepository petReadRepository)
            {
                _activityReadRepository = activityReadRepository;
                _petReadRepository = petReadRepository;
            }
            public async Task<GetByPetIdEducationQueryResponse> Handle(GetByPetIdEducationQuery request, CancellationToken cancellationToken)
            {
                Pet? pet = await _petReadRepository.Table.Where(x => x.Id == request.PetId).Include(x => x.Educations).FirstOrDefaultAsync();
                var socialInteractions = pet.Educations.Select(x => x.Name).ToList();
                return new()
                {
                    Name = pet.Name,
                    Educations = socialInteractions
                };
            }
        }
    }

    public class GetByPetIdEducationQueryResponse
    {
        public string Name { get; set; }
        public List<string> Educations { get; set; }
    }
}
