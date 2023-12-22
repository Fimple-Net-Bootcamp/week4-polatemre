using VirtualPetCareApi.Application.Repositories;
using VirtualPetCareApi.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPetCareApi.Application.Features.Commands.Pets
{
    public class UpdatePetCommand : IRequest<UpdatePetCommandResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }

        public class UpdatePetCommandHandler : IRequestHandler<UpdatePetCommand, UpdatePetCommandResponse>
        {
            readonly IPetWriteRepository _petWriteRepository;
            readonly IPetReadRepository _petReadRepository;
            readonly ILogger<UpdatePetCommandHandler> _logger;
            public UpdatePetCommandHandler(IPetWriteRepository petWriteRepository, IPetReadRepository petReadRepository)
            {
                _petWriteRepository = petWriteRepository;
                _petReadRepository = petReadRepository;
            }
            public async Task<UpdatePetCommandResponse> Handle(UpdatePetCommand request, CancellationToken cancellationToken)
            {
                Pet pet = await _petReadRepository.GetByIdAsync(request.Id);
                pet.Description = request.Description;
                pet.Name = request.Name;
                pet.Status = request.Status;

                await _petWriteRepository.SaveAsync();

                return new()
                {
                    Id = request.Id,
                    Status = request.Status,
                    Description = request.Description,
                    Name = request.Name
                };
            }
        }

    }

    public class UpdatePetCommandResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
    }
}
