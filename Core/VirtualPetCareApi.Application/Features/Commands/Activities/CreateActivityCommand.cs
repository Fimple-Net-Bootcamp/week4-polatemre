using VirtualPetCareApi.Application.Repositories;
using MediatR;
using Activity = VirtualPetCareApi.Domain.Entities.Activity;

namespace VirtualPetCareApi.Application.Features.Commands.Activities
{
    public class CreateActivityCommand : IRequest<CreateActivityCommandResponse>
    {
        public int PetId { get; set; }
        public string Name { get; set; }

        public class CreateActivityCommandHandler : IRequestHandler<CreateActivityCommand, CreateActivityCommandResponse>
        {
            readonly IActivityWriteRepository _activityWriteRepository;
            public CreateActivityCommandHandler(IActivityWriteRepository activityWriteRepository)
            {
                _activityWriteRepository = activityWriteRepository;
            }
            public async Task<CreateActivityCommandResponse> Handle(CreateActivityCommand request, CancellationToken cancellationToken)
            {
                var activity = new Activity()
                {
                    PetId = request.PetId,
                    Name = request.Name,
                };

                await _activityWriteRepository.AddAsync(activity);
                await _activityWriteRepository.SaveAsync();
                return new CreateActivityCommandResponse() 
                { 
                    Id = activity.Id,
                    Name = activity.Name,
                    PetId = activity.PetId
                };
            }
        }

    }

    public class CreateActivityCommandResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PetId { get; set; }
    }
}
