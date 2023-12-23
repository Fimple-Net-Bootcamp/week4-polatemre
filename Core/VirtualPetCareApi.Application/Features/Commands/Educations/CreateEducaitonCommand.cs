using VirtualPetCareApi.Application.Repositories;
using MediatR;
using Education = VirtualPetCareApi.Domain.Entities.Education;

namespace VirtualPetCareApi.Application.Features.Commands.Activities
{
    public class CreateEducationCommand : IRequest<CreateEducationCommandResponse>
    {
        public int PetId { get; set; }
        public string Name { get; set; }

        public class CreateEducationCommandHandler : IRequestHandler<CreateEducationCommand, CreateEducationCommandResponse>
        {
            readonly IEducationWriteRepository _EducationWriteRepository;
            public CreateEducationCommandHandler(IEducationWriteRepository EducationWriteRepository)
            {
                _EducationWriteRepository = EducationWriteRepository;
            }
            public async Task<CreateEducationCommandResponse> Handle(CreateEducationCommand request, CancellationToken cancellationToken)
            {
                var Education = new Education()
                {
                    PetId = request.PetId,
                    Name = request.Name,
                };

                await _EducationWriteRepository.AddAsync(Education);
                await _EducationWriteRepository.SaveAsync();
                return new CreateEducationCommandResponse() 
                { 
                    Id = Education.Id,
                    Name = Education.Name,
                    PetId = Education.PetId
                };
            }
        }

    }

    public class CreateEducationCommandResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PetId { get; set; }
    }
}
