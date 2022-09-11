using Core.Security.Entities;

namespace Kodlama.io.Devs.Application.Features.RefreshTokens.Commands.CreateRefreshTokenToUser;

public class CreateRefreshTokenToUserCommandRequest : IRequest<Core.Security.JWT.RefreshToken>
{
    public User User { get; set; }

    public bool IsSaveChanges { get; set; }
}
