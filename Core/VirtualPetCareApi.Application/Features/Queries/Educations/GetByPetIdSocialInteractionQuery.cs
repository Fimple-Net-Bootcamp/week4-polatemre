using VirtualPetCareApi.Application.Repositories;
using VirtualPetCareApi.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace VirtualPetCareApi.Application.Features.Queries.SocialInteractions
{
    public class GetByPetIdAcitivityQuery : IRequest<GetByPetIdAcitivityQueryResponse>
    {
        public int PetId { get; set; }
        public class GetByPetIdSocialInteractionQueryHandler : IRequestHandler<GetByPetIdAcitivityQuery, GetByPetIdAcitivityQueryResponse>
        {
            readonly ISocialInteractionReadRepository _activityReadRepository;
            readonly IPetReadRepository _petReadRepository;

            public GetByPetIdSocialInteractionQueryHandler(ISocialInteractionReadRepository activityReadRepository, IPetReadRepository petReadRepository)
            {
                _activityReadRepository = activityReadRepository;
                _petReadRepository = petReadRepository;
            }
            public async Task<GetByPetIdAcitivityQueryResponse> Handle(GetByPetIdAcitivityQuery request, CancellationToken cancellationToken)
            {
                Pet? pet = await _petReadRepository.Table.Where(x => x.Id == request.PetId).Include(x => x.SocialInteractions).FirstOrDefaultAsync();
                var socialInteractions = pet.SocialInteractions.Select(x => x.Name).ToList();
                return new()
                {
                    Name = pet.Name,
                    SocialInteractions = socialInteractions
                };
            }
        }
    }

    public class GetByPetIdAcitivityQueryResponse
    {
        public string Name { get; set; }
        public List<string> SocialInteractions { get; set; }
    }
}
