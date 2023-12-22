using VirtualPetCareApi.Application.Repositories;
using VirtualPetCareApi.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.EntityFrameworkCore;

namespace VirtualPetCareApi.Application.Features.Commands.Pets
{
    public class PatchHealthCommand : IRequest<PatchHealthCommandResponse>
    {
        public int PetId { get; set; }
        public JsonPatchDocument<Health> Health { get; set; }

        public class PatchHealthCommandHandler : IRequestHandler<PatchHealthCommand, PatchHealthCommandResponse>
        {
            readonly IHealthWriteRepository _healthWriteRepository;
            readonly IPetWriteRepository _petWriteRepository;
            readonly IPetReadRepository _petReadRepository;
            readonly ILogger<PatchHealthCommandHandler> _logger;
            public PatchHealthCommandHandler(IPetWriteRepository petWriteRepository, IPetReadRepository petReadRepository, IHealthWriteRepository healthWriteRepository)
            {
                _petWriteRepository = petWriteRepository;
                _petReadRepository = petReadRepository;
                _healthWriteRepository = healthWriteRepository;
            }
            public async Task<PatchHealthCommandResponse> Handle(PatchHealthCommand request, CancellationToken cancellationToken)
            {
                Pet pet = await _petReadRepository.GetByIdAsync(request.PetId);

                var healthPatch = new JsonPatchDocument<Health>();

                foreach (var opr in request.Health.Operations)
                {
                    healthPatch.Operations.Add(new Operation<Health>
                    {
                        op = opr.op,
                        path = opr.path,
                        value = opr.value
                    });
                }

                healthPatch.ContractResolver =
                request.Health.ContractResolver;

                healthPatch.ApplyTo(pet.Health);

                await _healthWriteRepository.SaveAsync();

                return new()
                {
                    Id = pet.Id,
                    Name = pet.Name,
                    Health = pet.Health
                };
            }
        }

    }

    public class PatchHealthCommandResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Health Health { get; set; }
    }
}
