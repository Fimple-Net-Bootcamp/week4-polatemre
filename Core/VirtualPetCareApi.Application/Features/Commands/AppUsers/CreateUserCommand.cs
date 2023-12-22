using VirtualPetCareApi.Application.Abstractions.Services;
using VirtualPetCareApi.Application.DTOs.User;
using VirtualPetCareApi.Application.Exceptions;
using VirtualPetCareApi.Application.Repositories;
using VirtualPetCareApi.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace VirtualPetCareApi.Application.Features.Commands.AppUsers
{
    public class CreateUserCommand : IRequest<CreateUserCommandResponse>
    {
        public string NameSurname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }

        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserCommandResponse>
        {
            readonly IUserService _userService;

            public CreateUserCommandHandler(IUserService userService)
            {
                _userService = userService;
            }

            public async Task<CreateUserCommandResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                CreateUserResponse response = await _userService.CreateAsync(new()
                {
                    Password = request.Password,
                    PasswordConfirm = request.PasswordConfirm,
                    Username = request.Username,
                    Email = request.Email,
                    NameSurname = request.NameSurname,
                });

                return new()
                {
                    Message = response.Message,
                    Succeeded = response.Succeeded
                };
            }
        }

    }

    public class CreateUserCommandResponse
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
    }
}
