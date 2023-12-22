using VirtualPetCareApi.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPetCareApi.Application.Features.Commands.Activities
{
    public class RemoveActivityCommand : IRequest<RemoveActivityCommandResponse>
    {
        public int Id { get; set; }

        public class RemoveActivityCommandHandler : IRequestHandler<RemoveActivityCommand, RemoveActivityCommandResponse>
        {
            readonly IActivityWriteRepository _activityWriteRepository;
            public RemoveActivityCommandHandler(IActivityWriteRepository activityWriteRepository)
            {
                _activityWriteRepository = activityWriteRepository;
            }
            public async Task<RemoveActivityCommandResponse> Handle(RemoveActivityCommand request, CancellationToken cancellationToken)
            {
                await _activityWriteRepository.RemoveAsync(request.Id);
                await _activityWriteRepository.SaveAsync();

                return new();
            }
        }
    }

    public class RemoveActivityCommandResponse
    {

    }
}
