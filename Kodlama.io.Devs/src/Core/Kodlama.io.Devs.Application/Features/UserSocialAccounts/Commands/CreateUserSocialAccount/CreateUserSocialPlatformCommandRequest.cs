namespace Kodlama.io.Devs.Application.Features.UserSocialAccounts.Commands.CreateUserSocialAccount;

public class CreateUserSocialAccountCommandRequest : IRequest<IResponse>
{
    public int UserId { get; set; }
    public int SocialPlatformId { get; set; }
    public string Path { get; set; }
}