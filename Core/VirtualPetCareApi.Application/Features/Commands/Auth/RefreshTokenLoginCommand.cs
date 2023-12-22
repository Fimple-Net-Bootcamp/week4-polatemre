using VirtualPetCareApi.Application.Abstractions.Services;
using VirtualPetCareApi.Application.Abstractions.Token;
using VirtualPetCareApi.Application.DTOs;
using VirtualPetCareApi.Application.Exceptions;
using VirtualPetCareApi.Application.Repositories;
using VirtualPetCareApi.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace VirtualPetCareApi.Application.Features.Commands.Auth
{
    public class RefreshTokenLoginCommand : IRequest<RefreshTokenLoginCommandResponse>
    {
        public string RefreshToken { get; set; }

        public class RefreshTokenLoginCommandHandler : IRequestHandler<RefreshTokenLoginCommand, RefreshTokenLoginCommandResponse>
        {
            readonly IAuthService _authService;
            public RefreshTokenLoginCommandHandler(IAuthService authService)
            {
                _authService = authService;
            }
            public async Task<RefreshTokenLoginCommandResponse> Handle(RefreshTokenLoginCommand request, CancellationToken cancellationToken)
            {
                var token = await _authService.RefreshTokenLoginAsync(request.RefreshToken);
                return new()
                {
                    Token = token
                };
            }
        }

    }

    public class RefreshTokenLoginCommandResponse
    {
        public Token Token { get; set; }
    }
}
