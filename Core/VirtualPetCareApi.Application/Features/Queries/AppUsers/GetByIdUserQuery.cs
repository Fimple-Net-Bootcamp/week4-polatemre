using VirtualPetCareApi.Application.Abstractions.Services;
using VirtualPetCareApi.Application.DTOs.User;
using MediatR;

namespace VirtualPetCareApi.Application.Features.Commands.AppUsers
{
    public class GetByIdUserQuery : IRequest<GetByIdUserQueryResponse>
    {
        public string Id { get; set; }

        public class GetByIdUserQueryHandler : IRequestHandler<GetByIdUserQuery, GetByIdUserQueryResponse>
        {
            readonly IUserService _userService;

            public GetByIdUserQueryHandler(IUserService userService)
            {
                _userService = userService;
            }

            public async Task<GetByIdUserQueryResponse> Handle(GetByIdUserQuery request, CancellationToken cancellationToken)
            {
                SingleUser? response = await _userService.GetById(request.Id);

                return new()
                {
                    Id = response.Id,
                    UserName = response.UserName,
                    TwoFactorEnabled = response.TwoFactorEnabled,
                    NameSurname = response.NameSurname,
                    Email = response.Email
                };
            }
        }

    }

    public class GetByIdUserQueryResponse
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string NameSurname { get; set; }
        public string UserName { get; set; }
        public bool TwoFactorEnabled { get; set; }
    }
}
