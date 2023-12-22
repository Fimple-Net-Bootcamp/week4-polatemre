using VirtualPetCareApi.Application.Repositories;
using MediatR;
using Pet = VirtualPetCareApi.Domain.Entities.Pet;

namespace VirtualPetCareApi.Application.Features.Commands.Pets
{
    public class CreatePetCommand : IRequest<CreatePetCommandResponse>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public bool Status { get; set; }
        public int HealthId { get; set; }

        public class CreatePetCommandHandler : IRequestHandler<CreatePetCommand, CreatePetCommandResponse>
        {
            readonly IPetWriteRepository _petWriteRepository;
            public CreatePetCommandHandler(IPetWriteRepository petWriteRepository)
            {
                _petWriteRepository = petWriteRepository;
            }
            public async Task<CreatePetCommandResponse> Handle(CreatePetCommand request, CancellationToken cancellationToken)
            {
                var pet = new Pet()
                {
                    Description = request.Description,
                    Status = request.Status,
                    HealthId = request.HealthId,
                    UserId = request.UserId,
                    Name = request.Name,
                };

                await _petWriteRepository.AddAsync(pet);
                await _petWriteRepository.SaveAsync();
                return new CreatePetCommandResponse()
                {
                    Id = pet.Id,
                    Name = pet.Name,
                    UserId = pet.UserId,
                    HealthId = pet.HealthId,
                    Description = pet.Description
                };
            }
        }

    }

    public class CreatePetCommandResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public int HealthId { get; set; }
        public string Description { get; set; }
    }
}
