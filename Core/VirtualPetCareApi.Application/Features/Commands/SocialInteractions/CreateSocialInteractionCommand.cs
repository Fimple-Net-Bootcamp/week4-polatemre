using VirtualPetCareApi.Application.Repositories;
using MediatR;
using SocialInteraction = VirtualPetCareApi.Domain.Entities.SocialInteraction;

namespace VirtualPetCareApi.Application.Features.Commands.Activities
{
    public class CreateSocialInteractionCommand : IRequest<CreateSocialInteractionCommandResponse>
    {
        public int PetId { get; set; }
        public string Name { get; set; }

        public class CreateSocialInteractionCommandHandler : IRequestHandler<CreateSocialInteractionCommand, CreateSocialInteractionCommandResponse>
        {
            readonly ISocialInteractionWriteRepository _SocialInteractionWriteRepository;
            public CreateSocialInteractionCommandHandler(ISocialInteractionWriteRepository SocialInteractionWriteRepository)
            {
                _SocialInteractionWriteRepository = SocialInteractionWriteRepository;
            }
            public async Task<CreateSocialInteractionCommandResponse> Handle(CreateSocialInteractionCommand request, CancellationToken cancellationToken)
            {
                var SocialInteraction = new SocialInteraction()
                {
                    PetId = request.PetId,
                    Name = request.Name,
                };

                await _SocialInteractionWriteRepository.AddAsync(SocialInteraction);
                await _SocialInteractionWriteRepository.SaveAsync();
                return new CreateSocialInteractionCommandResponse() 
                { 
                    Id = SocialInteraction.Id,
                    Name = SocialInteraction.Name,
                    PetId = SocialInteraction.PetId
                };
            }
        }

    }

    public class CreateSocialInteractionCommandResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PetId { get; set; }
    }
}
