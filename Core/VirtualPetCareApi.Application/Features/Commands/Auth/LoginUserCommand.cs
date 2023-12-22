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
    public class LoginUserCommand : IRequest<LoginUserCommandResponse>
    {
        public string UsernameOrEmail { get; set; }
        public string Password { get; set; }

        public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserCommandResponse>
        {
            readonly ITokenHandler _tokenHandler;
            readonly IAuthService _authService;
            public LoginUserCommandHandler(ITokenHandler tokenHandler, IAuthService authService)
            {
                _tokenHandler = tokenHandler;
                _authService = authService;
            }
            public async Task<LoginUserCommandResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
            {

                var token = await _authService.LoginAsync(request.UsernameOrEmail, request.Password, 900);
                return new()
                {
                    Token = token
                };
            }
        }

    }

    public class LoginUserCommandResponse
    {
        public Token Token { get; set; }
    }
}
